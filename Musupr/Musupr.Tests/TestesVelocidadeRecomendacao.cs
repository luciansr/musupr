using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Musupr.Domain.Models;
using Musupr.Service;
using System.Linq;

namespace Musupr.Tests
{
    [TestClass]
    public class TestesVelocidadeRecomendacao
    {
        JaccardService jaccardService = new JaccardService();

        [TestMethod]
        public void TesteVelocidade10()
        {
            Random gen = new Random();
            int number = 10;

            HashSet<Vaga> vagas = new HashSet<Vaga>();
            HashSet<Usuario> usuarios = new HashSet<Usuario>();

            for (int i = 1; i <= number; ++i)
            {
                vagas.Add(new Vaga
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });

                usuarios.Add(new Usuario
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });
            }

            int j = 0;

            foreach (Usuario usuario in usuarios)
            {
                foreach (Vaga vaga in vagas)
                {
                    Avaliacao tempAvaliacao = new Avaliacao {
                        usuario = usuario,
                        vaga = vaga,
                        ID = ++j,
                        Gostou = gen.Next(100) > 49
                    };

                    usuario.avaliacoes.Add(tempAvaliacao);
                    vaga.avaliacoes.Add(tempAvaliacao);
                }
            }

            jaccardService.OrdenaVagasPorCoeficienteDeJaccard(vagas, usuarios.FirstOrDefault());
        }

        [TestMethod]
        public void TesteVelocidade100()
        {
            Random gen = new Random();
            int number = 100;

            List<Vaga> vagas = new List<Vaga>();
            List<Usuario> usuarios = new List<Usuario>();

            for (int i = 1; i <= number; ++i)
            {
                vagas.Add(new Vaga
                {
                    ID = i,
                    avaliacoes = new List<Avaliacao>()
                });

                usuarios.Add(new Usuario
                {
                    ID = i,
                    avaliacoes = new List<Avaliacao>()
                });
            }

            int j = 0;

            foreach (Usuario usuario in usuarios)
            {
                foreach (Vaga vaga in vagas)
                {
                    Avaliacao tempAvaliacao = new Avaliacao
                    {
                        usuario = usuario,
                        vaga = vaga,
                        ID = ++j,
                        Gostou = gen.Next(100) > 49
                    };

                    usuario.avaliacoes.Add(tempAvaliacao);
                    vaga.avaliacoes.Add(tempAvaliacao);
                }
            }
            jaccardService.OrdenaVagasPorCoeficienteDeJaccard(vagas, usuarios[0]);
        }

        [TestMethod]
        public void TesteVelocidade200()
        {
            Random gen = new Random();
            int number = 200;

            HashSet<Vaga> vagas = new HashSet<Vaga>();
            HashSet<Usuario> usuarios = new HashSet<Usuario>();

            for (int i = 1; i <= number; ++i)
            {
                vagas.Add(new Vaga
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });

                usuarios.Add(new Usuario
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });
            }

            int j = 0;

            foreach (Usuario usuario in usuarios)
            {
                foreach (Vaga vaga in vagas)
                {
                    Avaliacao tempAvaliacao = new Avaliacao
                    {
                        usuario = usuario,
                        vaga = vaga,
                        ID = ++j,
                        Gostou = gen.Next(100) > 49
                    };

                    usuario.avaliacoes.Add(tempAvaliacao);
                    vaga.avaliacoes.Add(tempAvaliacao);
                }
            }
            jaccardService.OrdenaVagasPorCoeficienteDeJaccard(vagas, usuarios.FirstOrDefault());
        }

        [TestMethod]
        public void TesteVelocidade500()
        {
            Random gen = new Random();
            int number = 500;

            HashSet<Vaga> vagas = new HashSet<Vaga>();
            HashSet<Usuario> usuarios = new HashSet<Usuario>();

            for (int i = 1; i <= number; ++i)
            {
                vagas.Add(new Vaga
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });

                usuarios.Add(new Usuario
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });
            }

            int j = 0;

            foreach (Usuario usuario in usuarios)
            {
                foreach (Vaga vaga in vagas)
                {
                    Avaliacao tempAvaliacao = new Avaliacao
                    {
                        usuario = usuario,
                        vaga = vaga,
                        ID = ++j,
                        Gostou = gen.Next(100) > 49
                    };

                    usuario.avaliacoes.Add(tempAvaliacao);
                    vaga.avaliacoes.Add(tempAvaliacao);
                }
            }

            jaccardService.OrdenaVagasPorCoeficienteDeJaccard(vagas, usuarios.FirstOrDefault());
        }

        [TestMethod]
        public void TesteVelocidade1000()
        {
            Random gen = new Random();
            int number = 1000;

            HashSet<Vaga> vagas = new HashSet<Vaga>();
            HashSet<Usuario> usuarios = new HashSet<Usuario>();

            for (int i = 1; i <= number; ++i)
            {
                vagas.Add(new Vaga
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });

                usuarios.Add(new Usuario
                {
                    ID = i,
                    avaliacoes = new HashSet<Avaliacao>()
                });
            }

            int j = 0;

            foreach (Usuario usuario in usuarios)
            {
                foreach (Vaga vaga in vagas)
                {
                    Avaliacao tempAvaliacao = new Avaliacao
                    {
                        usuario = usuario,
                        vaga = vaga,
                        ID = ++j,
                        Gostou = gen.Next(100) > 49
                    };

                    usuario.avaliacoes.Add(tempAvaliacao);
                    vaga.avaliacoes.Add(tempAvaliacao);
                }
            }

            jaccardService.OrdenaVagasPorCoeficienteDeJaccard(vagas, usuarios.FirstOrDefault());
        }
    }
}
