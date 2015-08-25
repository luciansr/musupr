using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Musupr.Domain.Models;
using Musupr.Repository;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using Musupr.Domain.DTModels;
using Musupr.Service.Helpers;

namespace Musupr.Service
{
    public class VagasService
    {
        private IUnitOfWork _uow;
        private RecommendationService _recommendationService;
        private JaccardService _jaccardService;

        private System.Linq.Expressions.Expression<Func<Vaga, bool>> vagaValida = v => !v.Criador.Bloqueado && !v.Bloqueada && v.DataExpiracao > DateTime.Now;

        public VagasService(IUnitOfWork uow, RecommendationService recommendationService, JaccardService jaccardService)
        {
            _uow = uow;
            _recommendationService = recommendationService;
            _jaccardService = jaccardService;
        }

        public IEnumerable<VagaModel> GetUltimasNVagas(int n)
        {
            IEnumerable<Vaga> vagas = _uow.Vagas.Get(vagaValida).OrderByDescending(v => v.DataCriacao);

            if (n < vagas.Count())
            {
                return vagas.Take(n).Select(v => new VagaModel(v));
            }
            else
            {
                return vagas.Select(v => new VagaModel(v));
            };
        }

        private IEnumerable<Vaga> OrdenaVagasRestantesPorConteudo(List<JaccardService.PontuacaoVaga> vagasOrdenadasPorJaccard, Usuario usuario)
        {
            IEnumerable<Vaga> vagasOrdenadas = new List<Vaga>();

            List<Vaga> tempVagas = new List<Vaga>();

            if (vagasOrdenadasPorJaccard.Count > 1)
            {
                tempVagas.Add(vagasOrdenadasPorJaccard[0].vaga);
            }
            else
            {
                return vagasOrdenadasPorJaccard.Select(v => v.vaga);
            }

            for (int i = 1; i < vagasOrdenadasPorJaccard.Count(); ++i)
            {
                if (vagasOrdenadasPorJaccard[i].predicaoAvaliacao != vagasOrdenadasPorJaccard[i - 1].predicaoAvaliacao)
                {
                    tempVagas = _recommendationService.OrdenaVagasPorRecomendacao(usuario, tempVagas);

                    vagasOrdenadas = vagasOrdenadas.Concat(tempVagas);

                    tempVagas = new List<Vaga>();
                }

                tempVagas.Add(vagasOrdenadasPorJaccard[i].vaga);
            }

            tempVagas = _recommendationService.OrdenaVagasPorRecomendacao(usuario, tempVagas);

            vagasOrdenadas = vagasOrdenadas.Concat(tempVagas);

            return vagasOrdenadas.ToList();
        }

