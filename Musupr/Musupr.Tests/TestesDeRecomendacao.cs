using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Musupr.Service;
using Musupr.Infrastructure;
using Musupr.Domain.Models;
using System.Collections.Generic;
using Musupr.Service.Helpers;

namespace Musupr.Tests
{
    [TestClass]
    public class TestesDeRecomendacao
    {
        private Qualificacao jQuery = new Qualificacao { Nome = "jQuery", Tipo = "jquery" };
        private Qualificacao javascript = new Qualificacao { Nome = "Javascript", Tipo = "javascript" };
        private Qualificacao CSharp = new Qualificacao { Nome = "C#", Tipo = "csharp" };
        private Qualificacao CSS = new Qualificacao { Nome = ".CSS", Tipo = "css" };
        private Qualificacao Lideranca = new Qualificacao { Nome = "Lideranca", Tipo = "lideranca" };
        private Qualificacao TrabalhoEmEquipe = new Qualificacao { Nome = "Trabalho em Equipe", Tipo = "trabalhoEmEquipe" };
        private Qualificacao SerAutoDidata = new Qualificacao { Nome = "Capacidade de aprender sem ajuda", Tipo = "serAutoDidata" };

        #region TestesPorcentagem
        [TestMethod]
        public void TestPorcentagem75Porcento()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 100 },
                }
            };

            Vaga vaga = new Vaga
            {
                Titulo = "Vaga2",
                Salario = 2100,
                qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 100 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 100 },
                }
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            Assert.AreEqual(rService.CalculaPercentagemDeRequisitosAtendidos(usuario, vaga), 0.75);
        }

        [TestMethod]
        public void TestPorcentagem100Porcento()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 100 },
                }
            };

            Vaga vaga = new Vaga
            {
                Titulo = "Vaga2",
                Salario = 2100,
                qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 100 },
                }
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            Assert.AreEqual(rService.CalculaPercentagemDeRequisitosAtendidos(usuario, vaga), 1);
        }

        [TestMethod]
        public void TestPorcentagem100PorcentoUsuarioComMaisAtributos()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 100 },
                }
            };

            Vaga vaga = new Vaga
            {
                Titulo = "Vaga2",
                Salario = 2100,
                qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                }
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            Assert.AreEqual(rService.CalculaPercentagemDeRequisitosAtendidos(usuario, vaga), 1);
        }

        [TestMethod]
        public void TestPorcentagem0Porcento()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao>
                {
                }
            };

            Vaga vaga = new Vaga
            {
                Titulo = "Vaga2",
                Salario = 2100,
                qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 100 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 100 },
                }
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            Assert.AreEqual(rService.CalculaPercentagemDeRequisitosAtendidos(usuario, vaga), 0);
        }
        #endregion

        [TestMethod]
        public void TestBasico()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 90 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 95 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 70 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 60 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 50 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga3", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 80 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 60 },
                }},
                new Vaga { Titulo = "Vaga1", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 50 },
                }},
                new Vaga { Titulo = "Vaga2", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = CSS, Nivel = 70 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 60 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 80 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 80 },
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[2].Titulo == "Vaga3", "Esperada vaga3, vaga retornada = " + listaVagasRecomendadas[2].Titulo);
        }

        [TestMethod]
        public void TestUmaSoQualidade()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 85 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 75 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga2", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 }
                }},
                new Vaga { Titulo = "Vaga3", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 80 }
                }},
                new Vaga { Titulo = "Vaga1", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 80 }
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[2].Titulo == "Vaga3", "Esperada vaga3, vaga retornada = " + listaVagasRecomendadas[2].Titulo);
        }

        [TestMethod]
        public void TestUmaSoQualidade2()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 80 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 80 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga1", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = javascript, Nivel = 75 }
                }},
                new Vaga { Titulo = "Vaga3", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 85 }
                }},
                new Vaga { Titulo = "Vaga2", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 81 }
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[2].Titulo == "Vaga3", "Esperada vaga3, vaga retornada = " + listaVagasRecomendadas[2].Titulo);
        }

        [TestMethod]
        public void TestQualidadesMistas()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 90 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 95 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 95 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 30 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 60 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 80 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga1", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 50 },
                }},
                new Vaga { Titulo = "Vaga2", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 70 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 80 }
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
        }

        [TestMethod]
        public void TestQualidadesMistasInverso()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 35 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 45 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 40 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 95 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 80 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 85 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga2", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 50 },
                }},
                new Vaga { Titulo = "Vaga1", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 70 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 80 }
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
        }

        [TestMethod]
        public void TestVagasQuaseIdenticas()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 30 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 40 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 30 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 30 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 80 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 60 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga2", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 33 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 42 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 31 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 25 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 83 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 85 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 61 }
                }},
                new Vaga { Titulo = "Vaga1", qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 30 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 40 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 30 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 30 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 80 },
                    new NivelQualificacao { qualificacao = TrabalhoEmEquipe, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 60 }
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
        }

        [TestMethod]
        public void TestComSalarioVagasIguaisSalarioMaior()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 90 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 95 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 70 },
                    new NivelQualificacao { qualificacao = CSS, Nivel = 60 },
                    new NivelQualificacao { qualificacao = Lideranca, Nivel = 50 }
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga2", Salario = 2100, qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 50 },
                }},
                new Vaga { Titulo = "Vaga1", Salario = 2500, qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 50 },
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
        }

        [TestMethod]
        public void TestSalarioERequisitosLigeiramenteDiferentes()
        {
            Usuario usuario = new Usuario
            {
                qualidades = new List<NivelQualificacao> { 
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                }
            };

            List<Vaga> listaVagasInicial = new List<Vaga> { 
                new Vaga { Titulo = "Vaga2", Salario = 2100, qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 70 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 80 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 50 },
                }},
                new Vaga { Titulo = "Vaga1", Salario = 2500, qualidadesDesejadas = new List<NivelQualificacao> {
                    new NivelQualificacao { qualificacao = jQuery, Nivel = 80 },
                    new NivelQualificacao { qualificacao = javascript, Nivel = 90 },
                    new NivelQualificacao { qualificacao = CSharp, Nivel = 90 },
                    new NivelQualificacao { qualificacao = SerAutoDidata, Nivel = 50 },
                }}
            };

            RecommendationService rService = Factory.Instance.Get<RecommendationService>();

            List<Vaga> listaVagasRecomendadas = rService.OrdenaVagasPorRecomendacao(usuario, listaVagasInicial);
            Assert.IsTrue(listaVagasRecomendadas != null);
            Assert.IsTrue(listaVagasRecomendadas[0].Titulo == "Vaga1", "Esperada vaga1, vaga retornada = " + listaVagasRecomendadas[0].Titulo);
            Assert.IsTrue(listaVagasRecomendadas[1].Titulo == "Vaga2", "Esperada vaga2, vaga retornada = " + listaVagasRecomendadas[1].Titulo);
        }

        [TestMethod]
        public void TestComparacaoBasica()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2100
            }, 0.80, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 2100
            }, 0.80, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();

            Assert.IsTrue(comparador.Compare(vaga1, vaga2) == 0);
        }

        [TestMethod]
        public void TestBasicoComparacaoVaga1MelhorQueVaga2()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2200
            }, 0.80, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 2100
            }, 0.80, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result);
        }

        [TestMethod]
        public void TestBasicoComparacaoVaga2MelhorQueVaga1()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2200
            }, 0.80, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 2220
            }, 0.80, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result > 0, "Esperado > 0, retornado: " + result);
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioPequenaRequisitos()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3100
            }, 0.70, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 2100
            }, 0.90, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaPequenaSalarioPequenaRequisitos()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.85, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3100
            }, 0.80, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 4000
            }, 0.60, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos2()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 5000
            }, 0.60, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 2000
            }, 0.90, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos3()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.65, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 1500
            }, 0.90, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }


        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos3Contrario()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 1500
            }, 0.90, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.65, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result > 0, "Esperado > 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos4()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 5000
            }, 0.60, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 1500
            }, 0.90, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos2Inverso()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2000
            }, 0.90, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 5000
            }, 0.50, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos2Inverso2()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 5000
            }, 0.90, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 7000
            }, 0.50, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoVagaDiferencaGrandeSalarioGrandeRequisitos2Inverso3()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 1200
            }, 0.90, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.50, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 20.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 30.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia2()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2500
            }, 0.60, 12.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 30.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia3()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2800
            }, 0.50, 10.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 30.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia4()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 2500
            }, 0.90, 45.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 30.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia5()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 40.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 20.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia5Contrario()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.60, 20.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 40.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result > 0, "Esperado > 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia6()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.75, 20.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 40.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia6Contrario()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 40.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.75, 20.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result > 0, "Esperado > 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoComSalarioEDistancia7()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 4500
            }, 0.70, 50.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 20.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestComparacaoBasicoDistanciaZerada()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 4500
            }, 0.70, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.90, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }

        [TestMethod]
        public void TestTudoZeradoMenosSalario()
        {
            Tuple<Vaga, double, double> vaga1 =
            Tuple.Create(new Vaga
            {
                Salario = 4500
            }, 0.0, 0.0);

            Tuple<Vaga, double, double> vaga2 =
            Tuple.Create(new Vaga
            {
                Salario = 3000
            }, 0.0, 0.0);

            ComparadorVaga comparador = new ComparadorVaga();
            double result = comparador.Compare(vaga1, vaga2);

            Assert.IsTrue(result < 0, "Esperado < 0, retornado: " + result); //vaga 1 melhor que vaga 2 é o esperado
        }
    }
}
