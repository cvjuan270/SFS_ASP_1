using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_ASP_1.Models.Factura
{
    public class Cabecera
    {
        public string tipOperacion { get; set; }
        public string fecEmision { get; set; }
        public string horEmision { get; set; }
        public string fecVencimiento { get; set; }
        public string codLocalEmisor { get; set; }
        public string tipDocUsuario { get; set; }
        public string numDocUsuario { get; set; }
        public string rznSocialUsuario { get; set; }
        public string tipMoneda { get; set; }
        public string sumTotTributos { get; set; }
        public string sumTotValVenta { get; set; }
        public string sumPrecioVenta { get; set; }
        public string sumDescTotal { get; set; }
        public string sumOtrosCargos { get; set; }
        public string sumTotalAnticipos { get; set; }
        public string sumImpVenta { get; set; }
        public string ublVersionId { get; set; }
        public string customizationId { get; set; }

        public AdicionalCabecera adicionalCabecera { get; set; }
    }
}
