using SFS_ASP_1.Models.Factura;
using System.Collections.Generic;

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
