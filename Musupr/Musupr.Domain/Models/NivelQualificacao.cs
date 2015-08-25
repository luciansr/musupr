using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musupr.Domain.Models
{
    [Table("NivelQualificacoes")]
    public class NivelQualificacao
    {
        public int ID { get; set; }

        [Required]
        public virtual Qualificacao qualificacao { get; set; }

        [Required]
        public int Nivel { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Vaga vaga { get; set; }
    }
}
