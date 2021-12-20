using SFS_ASP_1.Models.Factura;
using System.Collections.Generic;

namespace SFS_ASP_1.Models.NotasCreadito
{
    public class RootNC
    {
        public CabeceraNC cabecera { get; set; }
        public List<DetalleFT> detalle { get; set; }
        public List<LeyendaFT> leyendas { get; set; }
        //public List<AdicionalDetalle> adicionalDetalle { get; set; }
        public List<TributoFT> tributos { get; set; }
    }
}
