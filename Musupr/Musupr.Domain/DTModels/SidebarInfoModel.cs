using Musupr.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Musupr.Domain.DTModels
{
    public class SidebarInfoModel
    {
        public class TipoVagaCounter {
            public TipoVaga tipo { get; set; }
            public int quantidade { get; set; }
        }

        public IEnumerable<string> tags { get; set; }
        public IEnumerable<VagaModel> ultimasOportunidades { get; set; }
        public List<TipoVagaCounter> tipoVagaCounter { get; set; }
    }
}
