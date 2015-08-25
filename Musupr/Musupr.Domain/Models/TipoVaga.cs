using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Musupr.Domain.Models
{
     [Table("TipoVaga")]
    public class TipoVaga
    {
        public enum TipoVagaEnum { INICIACAO = 1, ESTAGIO = 2, TRAINEE = 3, OUTRO = 4 }

        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Tipo { get; set; }

    }
}
