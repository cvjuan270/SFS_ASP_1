using SFS_ASP_1.Models.Guias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace SFS_ASP_1.Controllers.GenDocEle
{
    public class CrearJsonGR
    {
        private static CabeceraGR cabeceraGR = new CabeceraGR();
        private static List<DetalleGR> detalleGRsReturn = new List<DetalleGR>();
        public string JsonGR;

        public CrearJsonGR(int DocEnt) 
        {
            RootGR rootGR = GetDocumentElectronicoGR(DocEnt);
            JsonGR = JsonConvert.SerializeObject(rootGR, Formatting.Indented);
        }
        public static RootGR GetDocumentElectronicoGR(int DocEntry)
        {
            RootGR root = new RootGR
            {
                cabecera = GetCabeceraGR(DocEntry),
                detalle = GetListDetalleGR(DocEntry)
            };
            return root;
        }

        private static CabeceraGR GetCabeceraGR(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC [dbo].[Consulta_SFS_CAB_GR] @DocEntry = {0}", DocEntry)))
            {
                cabeceraGR.fecEmision = dt.Rows[0].ItemArray[0].ToString();
                cabeceraGR.horEmision = dt.Rows[0].ItemArray[1].ToString();
                cabeceraGR.tipDocGuia = dt.Rows[0].ItemArray[2].ToString();
                cabeceraGR.serNumDocGuia = dt.Rows[0].ItemArray[3].ToString();
                cabeceraGR.numDocDestinatario = dt.Rows[0].ItemArray[4].ToString();
                cabeceraGR.tipDocDestinatario = dt.Rows[0].ItemArray[5].ToString();
                cabeceraGR.rznSocialDestinatario = dt.Rows[0].ItemArray[6].ToString();
                cabeceraGR.motTrasladoDatosEnvio = dt.Rows[0].ItemArray[7].ToString();
                cabeceraGR.desMotivoTrasladoDatosEnvio = dt.Rows[0].ItemArray[8].ToString();
                cabeceraGR.indTransbordoProgDatosEnvio = dt.Rows[0].ItemArray[9].ToString();
                cabeceraGR.psoBrutoTotalBienesDatosEnvio = dt.Rows[0].ItemArray[10].ToString();
                cabeceraGR.uniMedidaPesoBrutoDatosEnvio = dt.Rows[0].ItemArray[11].ToString();
                cabeceraGR.numBultosDatosEnvio = dt.Rows[0].ItemArray[12].ToString();
                cabeceraGR.modTrasladoDatosEnvio = dt.Rows[0].ItemArray[13].ToString();
                cabeceraGR.fecInicioTrasladoDatosEnvio = dt.Rows[0].ItemArray[14].ToString();
                cabeceraGR.numDocTransportista = dt.Rows[0].ItemArray[15].ToString();
                cabeceraGR.tipDocTransportista = dt.Rows[0].ItemArray[16].ToString();
                cabeceraGR.nomTransportista = dt.Rows[0].ItemArray[17].ToString();
                cabeceraGR.numPlacaTransPrivado = dt.Rows[0].ItemArray[18].ToString();
                cabeceraGR.numDocIdeConductorTransPrivado = dt.Rows[0].ItemArray[19].ToString();
                cabeceraGR.tipDocIdeConductorTransPrivado = dt.Rows[0].ItemArray[20].ToString();
                cabeceraGR.nomConductorTransPrivado = dt.Rows[0].ItemArray[21].ToString();
                cabeceraGR.ubiLlegada = dt.Rows[0].ItemArray[22].ToString();
                cabeceraGR.dirLlegada = dt.Rows[0].ItemArray[23].ToString();
                cabeceraGR.ubiPartida = dt.Rows[0].ItemArray[24].ToString();
                cabeceraGR.dirPartida = dt.Rows[0].ItemArray[25].ToString();
                cabeceraGR.ublVersionId = dt.Rows[0].ItemArray[26].ToString();
                cabeceraGR.customizationId = dt.Rows[0].ItemArray[27].ToString();
            }
            return cabeceraGR;
        }
        private static List<DetalleGR> GetListDetalleGR(int DocEntry)
        {
            using (DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC [dbo].[Consulta_SFS_DET_GR] @DocEntry = {0}", DocEntry)))
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DetalleGR det = new DetalleGR();
                    det.uniMedidaItem = dt.Rows[i].ItemArray[0].ToString();
                    det.canItem = dt.Rows[i].ItemArray[1].ToString();
                    det.desItem = dt.Rows[i].ItemArray[2].ToString();
                    det.codItem = dt.Rows[i].ItemArray[3].ToString();

                    detalleGRsReturn.Add(det);
                }
            }
            return detalleGRsReturn;
        }

        
    }
}