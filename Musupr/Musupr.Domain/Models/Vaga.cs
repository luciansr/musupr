using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musupr.Domain.Models
{
    [Table("Vagas")]
    public class Vaga
    {
        public Vaga()
        {
            this.qualidadesDesejadas = new HashSet<NivelQualificacao>();
            this.avaliacoes = new HashSet<Avaliacao>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        [Required]
        public DateTime DataExpiracao { get; set; }

        public int Salario { get; set; }

        //public int HorasPorSemana { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }


        [Required]
        public virtual Usuario Criador { get; set; }
        [Required]
        public virtual TipoVaga TipoVaga { get; set; }

        public virtual ICollection<NivelQualificacao> qualidadesDesejadas { get; set; }

        public virtual ICollection<Avaliacao> avaliacoes { get; set; }

        public bool Bloqueada { get; set; }
        public string DescricaoMarkdown { get; set; }

        public string ThumbnailUrl { get; set; }
        public string PostItemImageUrl { get; set; }
        public string HeaderImageUrl { get; set; }

    }
}