using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musupr.Domain.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public Usuario() {
            this.qualidades = new HashSet<NivelQualificacao>();
            this.avaliacoes = new HashSet<Avaliacao>();        
        }

        public int ID { get; set; }

        [Required]
        public string UserID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required]
        public string Roles { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public int Idade { get { return DataNascimento != null ? (int)((DateTime.Now - DataNascimento.Value).TotalDays/365.2425) : 0; }  }

        public DateTime? DataNascimento { get; set;}
        public string Genero { get; set; }
        public string FacebookID { get; set; }
        public bool EmailVerificado { get; set; }
        public bool CadastradoPeloFacebook { get; set; }


        public virtual ICollection<NivelQualificacao> qualidades { get; set; }
        public virtual ICollection<Avaliacao> avaliacoes { get; set; }

        public virtual ICollection<Vaga> vagas { get; set; }

        public string Descricao { get; set; }
        public string DescricaoMarkdown { get; set; }
        public string HeaderImageUrl { get; set; }
        public string ProfileImageUrl { get; set; }
        public bool Bloqueado { get; set; }

        public string GuidVerificacao { get; set; }
        public string GuidTrocaSenha { get; set; }

    }
}