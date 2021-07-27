using System.Collections.Generic;

namespace SFS_ASP_1.Models.Factura
{
    public class RootFT
    {
        public Cabecera cabecera { get; set; }
        public  List<AdicionalCabecera> adicionalCabecera { get; set; }
        public List<Detalle> detalle { get; set; }
        public List<Leyenda> leyendas { get; set; }
        //public List<AdicionalDetalle> adicionalDetalle { get; set; }
        public List<Tributo> tributos { get; set; }
    }
}
