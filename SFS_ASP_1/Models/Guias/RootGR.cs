using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_ASP_1.Models.Guias
{
    public class RootGR
    {
        public CabeceraGR cabecera { get; set; }
        public List<DetalleGR> detalle { get; set; }
    }
}
