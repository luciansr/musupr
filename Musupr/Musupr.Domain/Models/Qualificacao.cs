using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musupr.Domain.Models
{
    [Table("Qualificacoes")]
    public class Qualificacao
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Index("Index_Tipo", 1, IsUnique=true), MaxLengthAttribute(128)]
        public string Tipo { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