        public DadosDePaginaDeVagas GetDadosDeVagaPorRecomendacao(int pagina, string busca, int tamanhoPagina, int usuarioID)
        {
            DadosDePaginaDeVagas dadosDePagina = new DadosDePaginaDeVagas();

            string[] palavrasNaBusca;
            IEnumerable<Vaga> vagas = null;

            if (!String.IsNullOrWhiteSpace(busca))
            {
                palavrasNaBusca = busca.Split(' ');
                if (palavrasNaBusca.Count() > 0)
                {
                    vagas = _uow.Vagas.Get(vagaValida).Where(v =>
                        palavrasNaBusca.All(p =>
                            (v.DescricaoMarkdown != null && v.DescricaoMarkdown.ToLower().Contains(p.ToLower())) ||
                            (v.Descricao != null && v.Descricao.ToLower().Contains(p.ToLower())) ||
                            (v.Titulo != null && v.Titulo.ToLower().Contains(p.ToLower())) ||
                            (v.TipoVaga != null && v.TipoVaga.Nome != null && v.TipoVaga.Nome.ToLower().Contains(p.ToLower()))
                            ));
                }
            }

            if (vagas == null)
            {
                vagas = _uow.Vagas.Get(vagaValida);
            }

            IEnumerable<Vaga> vagasPorRecomendacao;

            Usuario usuario = _uow.Usuarios.GetByID(usuarioID);

            dadosDePagina.paginaSelecionada = pagina;



            int numeroVagas = vagas.Count();

            dadosDePagina.numeroPaginas = ((double)numeroVagas / tamanhoPagina) % 1 > 1 ? (numeroVagas / tamanhoPagina) : (numeroVagas / tamanhoPagina) + 1;

            if (pagina > dadosDePagina.numeroPaginas) { pagina = dadosDePagina.numeroPaginas; }

            if (usuario != null)
            {
                IEnumerable<JaccardService.PontuacaoVaga> vagasEPontuacoes = _jaccardService.OrdenaVagasPorCoeficienteDeJaccard(vagas, usuario);

                //vagasPorRecomendacao = OrdenaVagasRestantesPorConteudo(vagasEPontuacoes.ToList(), usuario);
                vagasPorRecomendacao = vagasEPontuacoes.OrderByDescending(v => v.predicaoAvaliacao).Select(v => v.vaga);
            }
            else
            {
                vagasPorRecomendacao = vagas.OrderByDescending(v => v.DataCriacao);
            }

            if (vagasPorRecomendacao.Count() > tamanhoPagina * (pagina - 1))
            {
                if (vagasPorRecomendacao.Count() > tamanhoPagina * pagina)
                {
                    dadosDePagina.vagasDaPagina = vagasPorRecomendacao.Skip(tamanhoPagina * (pagina - 1)).Take(tamanhoPagina).Select(v => new VagaModel(v));
                }
                else
                {
                    dadosDePagina.vagasDaPagina = vagasPorRecomendacao.Skip(tamanhoPagina * (pagina - 1)).Select(v => new VagaModel(v));
                }
            }

            return dadosDePagina;
        }

        public IEnumerable<string> GetTagsFromVagas(IEnumerable<Vaga> vagas, int numeroTags)
        {
            IEnumerable<string> tags = new List<string>();

            char[] charsToRemove = new[] { ' ', ',', '.', '(', ')', '[', ']', '{', '}', '-', ';', ':', '\'', '#', '*', '~', '|', '$', '^', '>', '<', '=', '\n', '`', '+', '_' };

            List<string> palavrasTags = vagas.Where(v => v.DescricaoMarkdown != null)
                .SelectMany(v => HtmlRemoval.StripTagsRegex(v.DescricaoMarkdown).Split(charsToRemove))
                .Concat(

                vagas.Where(v => v.Descricao != null)
                .SelectMany(v => HtmlRemoval.StripTagsRegex(v.Descricao).Split(charsToRemove))

                ).Where(p => p.Length > 4 && p.Length < 25).Select(p => p.ToUpper()).OrderBy(p => p).ToList();

            palavrasTags = palavrasTags.OrderByDescending(p => palavrasTags.Count(p2 => p2.Equals(p))).Distinct().ToList();

            if (palavrasTags.Count() > numeroTags)
            {
                return palavrasTags.Take(numeroTags);
            }

            return palavrasTags;
        }

        public IEnumerable<string> GetNTags(int n)
        {
            IEnumerable<Vaga> vagas = _uow.Vagas.Get(vagaValida);

            return GetTagsFromVagas(vagas, n);
        }

        public VagaModel GetVagaModelByID(int id, int usuarioID = 0)
        {
            Vaga vaga = _uow.Vagas.GetByID(id);
            if (vaga == null) return null;

            VagaModel vagaModel = new VagaModel(vaga);

            Avaliacao avaliacaoUsuario = vaga.avaliacoes.FirstOrDefault(a => a.usuario.ID == usuarioID);

            if (avaliacaoUsuario != null)
            {
                vagaModel.Like = avaliacaoUsuario.Gostou;
            }
            else
            {
                vagaModel.Like = null;
            }

            return vagaModel;
        }

