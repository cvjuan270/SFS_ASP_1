using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SFS_ASP_1.Models.Factura;
using SFS_ASP_1.Models;
using System.Data;
using Newtonsoft.Json;

namespace SFS_ASP_1.Controllers.GenDocEle
{
    public class CreaJsonFT
    {
        public RootFT rootFT = new RootFT();
        private static int DocEntry;
        public string JsonFT;
        public CreaJsonFT(int _DocEntry)
        {
            DocEntry = _DocEntry;
            SetCabeceraFT();
            SetAditionalCabeceraFT();
            SetListDetalleFT();
            SetLeyenda();
            SetTributo();
            SetPago();
            SetCuotas();
            SetJsonFT();
        }

        public void SetCabeceraFT()
        {
            using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC[dbo].[Consulta_SFS_CAB] @DocEntry = '{DocEntry}'"))
            {
                rootFT.cabecera.tipOperacion = dt.Rows[0].ItemArray[0].ToString();
                rootFT.cabecera.fecEmision = dt.Rows[0].ItemArray[1].ToString();
                rootFT.cabecera.horEmision = dt.Rows[0].ItemArray[2].ToString();
                rootFT.cabecera.fecVencimiento = dt.Rows[0].ItemArray[3].ToString();
                rootFT.cabecera.codLocalEmisor = dt.Rows[0].ItemArray[4].ToString();
                rootFT.cabecera.tipDocUsuario = dt.Rows[0].ItemArray[5].ToString();
                rootFT.cabecera.numDocUsuario = dt.Rows[0].ItemArray[6].ToString();
                rootFT.cabecera.rznSocialUsuario = dt.Rows[0].ItemArray[7].ToString();
                rootFT.cabecera.tipMoneda = dt.Rows[0].ItemArray[8].ToString();
                rootFT.cabecera.sumTotTributos = dt.Rows[0].ItemArray[9].ToString();
                rootFT.cabecera.sumTotValVenta = dt.Rows[0].ItemArray[10].ToString();
                rootFT.cabecera.sumPrecioVenta = dt.Rows[0].ItemArray[11].ToString();
                rootFT.cabecera.sumDescTotal = dt.Rows[0].ItemArray[12].ToString();
                rootFT.cabecera.sumOtrosCargos = dt.Rows[0].ItemArray[13].ToString();
                rootFT.cabecera.sumTotalAnticipos = dt.Rows[0].ItemArray[14].ToString();
                rootFT.cabecera.sumImpVenta = dt.Rows[0].ItemArray[15].ToString();
                rootFT.cabecera.ublVersionId = dt.Rows[0].ItemArray[16].ToString();
                rootFT.cabecera.customizationId = dt.Rows[0].ItemArray[17].ToString();
                //rootFT.cabecera.adicionalCabecera = SetAditionalCabecera.cabecera(DocEntry);
            }
        }

        public void SetAditionalCabeceraFT()
        {
            using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC  [dbo].[Consulta_SFS_ACA] @DocEntry = '{DocEntry}'"))
            {
                rootFT.adicionalCabecera.Add(
                    new AdicionalCabeceraFT
                    {
                        ctaBancoNacionDetraccion = dt.Rows[0].ItemArray[0].ToString(),
                        codBienDetraccion = dt.Rows[0].ItemArray[1].ToString(),
                        porDetraccion = dt.Rows[0].ItemArray[2].ToString(),
                        mtoDetraccion = dt.Rows[0].ItemArray[3].ToString(),
                        codMedioPago = dt.Rows[0].ItemArray[4].ToString(),
                        codPaisCliente = dt.Rows[0].ItemArray[5].ToString(),
                        codUbigeoCliente = dt.Rows[0].ItemArray[6].ToString(),
                        desDireccionCliente = dt.Rows[0].ItemArray[7].ToString(),
                        codPaisEntrega = dt.Rows[0].ItemArray[8].ToString(),
                        codUbigeoEntrega = dt.Rows[0].ItemArray[9].ToString(),
                        desDireccionEntrega = dt.Rows[0].ItemArray[10].ToString()

                    });
            }
        }

