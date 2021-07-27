using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_ASP_1.Models.Factura
{
    public class Detalle
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
}
