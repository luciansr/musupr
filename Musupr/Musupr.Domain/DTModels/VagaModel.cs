using Musupr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musupr.Domain.DTModels
{
    public class VagaModel
    {
        public VagaModel() { }

        public VagaModel(Vaga vaga)
        {
            this.ID = vaga.ID;
            this.Titulo = vaga.Titulo;
            this.Descricao = vaga.Descricao;
            this.DescricaoMarkdown = vaga.DescricaoMarkdown;
            this.DataCriacao = vaga.DataCriacao;
            this.DataExpiracao = vaga.DataExpiracao;
            this.Salario = vaga.Salario;
            //this.HorasPorSemana = vaga.HorasPorSemana;
            this.Latitude = vaga.Latitude;
            this.Longitude = vaga.Longitude;
            this.CriadorNome = vaga.Criador.Nome;
            this.CriadorID = vaga.Criador.ID;
            this.TipoVagaID = vaga.TipoVaga.ID;
            this.ThumbnailUrl = vaga.ThumbnailUrl;
            this.PostItemImageUrl = vaga.PostItemImageUrl;
            this.HeaderImageUrl = vaga.HeaderImageUrl;
            this.Bloqueada = vaga.Bloqueada;
            this.CriadorBloqueado = vaga.Criador.Bloqueado;
            this.DeAdmin = vaga.Criador.Roles.Contains("admin");
        }
        public bool DeAdmin { get; set; }
        public int TempoExpiracao { get; set; }
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public int Salario { get; set; }
        public string DescricaoMarkdown { get; set; }
        //public int HorasPorSemana { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string ThumbnailUrl { get; set; }
        public string PostItemImageUrl { get; set; }
        public string HeaderImageUrl { get; set; }

        public bool? Like { get; set; }

        public string CriadorNome { get; set; }
        public bool CriadorBloqueado { get; set; }
        public int TipoVagaID { get; set; }
        public int CriadorID { get; set; }
        public bool Bloqueada { get; set; }
    }
}