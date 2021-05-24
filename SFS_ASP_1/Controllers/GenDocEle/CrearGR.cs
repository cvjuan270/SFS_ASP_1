using Newtonsoft.Json;
using RestSharp;
using SFS_ASP_1.Controllers.Helper;
using SFS_ASP_1.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SFS_ASP_1.Controllers.GenDocEle
{
    public class CrearGR
    {
        #region variables
        private static DataTable DTCabecera;
        public string[] respuestacdr = new string[2];
        public string RespuestaXml;
        private static string oRucEmi;
        //private static string oRazSocEmi;
        //private static string oDireccEmi;

        //private static string oLicTradNum;
        //private static string oCardName;
        //private static string oDocName;

        private static string oDocType;
        private static int oDocEntry;
        private static string oSerie;
        private static string oFolioNum;

        private static string RutaData;
        private static string RutaXml;
        private static string RutaPdf;
        private static string RutaCdr;
        private static string RutaRPTA;
        private static string RutaLog;
        private static string RutaXmlCdr;
        private static string RutaImg;
        private static string RutHttFirma;
        private static string RutHttEnvio;
        private static string RutHttpActualizar;
        #endregion

        public static void Datos(int DocEntry)
        {
            #region Emisor
            DataTable dtEmi = Conexion.Ejecutar_dt("EXEC [dbo].[Consulta_Datos_Generales]");
            oRucEmi = dtEmi.Rows[0].ItemArray[0].ToString();
            //oRazSocEmi = dtEmi.Rows[0].ItemArray[1].ToString();
            //oDireccEmi = dtEmi.Rows[0].ItemArray[2].ToString();
            #endregion

            DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC [dbo].[Consulta_NombreGuia] @DocEntry = '{0}'", DocEntry));
            //oLicTradNum = dt.Rows[0].ItemArray[0].ToString();
            //oCardName = dt.Rows[0].ItemArray[1].ToString();
            oSerie = dt.Rows[0].ItemArray[2].ToString();
            oFolioNum = dt.Rows[0].ItemArray[3].ToString();
            oDocType = "09";
            oDocEntry = DocEntry;
        }
        public static void Rutas()
        {
            RutaData = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["DATA"].ToString() + oRucEmi + "-" + oDocType + "-" + oSerie + "-" + oFolioNum + ".json";
            RutaXml = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["FIRMA"].ToString() + oRucEmi + "-" + oDocType + "-" + oSerie + "-" + oFolioNum + ".xml";
            RutaPdf = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["REPO"].ToString() + oRucEmi + "-" + oDocType + "-" + oSerie + "-" + oFolioNum + ".pdf";
            RutaCdr = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["RPTA"].ToString() + "R" + oRucEmi + "-" + oDocType + "-" + oSerie + "-" + oFolioNum + ".zip";
            RutaXmlCdr = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["RPTA"].ToString() + "R" + "-" + oRucEmi + "-" + oDocType + "-" + oSerie + "-" + oFolioNum + ".xml";
            RutaRPTA = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["RPTA"].ToString();
            RutaImg = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["IMG"].ToString();
            RutaLog = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["LOG"].ToString();
            RutHttFirma = ConfigurationManager.AppSettings["RutHttpGR"].ToString() + ConfigurationManager.AppSettings["HttpFirma"].ToString();
            RutHttEnvio = ConfigurationManager.AppSettings["RutHttpGR"].ToString() + ConfigurationManager.AppSettings["HttpEnvio"].ToString();
            RutHttpActualizar = ConfigurationManager.AppSettings["RutHttpGR"].ToString() + ConfigurationManager.AppSettings["HttpActualizar"].ToString();  
        }
        private static DataTable GetDTCabecera(int DocEntry)
        {
            DataTable dataTableReturn = null;
            string cmd = string.Format("EXEC [dbo].[Consulta_SFS_CAB_GR] @DocEntry = {0}", DocEntry);
            dataTableReturn = Conexion.Ejecutar_dt(cmd);
            return dataTableReturn;
        }
        private static DataTable GetDTDetalle(int DocEntry)
        {
            DataTable dataTableReturn = null;
            string cmd = string.Format("EXEC [dbo].[Consulta_SFS_DET_GR] @DocEntry = {0}", DocEntry);
            dataTableReturn = Conexion.Ejecutar_dt(cmd);
            return dataTableReturn;
        }
        private static List<DetalleGR> GetListDetalleGR(int DocEntry)
        {
            List<DetalleGR> detalleGRsReturn = new List<DetalleGR>();
            DataTable dt = GetDTDetalle(DocEntry);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DetalleGR det = new DetalleGR();
                det.uniMedidaItem = dt.Rows[i].ItemArray[0].ToString();
                det.canItem = dt.Rows[i].ItemArray[1].ToString();
                det.desItem = dt.Rows[i].ItemArray[2].ToString();
                det.codItem = dt.Rows[i].ItemArray[3].ToString();

                detalleGRsReturn.Add(det);
            }
            return detalleGRsReturn;
        }
        private static CabeceraGR GetCabeceraGR(int DocEntry)
        {
            DTCabecera = null;
            DTCabecera = GetDTCabecera(DocEntry);
            CabeceraGR cabeceraGR = new CabeceraGR();

            cabeceraGR.fecEmision = DTCabecera.Rows[0].ItemArray[0].ToString();
            cabeceraGR.horEmision = DTCabecera.Rows[0].ItemArray[1].ToString();
            cabeceraGR.tipDocGuia = DTCabecera.Rows[0].ItemArray[2].ToString();
            cabeceraGR.serNumDocGuia = DTCabecera.Rows[0].ItemArray[3].ToString();
            cabeceraGR.numDocDestinatario = DTCabecera.Rows[0].ItemArray[4].ToString();
            cabeceraGR.tipDocDestinatario = DTCabecera.Rows[0].ItemArray[5].ToString();
            cabeceraGR.rznSocialDestinatario = DTCabecera.Rows[0].ItemArray[6].ToString();
            cabeceraGR.motTrasladoDatosEnvio = DTCabecera.Rows[0].ItemArray[7].ToString();
            cabeceraGR.desMotivoTrasladoDatosEnvio = DTCabecera.Rows[0].ItemArray[8].ToString();
            cabeceraGR.indTransbordoProgDatosEnvio = DTCabecera.Rows[0].ItemArray[9].ToString();
            cabeceraGR.psoBrutoTotalBienesDatosEnvio = DTCabecera.Rows[0].ItemArray[10].ToString();
            cabeceraGR.uniMedidaPesoBrutoDatosEnvio = DTCabecera.Rows[0].ItemArray[11].ToString();
            cabeceraGR.numBultosDatosEnvio = DTCabecera.Rows[0].ItemArray[12].ToString();
            cabeceraGR.modTrasladoDatosEnvio = DTCabecera.Rows[0].ItemArray[13].ToString();
            cabeceraGR.fecInicioTrasladoDatosEnvio = DTCabecera.Rows[0].ItemArray[14].ToString();
            cabeceraGR.numDocTransportista = DTCabecera.Rows[0].ItemArray[15].ToString();
            cabeceraGR.tipDocTransportista = DTCabecera.Rows[0].ItemArray[16].ToString();
            cabeceraGR.nomTransportista = DTCabecera.Rows[0].ItemArray[17].ToString();
            cabeceraGR.numPlacaTransPrivado = DTCabecera.Rows[0].ItemArray[18].ToString();
            cabeceraGR.numDocIdeConductorTransPrivado = DTCabecera.Rows[0].ItemArray[19].ToString();
            cabeceraGR.tipDocIdeConductorTransPrivado = DTCabecera.Rows[0].ItemArray[20].ToString();
            cabeceraGR.nomConductorTransPrivado = DTCabecera.Rows[0].ItemArray[21].ToString();
            cabeceraGR.ubiLlegada = DTCabecera.Rows[0].ItemArray[22].ToString();
            cabeceraGR.dirLlegada = DTCabecera.Rows[0].ItemArray[23].ToString();
            cabeceraGR.ubiPartida = DTCabecera.Rows[0].ItemArray[24].ToString();
            cabeceraGR.dirPartida = DTCabecera.Rows[0].ItemArray[25].ToString();
            cabeceraGR.ublVersionId = DTCabecera.Rows[0].ItemArray[26].ToString();
            cabeceraGR.customizationId = DTCabecera.Rows[0].ItemArray[27].ToString();

            return cabeceraGR;
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
        public void GuardaJson(RootGR root)
        {
            string json = JsonConvert.SerializeObject(root, Formatting.Indented);
            File.WriteAllText(RutaData, json);
        }
        public static string CreaJsonDoc(string num_ruc, string tip_docu, string num_docu)
        {
            JsonDoc body = new JsonDoc();

            body.num_ruc = num_ruc;
            body.tip_docu = tip_docu;
            body.num_docu = num_docu;

            return JsonConvert.SerializeObject(body);
        }

        public async Task<IRestResponse> GetXmlAsync()
        {
            string oJson = CreaJsonDoc(oRucEmi, oDocType, oSerie + "-" + oFolioNum);

            var client = new RestClient(RutHttFirma);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json;chartset=utf-8");
            request.AddHeader("Token", "d9860b1f0ed6461036dfa5649652c08c");
            request.AddParameter("application/json;chartset=utf-8", oJson, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response;
        }

        public async Task<IRestResponse> GetCdrAsync()
        {
            string oJson = CreaJsonDoc(oRucEmi, oDocType, oSerie + "-" + oFolioNum);

            var client = new RestClient(RutHttEnvio);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json;chartset=utf-8");
            request.AddHeader("Token", "d9860b1f0ed6461036dfa5649652c08c");
            request.AddParameter("application/json;chartset=utf-8", oJson, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return response;
        }

        public async Task<IRestResponse> GetActualizaPantallaAsync()
        {
            var client = new RestClient(RutHttpActualizar);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json;chartset=utf-8");
            request.AddHeader("Token", "d9860b1f0ed6461036dfa5649652c08c");
            request.AddParameter("application/json;chartset=utf-8", "{\\\"txtSecuencia\\\":\\\"000\\\"}", ParameterType.RequestBody);
             IRestResponse response =  client.Execute(request);
            Console.WriteLine(response.Content);
            return response;
        }

        private void ActualiRptaCdt()
        {
            Conexion.EjecutarQuery(string.Format("EXEC [dbo].[Actualizar_Rpta_Cdr_GR]@Docentry = {0}, @U_ResponseCode = '{1}', @U_Description = '{2}',@U_DigestValue = '{3}'", oDocEntry, respuestacdr[0], respuestacdr[1], respuestacdr[2]));
        }

        private void ActualizarRptaFirma() 
        {
            Conexion.EjecutarQuery(string.Format("EXEC [dbo].[Actualizar_Rpta_Xml_GR]@Docentry = {0}, @U_DigestValue = '{1}'", oDocEntry, RespuestaXml));
        }

        public CrearGR(int DocEntry) 
        {
            var oLog = new Log(RutaLog);
            try
            {
                Datos(DocEntry);
                Rutas();

                var docjson = GetDocumentElectronicoGR(oDocEntry);
                GuardaJson(docjson);

                 GetActualizaPantallaAsync().Wait();
                 GetXmlAsync().Wait();

                if (System.IO.File.Exists(RutaXml))
                {
                    RespuestaXml = LeeCdr.GetXml(RutaXml);
                    ActualizarRptaFirma();

                    GetCdrAsync().Wait();

                    if (System.IO.File.Exists(RutaCdr))
                    {
                        respuestacdr = LeeCdr.GetCdr(RutaCdr, RutaXmlCdr,RutaRPTA);
                        ActualiRptaCdt();
                    }
                    else
                    {
                        respuestacdr[0] = "1";
                        respuestacdr[1] = "Rechazado por SUNAT y / ó Error al invocar el servicio de SUNAT.";
                        oLog.Add("Error: " + "DocType: " + oDocType + " - DocEntry: " + oDocEntry + " Exception" + respuestacdr);
                    }
                }
                else
                {
                    respuestacdr[0] = "1";
                    respuestacdr[1] = "Error al firmar archivo XML";
                    oLog.Add("Error: " + "DocType: " + oDocType + " - DocEntry: " + oDocEntry + " Exception" + respuestacdr);
                }
            }
            catch (Exception ex)
            {
                respuestacdr[0] = "100";
                respuestacdr[1] = ex.Message;
                throw;
            }
        }

    }
}