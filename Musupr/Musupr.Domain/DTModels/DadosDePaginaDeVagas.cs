using Musupr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musupr.Domain.DTModels
{
    public class DadosDePaginaDeVagas
    {
        public IEnumerable<VagaModel> vagasDaPagina { get; set; }
        public int paginaSelecionada { get; set; }
        public int numeroPaginas { get; set; }
    }
}
