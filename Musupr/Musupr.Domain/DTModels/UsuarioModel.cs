using Musupr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musupr.Domain.DTModels
{
    public class UsuarioModel
    {
        public UsuarioModel() { }
        public UsuarioModel(Usuario usuario)
        {
            this.ID = usuario.ID;
            this.UserID = usuario.UserID;
            this.Email = usuario.Email;
            this.Nome = usuario.Nome;
            this.Sobrenome = usuario.Sobrenome;
            this.Roles = usuario.Roles;
            this.Latitude = usuario.Latitude;
            this.Longitude = usuario.Longitude;
            this.DataCriacao = usuario.DataCriacao;
            this.DataNascimento = usuario.DataNascimento;
            this.Genero = usuario.Genero;
            this.FacebookID = usuario.FacebookID;
            this.EmailVerificado = usuario.EmailVerificado;
            this.CadastradoPeloFacebook = usuario.CadastradoPeloFacebook;
            this.Descricao = usuario.Descricao;
            this.DescricaoMarkdown = usuario.DescricaoMarkdown;
            this.HeaderImageUrl = usuario.HeaderImageUrl;
            this.ProfileImageUrl = usuario.ProfileImageUrl;
            this.Bloqueado = usuario.Bloqueado;
            this.EhAdmin = usuario.Roles.Contains("admin");
        }
        public bool EhAdmin { get; set; }
        public int ID { get; set; }
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Roles { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataCriacao { get; set; }
        public int Idade { get { return DataNascimento != null ? (int)((DateTime.Now - DataNascimento.Value).TotalDays / 365.2425) : 0; } }
        public DateTime? DataNascimento { get; set; }
        public string Genero { get; set; }
        public string FacebookID { get; set; }
        public bool EmailVerificado { get; set; }
        public bool CadastradoPeloFacebook { get; set; }
        public bool PodeSerEditado { get; set; }

        public string Descricao { get; set; }
        public string DescricaoMarkdown { get; set; }
        public string HeaderImageUrl { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool Bloqueado { get; set; }
    }
}