using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Musupr.Service;
using Musupr.Domain.Models;
using System.Collections.Generic;

namespace Musupr.Tests
{
    [TestClass]
    public class TestesJaccard
    {
        public JaccardService jaccardService = new JaccardService();
        Vaga vaga1 = new Vaga
        {
            ID = 1
        };

        Vaga vaga2 = new Vaga
        {
            ID = 2
        };

        Vaga vaga3 = new Vaga
        {
            ID = 3
        };


        [TestMethod]
        public void TestSimilaridade1()
        {
            Usuario usuario = new Usuario
            {
                avaliacoes = new List<Avaliacao> { 
                    new Avaliacao {
                        Gostou = true,
                        vaga = vaga1
                    }
                }
            };

            Usuario outro = new Usuario
            {
                avaliacoes = new List<Avaliacao> { 
                    new Avaliacao {
                        Gostou = true,
                        vaga = vaga1
                    }
                }
            };

            Assert.AreEqual(1.0, jaccardService.SimilaridadeDeUsuarioComOutroUsuario(usuario, outro));
        }

        [TestMethod]
        public void TestSimilaridade1Inverso()
        {
            Usuario usuario = new Usuario
            {
                avaliacoes = new List<Avaliacao> { 
                    new Avaliacao {
                        Gostou = true,
                        vaga = vaga1
                    }
                }
            };

            Usuario outro = new Usuario
            {
                avaliacoes = new List<Avaliacao> { 
                    new Avaliacao {
                        Gostou = false,
                        vaga = vaga1
                    }
                }
            };

            Assert.AreEqual(-1, jaccardService.SimilaridadeDeUsuarioComOutroUsuario(usuario, outro));
        }

        [TestMethod]
        public void TestSimilaridade2Inverso()
        {
            Usuario usuario = new Usuario
            {
                avaliacoes = new List<Avaliacao> { 
                    new Avaliacao {
                        Gostou = false,
                        vaga = vaga1
                    },
                    new Avaliacao {
                        Gostou = true,
                        vaga = vaga2
                    }
                }
            };

            Usuario outro = new Usuario
            {
                avaliacoes = new List<Avaliacao> { 
                    new Avaliacao {
                        Gostou = true,
                        vaga = vaga1
                    },
                    new Avaliacao {
                        Gostou = false,
                        vaga = vaga2
                    }
                }
            };

            Assert.AreEqual(-1, jaccardService.SimilaridadeDeUsuarioComOutroUsuario(usuario, outro));
        }
    }
}
