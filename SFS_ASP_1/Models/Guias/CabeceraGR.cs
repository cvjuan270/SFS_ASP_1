using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_ASP_1.Models.Guias
{
    public class CabeceraGR
    {
        public string fecEmision { get; set; }
        public string horEmision { get; set; }
        public string tipDocGuia { get; set; }
        public string serNumDocGuia { get; set; }
        public string numDocDestinatario { get; set; }
        public string tipDocDestinatario { get; set; }
        public string rznSocialDestinatario { get; set; }
        public string motTrasladoDatosEnvio { get; set; }
        public string desMotivoTrasladoDatosEnvio { get; set; }
        public string indTransbordoProgDatosEnvio { get; set; }
        public string psoBrutoTotalBienesDatosEnvio { get; set; }
        public string uniMedidaPesoBrutoDatosEnvio { get; set; }
        public string numBultosDatosEnvio { get; set; }
        public string modTrasladoDatosEnvio { get; set; }
        public string fecInicioTrasladoDatosEnvio { get; set; }
        public string numDocTransportista { get; set; }
        public string tipDocTransportista { get; set; }
        public string nomTransportista { get; set; }
        public string numPlacaTransPrivado { get; set; }
        public string numDocIdeConductorTransPrivado { get; set; }
        public string tipDocIdeConductorTransPrivado { get; set; }
        public string nomConductorTransPrivado { get; set; }
        public string ubiLlegada { get; set; }
        public string dirLlegada { get; set; }
        public string ubiPartida { get; set; }
        public string dirPartida { get; set; }
        public string ublVersionId { get; set; }
        public string customizationId { get; set; }
    }
}
