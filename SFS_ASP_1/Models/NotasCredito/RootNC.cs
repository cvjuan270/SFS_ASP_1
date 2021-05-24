using SFS_ASP_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_ASP_1.Models.NotasCreadito
{
     public class RootNC
    {
        public CabeceraNC cabecera { get; set; }
        public List<Detalle> detalle { get; set; }
        public List<Leyenda> leyendas { get; set; }
        //public List<AdicionalDetalle> adicionalDetalle { get; set; }
        public List<Tributo> tributos { get; set; }
    }
}
