using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musupr.Domain.Models
{
    [Table("Avaliacoes")]
    public class Avaliacao
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public virtual Usuario usuario { get; set; }
        [Required]
        public virtual Vaga vaga { get; set; }
        [Required]
        public bool Gostou { get; set; }
    }
}
