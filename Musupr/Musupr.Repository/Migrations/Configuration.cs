namespace Musupr.Repository.Migrations
{
    using Musupr.Domain.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<Musupr.Repository.MusuprContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Musupr.Repository.MusuprContext context)
        {
            context.TiposVaga.AddOrUpdate(
                p => p.Tipo,
                new TipoVaga { ID = 1, Nome = "Iniciação Científica", Tipo = "iniciacao" },
                new TipoVaga { ID = 2, Nome = "Estágio", Tipo = "estagio" },
                new TipoVaga { ID = 3, Nome = "Trainee", Tipo = "trainee" },
                new TipoVaga { ID = 4, Nome = "Outros", Tipo = "outros" }
            );
            context.SaveChanges();

            context.Usuarios.AddOrUpdate(
                p => p.UserID,
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "luciansr@gmail.com",
                    Nome = "Lucian",
                    Sobrenome = "Sturião",
                    UserID = "adminlucian",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("@dmin!lIc574")
                });

            context.SaveChanges();
            //seedOnDebug(context);
        }

        private void seedOnDebug(Musupr.Repository.MusuprContext context)
        {
            context.Qualificacoes.AddOrUpdate(
                q => q.Tipo,
                new Qualificacao { Nome = "jQuery", Tipo = "jquery" },
                new Qualificacao { Nome = "Javascript", Tipo = "javascript" },
                new Qualificacao { Nome = "C#", Tipo = "csharp" },
                new Qualificacao { Nome = ".CSS", Tipo = "css" },
                new Qualificacao { Nome = "Desenvolvimento Web", Tipo = "desenvolvimentoWeb" },
                new Qualificacao { Nome = "Lideranca", Tipo = "lideranca" },
                new Qualificacao { Nome = "Trabalho em Equipe", Tipo = "trabalhoEmEquipe" },
                new Qualificacao { Nome = "Experiência em Scrum", Tipo = "experienciaEmScrum" },
                new Qualificacao { Nome = "Métodos ágeis", Tipo = "metodosAgeis" },
                new Qualificacao { Nome = "Capacidade de aprender sem ajuda", Tipo = "serAutoDidata" },
                new Qualificacao { Nome = "Desenvolvimento desktop", Tipo = "desenvolvimentoDesktop" },
                new Qualificacao { Nome = "Mineração de dados", Tipo = "mineracaoDeDados" },
                new Qualificacao { Nome = "Aprendizado de máquina", Tipo = "aprendizadoDeMaquina" },
                new Qualificacao { Nome = "Mecânica dos fluidos", Tipo = "mecanicaDosFluidos" }
            );

            context.Usuarios.AddOrUpdate(
                p => p.UserID,
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "luciansr@gmail.com",
                    Nome = "Lucian",
                    Sobrenome = "Sturião",
                    UserID = "luciansr@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("admin2")
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianlsr@gmail.com",
                    Nome = "Lucian user",
                    Sobrenome = "Sturião",
                    UserID = "lucianlsr@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "user",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.7776315,
                    Longitude = -43.4024368
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianweb1@gmail.com",
                    Nome = "Lucian Web Mesquita",
                    Sobrenome = "Sturião",
                    UserID = "lucianweb1@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "user",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.7776315,
                    Longitude = -43.4024368
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianteorico1@gmail.com",
                    Nome = "Lucian Teorico Mesquita",
                    Sobrenome = "Sturião",
                    UserID = "lucianteorico1@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.7776315,
                    Longitude = -43.4024368
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianlider1@gmail.com",
                    Nome = "Lucian Lider Mesquita",
                    Sobrenome = "Sturião",
                    UserID = "lucianlider1@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.7776315,
                    Longitude = -43.4024368
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianweb2@gmail.com",
                    Nome = "Lucian Web Barra",
                    Sobrenome = "Sturião",
                    UserID = "lucianweb2@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.972768,
                    Longitude = -43.3721544
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianteorico2@gmail.com",
                    Nome = "Lucian Teorico Barra",
                    Sobrenome = "Sturião",
                    UserID = "lucianteorico2@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.972768,
                    Longitude = -43.3721544
                },
                new Usuario
                {
                    CadastradoPeloFacebook = false,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DateTime.Parse("11/03/1991"),
                    Email = "lucianlider2@gmail.com",
                    Nome = "Lucian Lider Barra",
                    Sobrenome = "Sturião",
                    UserID = "lucianlider2@gmail.com",
                    EmailVerificado = true,
                    Genero = "M",
                    Roles = "admin",
                    Senha = GetSHA512("admin2"),
                    Latitude = -22.972768,
                    Longitude = -43.3721544
                }
            );
            context.Save();

            context.NiveisQualificacao.AddOrUpdate(
                n => n.ID,
                //web
                new NivelQualificacao
                {
                    ID = 1,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "jquery"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 2,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "jquery"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 3,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "javascript"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 4,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "javascript"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 5,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "csharp"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 6,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "csharp"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 7,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "css"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 8,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "css"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianweb2@gmail.com")
                },
                //teorico
                new NivelQualificacao
                {
                    ID = 9,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "desenvolvimentoDesktop"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 10,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "desenvolvimentoDesktop"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 11,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mineracaoDeDados"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 12,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mineracaoDeDados"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 13,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "aprendizadoDeMaquina"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 14,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "aprendizadoDeMaquina"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 15,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mecanicaDosFluidos"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 16,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mecanicaDosFluidos"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianteorico2@gmail.com")
                },
                //lider                                                                                                   
                new NivelQualificacao
                {
                    ID = 17,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "lideranca"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 18,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "lideranca"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 19,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "trabalhoEmEquipe"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 20,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "trabalhoEmEquipe"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 21,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "experienciaEmScrum"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 22,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "experienciaEmScrum"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider2@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 23,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "metodosAgeis"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider1@gmail.com")
                },
                new NivelQualificacao
                {
                    ID = 24,
                    qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "metodosAgeis"),
                    Nivel = 80,
                    usuario = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlider2@gmail.com")
                }
            );

            context.SaveChanges();
            //    empresa4.Descricao = "bla bla";
            //    empresa4.Nome = "Stoneage4";
            //    empresa4.DataCriacao = DateTime.Now;
            //    empresa4.Owner = usuario;

            context.SaveChanges();

            context.Vagas.AddOrUpdate(
                p => p.ID,
                new Vaga
                {
                    ID = 1,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlsr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga desenvolvedor web, Mesquita. Salário: R$ 4.000,00",
                    Salario = 4000,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.TRAINEE),
                    Titulo = "Desenvolvedor web Mesquita",
                    Latitude = -22.7821614,
                    Longitude = -43.4273657
                },
                new Vaga
                {
                    ID = 2,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlsr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga desenvolvedor web, Barra. Salário: R$ 4.000,00",
                    Salario = 4000,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.TRAINEE),
                    Titulo = "Desenvolvedor web Barra",
                    Latitude = -22.982935,
                    Longitude = -43.3631533
                },
                new Vaga
                {
                    ID = 3,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlsr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga desenvolvedor web, Mesquita. Salário: R$ 2.500,00",
                    Salario = 2500,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.OUTRO),
                    Titulo = "Desenvolvedor web Mesquita",
                    Latitude = -22.7821614,
                    Longitude = -43.4273657
                },
                new Vaga
                {
                    ID = 4,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "lucianlsr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga desenvolvedor web, Barra. Salário: R$ 2.500,00",
                    Salario = 2500,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.TRAINEE),
                    Titulo = "Desenvolvedor web Barra",
                    Latitude = -22.982935,
                    Longitude = -43.3631533
                },
                new Vaga
                {
                    ID = 5,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga professor computação, Mesquita. Salário: R$ 4.000,00",
                    Salario = 4000,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.ESTAGIO),
                    Titulo = "Professor computação Mesquita",
                    Latitude = -22.7821614,
                    Longitude = -43.4273657
                },
                new Vaga
                {
                    ID = 6,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga professor computação, Barra. Salário: R$ 4.000,00",
                    Salario = 4000,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.OUTRO),
                    Titulo = "Professor computação Barra",
                    Latitude = -22.982935,
                    Longitude = -43.3631533
                },
                new Vaga
                {
                    ID = 7,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga professor computação, Mesquita. Salário: R$ 2.500,00",
                    Salario = 2500,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.INICIACAO),
                    Titulo = "Professor computação Mesquita",
                    Latitude = -22.7821614,
                    Longitude = -43.4273657
                },
                new Vaga
                {
                    ID = 8,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga professor computação, Barra. Salário: R$ 2.500,00",
                    Salario = 2500,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.ESTAGIO),
                    Titulo = "Professor computação Barra",
                    Latitude = -22.982935,
                    Longitude = -43.3631533
                },
                new Vaga
                {
                    ID = 9,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga Gerente, Mesquita. Salário: R$ 4.000,00",
                    Salario = 4000,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.ESTAGIO),
                    Titulo = "Gerente Mesquita",
                    Latitude = -22.7821614,
                    Longitude = -43.4273657
                },
                new Vaga
                {
                    ID = 10,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga Gerente, Barra. Salário: R$ 4.000,00",
                    Salario = 4000,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.INICIACAO),
                    Titulo = "Gerente Barra",
                    Latitude = -22.982935,
                    Longitude = -43.3631533
                },
                new Vaga
                {
                    ID = 11,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga Gerente, Mesquita. Salário: R$ 2.500,00",
                    Salario = 2500,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.INICIACAO),
                    Titulo = "Gerente Mesquita",
                    Latitude = -22.7821614,
                    Longitude = -43.4273657
                },
                new Vaga
                {
                    ID = 12,
                    Criador = context.Usuarios.FirstOrDefault(u => u.UserID == "luciansr@gmail.com"),
                    DataCriacao = DateTime.Now,
                    DataExpiracao = DateTime.Parse("21/12/2015 00:00"),
                    Descricao = "Vaga Gerente, Barra. Salário: R$ 2.500,00",
                    Salario = 2500,
                    TipoVaga = context.TiposVaga.FirstOrDefault(t => t.ID == (int)TipoVaga.TipoVagaEnum.OUTRO),
                    Titulo = "Gerente Barra",
                    Latitude = -22.982935,
                    Longitude = -43.3631533
                }
            );

            context.SaveChanges();

            context.NiveisQualificacao.AddOrUpdate(
               n => n.ID,
                //web
               new NivelQualificacao
               {
                   ID = 25,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "jquery"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 1)
               },
               new NivelQualificacao
               {
                   ID = 26,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "jquery"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 2)
               },
               new NivelQualificacao
               {
                   ID = 27,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "jquery"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 3)
               },
               new NivelQualificacao
               {
                   ID = 28,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "jquery"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 4)
               },
               new NivelQualificacao
               {
                   ID = 29,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "javascript"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 1)
               },
               new NivelQualificacao
               {
                   ID = 30,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "javascript"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 2)
               },
               new NivelQualificacao
               {
                   ID = 31,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "javascript"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 3)
               },
               new NivelQualificacao
               {
                   ID = 32,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "javascript"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 4)
               },
               new NivelQualificacao
               {
                   ID = 33,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "csharp"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 1)
               },
               new NivelQualificacao
               {
                   ID = 34,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "csharp"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 2)
               },
               new NivelQualificacao
               {
                   ID = 35,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "csharp"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 3)
               },
               new NivelQualificacao
               {
                   ID = 36,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "csharp"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 4)
               },
               new NivelQualificacao
               {
                   ID = 37,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "css"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 1)
               },
               new NivelQualificacao
               {
                   ID = 38,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "css"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 2)
               },
               new NivelQualificacao
               {
                   ID = 39,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "css"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 3)
               },
               new NivelQualificacao
               {
                   ID = 40,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "css"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 4)
               },
                //teorico
               new NivelQualificacao
               {
                   ID = 41,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "desenvolvimentoDesktop"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 5)
               },
               new NivelQualificacao
               {
                   ID = 42,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "desenvolvimentoDesktop"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 6)
               }, new NivelQualificacao
               {
                   ID = 43,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "desenvolvimentoDesktop"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 7)
               },
               new NivelQualificacao
               {
                   ID = 44,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "desenvolvimentoDesktop"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 8)
               },
               new NivelQualificacao
               {
                   ID = 45,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mineracaoDeDados"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 5)
               },
               new NivelQualificacao
               {
                   ID = 46,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mineracaoDeDados"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 6)
               },
               new NivelQualificacao
               {
                   ID = 47,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mineracaoDeDados"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 7)
               },
               new NivelQualificacao
               {
                   ID = 48,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mineracaoDeDados"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 8)
               },
               new NivelQualificacao
               {
                   ID = 49,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "aprendizadoDeMaquina"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 5)
               },
               new NivelQualificacao
               {
                   ID = 50,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "aprendizadoDeMaquina"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 6)
               },
               new NivelQualificacao
               {
                   ID = 51,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "aprendizadoDeMaquina"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 7)
               },
               new NivelQualificacao
               {
                   ID = 52,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "aprendizadoDeMaquina"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 8)
               },
               new NivelQualificacao
               {
                   ID = 53,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mecanicaDosFluidos"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 5)
               },
               new NivelQualificacao
               {
                   ID = 54,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mecanicaDosFluidos"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 6)
               },
               new NivelQualificacao
               {
                   ID = 55,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mecanicaDosFluidos"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 7)
               },
               new NivelQualificacao
               {
                   ID = 56,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "mecanicaDosFluidos"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 8)
               },
                //lider                                                                                                   
               new NivelQualificacao
               {
                   ID = 57,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "lideranca"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 9)
               },
               new NivelQualificacao
               {
                   ID = 58,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "lideranca"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 10)
               },
               new NivelQualificacao
               {
                   ID = 59,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "lideranca"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 11)
               },
               new NivelQualificacao
               {
                   ID = 60,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "lideranca"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 12)
               },
               new NivelQualificacao
               {
                   ID = 61,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "trabalhoEmEquipe"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 9)
               },
               new NivelQualificacao
               {
                   ID = 62,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "trabalhoEmEquipe"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 10)
               },
               new NivelQualificacao
               {
                   ID = 63,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "trabalhoEmEquipe"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 11)
               },
               new NivelQualificacao
               {
                   ID = 64,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "trabalhoEmEquipe"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 12)
               },
               new NivelQualificacao
               {
                   ID = 65,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "experienciaEmScrum"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 9)
               },
               new NivelQualificacao
               {
                   ID = 66,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "experienciaEmScrum"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 10)
               },
               new NivelQualificacao
               {
                   ID = 67,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "experienciaEmScrum"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 11)
               },
               new NivelQualificacao
               {
                   ID = 68,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "experienciaEmScrum"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 12)
               },
               new NivelQualificacao
               {
                   ID = 69,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "metodosAgeis"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 9)
               },
               new NivelQualificacao
               {
                   ID = 70,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "metodosAgeis"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 10)
               },
               new NivelQualificacao
               {
                   ID = 71,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "metodosAgeis"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 11)
               },
               new NivelQualificacao
               {
                   ID = 72,
                   qualificacao = context.Qualificacoes.FirstOrDefault(q => q.Tipo == "metodosAgeis"),
                   Nivel = 80,
                   vaga = context.Vagas.FirstOrDefault(v => v.ID == 12)
               }
           );
        }

        private static string GetSHA512(string text)
        {
            ASCIIEncoding UE = new ASCIIEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            SHA512Managed hashString = new SHA512Managed();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