        public SidebarInfoModel GetSidebarInfo(int numberOfTags, int numberOfLastOpportunities)
        {
            SidebarInfoModel sidebarInfo = new SidebarInfoModel();

            List<TipoVaga> tiposVaga = GetTiposDeVagas().ToList();

            sidebarInfo.tipoVagaCounter = new List<SidebarInfoModel.TipoVagaCounter>();

            foreach (TipoVaga tipo in tiposVaga)
            {
                sidebarInfo.tipoVagaCounter.Add(new SidebarInfoModel.TipoVagaCounter
                {
                    tipo = tipo,
                    quantidade = _uow.Vagas.queryGet(vagaValida).Count(v => v.TipoVaga != null && v.TipoVaga.ID == tipo.ID)
                });
            }

            sidebarInfo.tags = GetNTags(numberOfTags);
            sidebarInfo.ultimasOportunidades = GetUltimasNVagas(numberOfLastOpportunities);

            return sidebarInfo;
        }

        public bool AvaliaVaga(bool like, int vagaId, int usuarioID)
        {
            Usuario usuario = _uow.Usuarios.GetByID(usuarioID);
            Vaga vaga = _uow.Vagas.GetByID(vagaId);

            if (usuario != null && vaga != null)
            {
                IEnumerable<Avaliacao> avaliacoes = usuario.avaliacoes.Where(a => a.vaga.ID == vagaId);

                if (avaliacoes.Count() > 1)
                {
                    foreach (Avaliacao avaliacaoTemp in avaliacoes.Skip(1).ToList())
                    {
                        _uow.Avaliacoes.Delete(avaliacaoTemp);
                    }
                }

                Avaliacao avaliacao = avaliacoes.FirstOrDefault();

                if (avaliacao != null)
                {
                    avaliacao.Gostou = like;
                    _uow.Avaliacoes.Update(avaliacao);
                }
                else
                {
                    avaliacao = new Avaliacao();
                    avaliacao.vaga = vaga;
                    avaliacao.usuario = usuario;
                    avaliacao.Gostou = like;
                    _uow.Avaliacoes.Insert(avaliacao);
                }

                _uow.Save();
                return true;
            }

            return false;
        }

        public IEnumerable<TipoVaga> GetTiposDeVagas()
        {
            return _uow.TiposVaga.Get();
        }

        public int SalvarAnuncio(VagaModel vagaModel, int usuarioID, bool EhAdmin)
        {
            Usuario usuario = _uow.Usuarios.GetByID(usuarioID);

            if (!EhAdmin && usuario.vagas != null && usuario.vagas.Count(v => v.DataExpiracao > DateTime.Now) > 5) return -406;

            if (vagaModel == null || usuario == null) return -1;

            if (vagaModel.ID <= 0)
            {
                Vaga vaga = GetVagaFromVagaModel(vagaModel);

                vaga.DataCriacao = DateTime.Now;
                vaga.DataExpiracao = vaga.DataCriacao.AddDays(vagaModel.TempoExpiracao);
                vaga.Criador = usuario;

                if (!EhAdmin && usuario.vagas != null && usuario.vagas.Count > 0 &&
                    usuario.vagas.Any(v =>
                        v.Titulo == vaga.Titulo ||
                        v.DescricaoMarkdown == vaga.DescricaoMarkdown ||
                        v.Descricao == vaga.Descricao
                        ))
                {
                    return -2;
                }

                vaga = _uow.Vagas.Insert(vaga);
                _uow.Save();

                return vaga.ID;
            }
            else
            {
                Vaga vagaAntiga = _uow.Vagas.GetByID(vagaModel.ID);

                if (vagaAntiga.Criador.ID != usuario.ID && !EhAdmin) return -401;

                Vaga vaga = GetVagaFromVagaModel(vagaModel);

                vagaAntiga.Titulo = vaga.Titulo;
                vagaAntiga.Descricao = vaga.Descricao;
                vagaAntiga.DescricaoMarkdown = vaga.DescricaoMarkdown;

                vagaAntiga.ThumbnailUrl = vaga.ThumbnailUrl;
                vagaAntiga.HeaderImageUrl = vaga.HeaderImageUrl;
                vagaAntiga.PostItemImageUrl = vaga.PostItemImageUrl;

                vagaAntiga.DataCriacao = vaga.DataCriacao;
                vagaAntiga.DataExpiracao = DateTime.Now.AddDays(vagaModel.TempoExpiracao);

                vagaAntiga.TipoVaga = vaga.TipoVaga;

                _uow.Vagas.Update(vagaAntiga);
                _uow.Save();

                return vagaAntiga.ID;
            }

        }