        public void SetListDetalleFT()
        {
            using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC [dbo].[Consulta_SFS_DET] @DocEntry = '{DocEntry}'"))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rootFT.detalle.Add(new DetalleFT
                    {
                        codUnidadMedida = dt.Rows[i].ItemArray[0].ToString(),
                        ctdUnidadItem = dt.Rows[i].ItemArray[1].ToString(),
                        codProducto = dt.Rows[i].ItemArray[2].ToString(),
                        codProductoSUNAT = dt.Rows[i].ItemArray[3].ToString(),
                        desItem = dt.Rows[i].ItemArray[4].ToString(),
                        mtoValorUnitario = dt.Rows[i].ItemArray[5].ToString(),
                        sumTotTributosItem = dt.Rows[i].ItemArray[6].ToString(),
                        codTriIGV = dt.Rows[i].ItemArray[7].ToString(),
                        mtoIgvItem = dt.Rows[i].ItemArray[8].ToString(),
                        mtoBaseIgvItem = dt.Rows[i].ItemArray[9].ToString(),
                        nomTributoIgvItem = dt.Rows[i].ItemArray[10].ToString(),
                        codTipTributoIgvItem = dt.Rows[i].ItemArray[11].ToString(),
                        tipAfeIGV = dt.Rows[i].ItemArray[12].ToString(),
                        porIgvItem = dt.Rows[i].ItemArray[13].ToString(),
                        codTriISC = dt.Rows[i].ItemArray[14].ToString(),
                        mtoIscItem = dt.Rows[i].ItemArray[15].ToString(),
                        mtoBaseIscItem = dt.Rows[i].ItemArray[16].ToString(),
                        nomTributoIscItem = dt.Rows[i].ItemArray[17].ToString(),
                        codTipTributoIscItem = dt.Rows[i].ItemArray[18].ToString(),
                        tipSisISC = dt.Rows[i].ItemArray[19].ToString(),
                        porIscItem = dt.Rows[i].ItemArray[20].ToString(),
                        codTriOtro = dt.Rows[i].ItemArray[21].ToString(),
                        mtoTriOtroItem = dt.Rows[i].ItemArray[22].ToString(),
                        mtoBaseTriOtroItem = dt.Rows[i].ItemArray[23].ToString(),
                        nomTributoOtroItem = dt.Rows[i].ItemArray[24].ToString(),
                        codTipTributoOtroItem = dt.Rows[i].ItemArray[25].ToString(),
                        porTriOtroItem = dt.Rows[i].ItemArray[26].ToString(),
                        codTriIcbper = dt.Rows[i].ItemArray[27].ToString(),
                        mtoTriIcbperItem = dt.Rows[i].ItemArray[28].ToString(),
                        ctdBolsasTriIcbperItem = dt.Rows[i].ItemArray[29].ToString(),
                        nomTributoIcbperItem = dt.Rows[i].ItemArray[30].ToString(),
                        codTipTributoIcbperItem = dt.Rows[i].ItemArray[31].ToString(),
                        mtoTriIcbperUnidad = dt.Rows[i].ItemArray[32].ToString(),
                        mtoPrecioVentaUnitario = dt.Rows[i].ItemArray[33].ToString(),
                        mtoValorVentaItem = dt.Rows[i].ItemArray[34].ToString(),
                        mtoValorReferencialUnitario = dt.Rows[i].ItemArray[35].ToString(),
                    });
                }
            }
        }

        private void SetLeyenda()
        {
            using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC [dbo].[Consulta_SFS_LEY] @DocEntry = '{DocEntry}'"))
            {
                rootFT.leyendas.Add(new LeyendaFT
                {
                    codLeyenda = dt.Rows[0].ItemArray[0].ToString(),
                    desLeyenda = dt.Rows[0].ItemArray[1].ToString()
                });
            }
        }

        private void SetTributo()
        {
            using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC  [dbo].[Consulta_SFS_TRY] @DocEntry = '{DocEntry}'"))
            {
                rootFT.tributos.Add(new TributoFT
                {
                    ideTributo = dt.Rows[0].ItemArray[0].ToString(),
                    nomTributo = dt.Rows[0].ItemArray[1].ToString(),
                    codTipTributo = dt.Rows[0].ItemArray[2].ToString(),
                    mtoBaseImponible = dt.Rows[0].ItemArray[3].ToString(),
                    mtoTributo = dt.Rows[0].ItemArray[4].ToString()
                });
            }
        }

        private void SetPago()
        {
            using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC [dbo].[Consulta_SFS_PAG] @DocEntry = {DocEntry}"))
            {
                rootFT.datoPago.formaPago = dt.Rows[0].ItemArray[0].ToString();
                rootFT.datoPago.mtoNetoPendientePago = dt.Rows[0].ItemArray[1].ToString();
                rootFT.datoPago.tipMonedaMtoNetoPendientePago = dt.Rows[0].ItemArray[2].ToString();
            }
        }
        private void SetCuotas()
        {
            if (rootFT.datoPago.formaPago == "Contado")
            {
                rootFT.detallePago = null;
            }

            else
            {
                using (DataTable dt = Conexion.Ejecutar_dt( $"EXEC [dbo].[Consulta_SFS_DPA] @DocEntry = {DocEntry}"))
                    rootFT.detallePago.Add(new detallePago
                    {
                        mtoCuotaPago = dt.Rows[0].ItemArray[0].ToString(),
                        fecCuotaPago = dt.Rows[0].ItemArray[1].ToString(),
                        tipMonedaCuotaPago = dt.Rows[0].ItemArray[2].ToString()
                    });
            }
        }

        private void SetJsonFT() 
        {
            JsonFT = JsonConvert.SerializeObject(rootFT,Formatting.Indented);
        }

       
       

    }
}