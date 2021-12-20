using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFS_ASP_1.Models.Factura
{
    public class RootFT
    {
        public CabeceraFT cabecera { get; set; }
        public List<AdicionalCabeceraFT> adicionalCabecera { get; set; }
        public List<DetalleFT> detalle { get; set; }
        public List<LeyendaFT> leyendas { get; set; }
        public List<TributoFT> tributos { get; set; }
        public datoPago datoPago { get; set; }
        public List<detallePago> detallePago { get; set; }

        public RootFT()
        {
            this.cabecera = new CabeceraFT();
            this.adicionalCabecera = new List<AdicionalCabeceraFT>();
            this.detalle = new List<DetalleFT>();
            this.leyendas = new List<LeyendaFT>();
            this.tributos = new List<TributoFT>();
            this.datoPago = new datoPago();
            this.detallePago = new List<detallePago>();
        }
    }

    public class CabeceraFT
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

        public AdicionalCabeceraFT adicionalCabecera { get; set; }
    }

    public class DetalleFT
    {
        public string codUnidadMedida { get; set; }
        public string ctdUnidadItem { get; set; }
        public string codProducto { get; set; }
        public string codProductoSUNAT { get; set; }
        public string desItem { get; set; }
        public string mtoValorUnitario { get; set; }
        public string sumTotTributosItem { get; set; }
        public string codTriIGV { get; set; }
        public string mtoIgvItem { get; set; }
        public string mtoBaseIgvItem { get; set; }
        public string nomTributoIgvItem { get; set; }
        public string codTipTributoIgvItem { get; set; }
        public string tipAfeIGV { get; set; }
        public string porIgvItem { get; set; }
        public string codTriISC { get; set; }
        public string mtoIscItem { get; set; }
        public string mtoBaseIscItem { get; set; }
        public string nomTributoIscItem { get; set; }
        public string codTipTributoIscItem { get; set; }
        public string tipSisISC { get; set; }
        public string porIscItem { get; set; }

        //
        public string codTriOtro { get; set; }
        public string mtoTriOtroItem { get; set; }
        public string mtoBaseTriOtroItem { get; set; }
        public string nomTributoOtroItem { get; set; }
        public string codTipTributoOtroItem { get; set; }
        public string porTriOtroItem { get; set; }
        public string codTriIcbper { get; set; }
        public string mtoTriIcbperItem { get; set; }
        public string ctdBolsasTriIcbperItem { get; set; }
        public string nomTributoIcbperItem { get; set; }
        public string codTipTributoIcbperItem { get; set; }
        public string mtoTriIcbperUnidad { get; set; }

        //
        public string mtoPrecioVentaUnitario { get; set; }
        public string mtoValorVentaItem { get; set; }
        public string mtoValorReferencialUnitario { get; set; }
    }

    public class LeyendaFT
    {
        public string codLeyenda { get; set; }
        public string desLeyenda { get; set; }
    }

    public class TributoFT
    {
        public string ideTributo { get; set; }
        public string nomTributo { get; set; }
        public string codTipTributo { get; set; }
        public string mtoBaseImponible { get; set; }
        public string mtoTributo { get; set; }
    }

    public class AdicionalCabeceraFT
    {
        public string ctaBancoNacionDetraccion { get; set; }
        public string codBienDetraccion { get; set; }
        public string porDetraccion { get; set; }
        public string mtoDetraccion { get; set; }
        public string codMedioPago { get; set; }
        public string codPaisCliente { get; set; }
        public string codUbigeoCliente { get; set; }
        public string desDireccionCliente { get; set; }
        public string codPaisEntrega { get; set; }
        public string codUbigeoEntrega { get; set; }
        public string desDireccionEntrega { get; set; }
    }

    public class datoPago
    {
        public string formaPago { get; set; }
        public string mtoNetoPendientePago { get; set; }
        public string tipMonedaMtoNetoPendientePago { get; set; }
    }

    public class detallePago
    {
        public string mtoCuotaPago { get; set; }
        public string fecCuotaPago { get; set; }
        public string tipMonedaCuotaPago { get; set; }
    }
}