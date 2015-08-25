using System;
using System.Collections.Generic;
using System.Linq;
using Musupr.Domain.Models;
using Musupr.Repository;
using Musupr.Domain.DTModels;
using Musupr.Service.Helpers;
using System.Collections;

namespace Musupr.Service
{
    public class JaccardService
    {
        public class PontuacaoVaga
        {
            public Vaga vaga { get; set; }
            public double predicaoAvaliacao { get; set; }
        }

        public IEnumerable<PontuacaoVaga> OrdenaVagasPorCoeficienteDeJaccard(IEnumerable<Vaga> vagas, Usuario usuario)
        {
            List<PontuacaoVaga> listaPontuacaoVaga = new List<PontuacaoVaga>();

            foreach (Vaga vaga in vagas)
            {
                listaPontuacaoVaga.Add(new PontuacaoVaga
                {
                    vaga = vaga,
                    predicaoAvaliacao = PredicaoDeVaga(usuario, vaga)
                });
            }

            //TO DO
            return listaPontuacaoVaga.OrderByDescending(v => v.predicaoAvaliacao);
        }

        public double SimilaridadeDeUsuarioComOutroUsuario(Usuario usuario, Usuario outro)
        {
            double acordos = 0.0;
            double desacordos = 0.0;

            double totalAvaliacoes = 0.0;

            HashSet<Avaliacao> outrasAvaliacoes = (outro.avaliacoes as HashSet<Avaliacao>);

            Dictionary<int, Avaliacao> dic = new Dictionary<int, Avaliacao>();

            foreach (Avaliacao avaliacao in outrasAvaliacoes)
            {
                dic.Add(avaliacao.vaga.ID, avaliacao);
            }

            foreach (Avaliacao avaliacao in usuario.avaliacoes)
            {
                Avaliacao outra;

                if (dic.TryGetValue(avaliacao.vaga.ID, out outra))
                {
                    dic.Remove(avaliacao.vaga.ID);

                    if (avaliacao.Gostou == outra.Gostou)
                    {
                        ++acordos;
                    }
                    else
                    {
                        ++desacordos;
                    }

                    outrasAvaliacoes.Remove(outra);
                }
            }

            totalAvaliacoes = usuario.avaliacoes.Count + outrasAvaliacoes.Count;

            return (acordos - desacordos) / totalAvaliacoes;
        }

        public double PredicaoDeVaga(Usuario usuario, Vaga vaga)
        {
            double pontuacao = 0.0;

            double avaliadaPor = 0.0;

            bool alreadyFound = false;

            foreach (Avaliacao avaliacao in vaga.avaliacoes)
            {

                if (alreadyFound || avaliacao.usuario.ID != usuario.ID)
                {
                    ++avaliadaPor;

                    double pontosSimilaridade = SimilaridadeDeUsuarioComOutroUsuario(usuario, avaliacao.usuario);

                    if (avaliacao.Gostou)
                    {
                        pontuacao += pontosSimilaridade;
                    }
                    else
                    {
                        pontuacao -= pontosSimilaridade;
                    }
                }
                else
                {
                    alreadyFound = true;
                }
            }

            return pontuacao / avaliadaPor;
        }


    }
}