        private Vaga GetVagaFromVagaModel(VagaModel vagaModel)
        {
            if (vagaModel == null) return null;

            Vaga vaga = new Vaga();

            vagaModel.Titulo = HtmlRemoval.StripTagsRegex(vagaModel.Titulo);
            vagaModel.DescricaoMarkdown = HtmlRemoval.StripTagsRegex(vagaModel.DescricaoMarkdown);
            vagaModel.Descricao = HtmlRemoval.StripTagsRegex(vagaModel.Descricao);

            vagaModel.ThumbnailUrl = HtmlRemoval.StripTagsRegex(vagaModel.ThumbnailUrl);
            vagaModel.PostItemImageUrl = HtmlRemoval.StripTagsRegex(vagaModel.PostItemImageUrl);
            vagaModel.HeaderImageUrl = HtmlRemoval.StripTagsRegex(vagaModel.HeaderImageUrl);

            Uri uriResult;

            if (!(Uri.TryCreate(vagaModel.ThumbnailUrl, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp))
            {
                vagaModel.ThumbnailUrl = null;
            }

            if (!(Uri.TryCreate(vagaModel.PostItemImageUrl, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp))
            {
                vagaModel.PostItemImageUrl = null;
            }

            if (!(Uri.TryCreate(vagaModel.HeaderImageUrl, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp))
            {
                vagaModel.HeaderImageUrl = null;
            }

            vaga.Titulo = vagaModel.Titulo.Substring(0, vagaModel.Titulo.Length > 29 ? 29 : vagaModel.Titulo.Length);
            vaga.Descricao = vagaModel.Descricao.Substring(0, vagaModel.Descricao.Length > 79 ? 79 : vagaModel.Descricao.Length);
            vaga.DescricaoMarkdown = vagaModel.DescricaoMarkdown.Substring(0, vagaModel.DescricaoMarkdown.Length > 3999 ? 3999 : vagaModel.DescricaoMarkdown.Length);


            vaga.ThumbnailUrl = vagaModel.ThumbnailUrl;
            vaga.HeaderImageUrl = vagaModel.HeaderImageUrl;
            vaga.PostItemImageUrl = vagaModel.PostItemImageUrl;

            vaga.DataCriacao = vagaModel.DataCriacao;
            vaga.DataExpiracao = vagaModel.DataExpiracao;

            vaga.TipoVaga = _uow.TiposVaga.GetByID(vagaModel.TipoVagaID);

            return vaga;
        }

        public IEnumerable<VagaModel> GetVagasFromUsuario(int usuarioID, bool RequerenteEhAdmin)
        {
            if (RequerenteEhAdmin)
            {
                return _uow.Vagas.Get().Select(v => new VagaModel(v));
            }
            else
            {
                return _uow.Vagas.Get(v => v.Criador.ID == usuarioID).Select(v => new VagaModel(v));
            }
        }

        public int ExpirarAnuncio(int Id, int usuarioID, bool EhAdmin)
        {
            Vaga vaga = _uow.Vagas.GetByID(Id);

            if (vaga == null) return -404;

            if (vaga.Criador.ID != usuarioID && !EhAdmin) return -401;

            if (vaga.DataExpiracao <= DateTime.Now)
            {
                return 0;
            }
            else
            {

                vaga.DataExpiracao = DateTime.Now;
                vaga.TipoVaga = vaga.TipoVaga;
                _uow.Vagas.Update(vaga);
                _uow.Save();

                return 0;
            }
        }

    }
}
