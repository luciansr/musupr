using Musupr.Domain.Models;
using Musupr.Repository;
using Musupr.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musupr.Service
{
    public class RecommendationService
    {
        GoogleAPIService googleApi;

        public RecommendationService(GoogleAPIService _googleApi)
        {
            googleApi = _googleApi;
        }

        public List<Vaga> OrdenaVagasPorRecomendacao(Usuario usuario, List<Vaga> listaVagas)
        {
            List<Tuple<Vaga, double, double>> listaRetornoVagas = new List<Tuple<Vaga, double, double>>();

            foreach (Vaga vaga in listaVagas)
            {
                double requisitosAtendidos = CalculaPercentagemDeRequisitosAtendidos(usuario, vaga);
                double distanciaUsuarioVaga = CalculaDistanciaEntreUsuarioEVaga(usuario, vaga);

                listaRetornoVagas.Add(Tuple.Create(vaga, requisitosAtendidos, distanciaUsuarioVaga));
            }

            listaRetornoVagas.Sort(new ComparadorVaga());

            return listaRetornoVagas.Select(t => t.Item1).ToList();
        }

        public double CalculaPercentagemDeRequisitosAtendidos(Usuario usuario, Vaga vaga)
        {
            double pontosTotais = 0, pontosFeitos = 0;

            foreach (NivelQualificacao qualificacaoVaga in vaga.qualidadesDesejadas)
            {
                NivelQualificacao qualificacaoUsuario = usuario.qualidades.FirstOrDefault(n => n.qualificacao.Tipo == qualificacaoVaga.qualificacao.Tipo);

                pontosTotais += qualificacaoVaga.Nivel;

                if (qualificacaoUsuario != null)
                {
                    double aproveitamento = (double)qualificacaoUsuario.Nivel / qualificacaoVaga.Nivel;

                    if (aproveitamento > 1)
                    {
                        pontosFeitos += qualificacaoVaga.Nivel + (qualificacaoUsuario.Nivel - qualificacaoVaga.Nivel) * 0.05;
                    }
                    else if (aproveitamento == 1)
                    {
                        pontosFeitos += qualificacaoVaga.Nivel;
                    }
                    else if (aproveitamento < 1)
                    {
                        pontosFeitos += qualificacaoUsuario.Nivel; // * aproveitamento;
                    }

                }

            }

            return pontosFeitos / pontosTotais;
        }

        public double CalculaDistanciaEntreUsuarioEVaga(Usuario usuario, Vaga vaga) 
        {
            if (usuario.Latitude != 0.0 &&
                usuario.Longitude != 0.0 &&
                vaga.Latitude != 0.0 &&
                vaga.Longitude != 0.0) 
            {
                return googleApi.CalculaDistanciaEntreDoisPontos(usuario.Latitude, usuario.Longitude, vaga.Latitude, vaga.Longitude);            
            }

            return 0.0;
        }
    }
}
