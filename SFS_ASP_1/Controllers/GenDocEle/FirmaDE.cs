using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using RestSharp;
using SFS_ASP_1.Models;

namespace SFS_ASP_1.Controllers.GenDocEle
{
    public class FirmaDE
    {
        public static async Task<RootListaSFS> ActualizaBAndejaAsync(string url) 
        {
            RootListaSFS rootListaSFS = new RootListaSFS();

            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json;chartset=utf-8");
            request.AddHeader("Token", "d9860b1f0ed6461036dfa5649652c08c");
            var body = @"";
            request.AddParameter("application/json;chartset=utf-8", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful)
            {
                var result = response.Content;
                rootListaSFS = JsonConvert.DeserializeObject<RootListaSFS>(result);
                return rootListaSFS;
            }
            else
            {
                return rootListaSFS = null;
            }
        }

        public static async Task<string[]> PostFirmaXml(DatosDE datosDE) 
        {
            string[] returResponse = new string[2];
            RootListaSFS rootListaSFS = new RootListaSFS();

            await ActualizaBAndejaAsync(datosDE.HttAct);
 
            if (!System.IO.File.Exists(datosDE.RutXml))
            {
                try
                {
                    string url = datosDE.HttFir;
                    string PostBod = datosDE.PosBod;
                    var client = new HttpClient();

                    HttpContent content = new StringContent(PostBod, System.Text.Encoding.UTF8, "application/json");

                    var httpresponse = await client.PostAsync(url, content);
                    if (httpresponse.IsSuccessStatusCode)
                    {
                        var result = await httpresponse.Content.ReadAsStringAsync();

                        rootListaSFS = JsonConvert.DeserializeObject<RootListaSFS>(result);

                        var document = rootListaSFS.ListaBandejaFacturador.Find(m => m.NomArch == datosDE.RucEmi + "-" + datosDE.DocTyp + "-" + datosDE.Serie + "-" + datosDE.FolNum);
                        returResponse[0] = document.IndSitu;
                        returResponse[1] = document.DesObse;

                        /*lee y guarda digestvalue*/
                        if (File.Exists(datosDE.RutXml))
                        {
                            string digesvalue = GetXml(datosDE.RutXml);
                            ActualizarRptaFirma(int.Parse(datosDE.DocEnt), digesvalue);
                        }

                        return returResponse;
                    }
                    else
                    {

                        returResponse[0] = "0000";
                        returResponse[1] = "Error se solicitud POST";

                        return returResponse;
                    }
                }
                catch (Exception ex)
                {
                    returResponse[0] = ex.Message;
                    returResponse[1] = ex.InnerException.Message;
                    return returResponse;
                }
            }
            else
            {
                returResponse[0] = "02";
                returResponse[1] = "Xml ya esta generado";
                return returResponse;
            }
            
        }

        public static async Task<string[]> PostEnvioXml(DatosDE datosDE)
        {
            await ActualizaBAndejaAsync(datosDE.HttAct);
            string[] returResponse = new string[2];
            RootListaSFS rootListaSFS = new RootListaSFS();
            try
            {
                if (System.IO.File.Exists(datosDE.RutXml))
                {
                  
                        string url = datosDE.HttEnv;
                        string PostBod = datosDE.PosBod;
                        var client = new HttpClient();

                        HttpContent content = new StringContent(PostBod, System.Text.Encoding.UTF8, "application/json");

                        var httpresponse = await client.PostAsync(url, content);
                        if (httpresponse.IsSuccessStatusCode)
                        {
                            var result = await httpresponse.Content.ReadAsStringAsync();

                            rootListaSFS = JsonConvert.DeserializeObject<RootListaSFS>(result);

                            var document = rootListaSFS.ListaBandejaFacturador.Find(m => m.NomArch == datosDE.RucEmi + "-" + datosDE.DocTyp + "-" + datosDE.Serie + "-" + datosDE.FolNum);

                             Thread.Sleep(4000);
                            /*lee y guarda respuesta CDR*/
                            if (File.Exists(datosDE.RutRpt))
                            {
                                string[] respuestaCDR = new string[3];
                                respuestaCDR = GetCdr(datosDE.RutCdr, datosDE.RuXmCd, datosDE.RutRpt);
                                ActualiRptaCdt(int.Parse(datosDE.DocEnt), respuestaCDR);
                            }
                        returResponse[0] = document.IndSitu;
                        returResponse[1] = document.DesObse;
                        return returResponse;
                        }
                        else
                        {
                            returResponse[0] = "0000";
                            returResponse[1] = "Error se solicitud POST";
                            return returResponse;
                        }
                }
                else
                {
                    returResponse[0] = "000";
                    returResponse[1] = "DE sin firmar";
                    return returResponse;
                }
            }
            catch (Exception ex)
            {

                returResponse[0] = ex.Message;
                returResponse[1] = ex.InnerException.Message;
                return returResponse;
            }
        }

        public static void ActualiRptaCdt(int oDocEntry,string[] respuestacdr)
        {
            Conexion.EjecutarQuery(string.Format("EXEC [dbo].[Actualizar_Rpta_Cdr]@Docentry = {0}, @U_ResponseCode = '{1}', @U_Description = '{2}',@U_DigestValue='{3}'", oDocEntry, respuestacdr[0], respuestacdr[1], respuestacdr[2]));
        }

        public static void ActualizarRptaFirma(int oDocEntry,string RespuestaXml)
        {
            Conexion.EjecutarQuery(string.Format("EXEC [dbo].[Actualizar_Rpta_Xml]@Docentry = {0}, @U_DigestValue = '{1}'", oDocEntry, RespuestaXml));
        }

        public static  string[] GetCdr(string oRutCdrZip, string oRutCdrxml, string oRutRPTA)
        {

            string[] ReturnCdr = new string[3];

            if (!File.Exists(oRutCdrxml))
            {
                ZipFile.ExtractToDirectory(oRutCdrZip, oRutRPTA);
            }

            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(oRutCdrxml);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("cbc:ResponseCode");
            XmlNodeList elemList1 = doc.GetElementsByTagName("cbc:Description");
            XmlNodeList elemList2 = doc.GetElementsByTagName("DigestValue");
            ReturnCdr[0] = elemList[0].InnerXml;
            ReturnCdr[1] = elemList1[0].InnerXml;
            ReturnCdr[2] = elemList2[0].InnerXml;
            return ReturnCdr;
        }
        public static string GetXml(string oRutXml)
        {
            string ReturnCdr;
            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(oRutXml);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName("ds:DigestValue");
            ReturnCdr = elemList[0].InnerXml;
            return ReturnCdr;
        }

    }
}