using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SFS_ASP_1.Models;

namespace SFS_ASP_1.Controllers.GenDocEle
{
    public class CreaDE
    {
        public static DatosDE oDatosDE = new DatosDE();
        public static RootListaSFS rootListaSFS;
        public static string cmd, SFSRoot, SFSHttp, json;
        public static string[] respuestacdr;


        public static DatosDE _CreaDE(string oDocTyp, int oDocEnt)
        {
            Datos(oDocTyp, oDocEnt);

            switch (oDocTyp)
            {
                case "01":
                    json = "";
                    CreaJsonFT creaJsonFT = new CreaJsonFT(oDocEnt);
                    json = creaJsonFT.JsonFT;
                    break;
                case "07":
                    json = "";
                    json = new CrearJsonNC(oDocEnt).JsonNC;
                    break;
                case "09":
                    json = "";
                    json = new CrearJsonGR(oDocEnt).JsonGR;
                    break;

            }

            GuardaJson();

            GetPostBody();
            return oDatosDE;
        }

        public static void Datos(string DocTyp, int DocEnt)
        {

            switch (DocTyp)
            {
                case "01": /*FACTURA*/
                    cmd = (string.Format("EXEC[dbo].[Consulta_NombreFactura] @DocEntry = '{0}'", DocEnt));
                    break;
                case "07":/*NOTA DE CREDITO*/
                    cmd = (string.Format("EXEC[dbo].[Consulta_NombreNC] @DocEntry = '{0}'", DocEnt));
                    break;

                case "09":/*GUIA DE REMISION*/
                    cmd = (string.Format("EXEC[dbo].[Consulta_NombreGuia] @DocEntry = '{0}'", DocEnt));
                    break;
            }

            /*DATOS GENERALES*/
            using (DataTable dt = Conexion.Ejecutar_dt("EXEC [dbo].[Consulta_Datos_Generales]"))
            {
                oDatosDE.RucEmi = dt.Rows[0].ItemArray[0].ToString();
                oDatosDE.RazEmi = dt.Rows[0].ItemArray[1].ToString();
                oDatosDE.DirEmi = dt.Rows[0].ItemArray[2].ToString();
            }

            using (DataTable dt = Conexion.Ejecutar_dt(cmd))
            {
                oDatosDE.Serie = dt.Rows[0].ItemArray[2].ToString();
                oDatosDE.FolNum = dt.Rows[0].ItemArray[3].ToString();
                oDatosDE.DocTyp = DocTyp;
                oDatosDE.DocEnt = DocEnt.ToString();
            }

            /****RUTAS*******/
            /*validamos ruta SFS*/
            if (DocTyp == "09")
            {
                SFSRoot = "RutSerGR";
                SFSHttp = "RutHttpGR";
            }
            else
            {
                SFSRoot = "RutSerFT";
                SFSHttp = "RutHttpFT";
            }

            oDatosDE.RutDat = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["DATA"].ToString() + oDatosDE.RucEmi + "-" + oDatosDE.DocTyp + "-" + oDatosDE.Serie + "-" + oDatosDE.FolNum + ".json";
            oDatosDE.RutXml = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["FIRMA"].ToString() + oDatosDE.RucEmi + "-" + oDatosDE.DocTyp + "-" + oDatosDE.Serie + "-" + oDatosDE.FolNum + ".xml";
            oDatosDE.RutPdf = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["REPO"].ToString() + oDatosDE.RucEmi + "-" + oDatosDE.DocTyp + "-" + oDatosDE.Serie + "-" + oDatosDE.FolNum + ".pdf";
            oDatosDE.RutCdr = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["RPTA"].ToString() + "R" + oDatosDE.RucEmi + "-" + oDatosDE.DocTyp + "-" + oDatosDE.Serie + "-" + oDatosDE.FolNum + ".zip";
            oDatosDE.RuXmCd = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["RPTA"].ToString() + "R" + "-" + oDatosDE.RucEmi + "-" + oDatosDE.DocTyp + "-" + oDatosDE.Serie + "-" + oDatosDE.FolNum + ".xml";
            oDatosDE.RutRpt = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["RPTA"].ToString();
            oDatosDE.RutImg = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["IMG"].ToString();
            oDatosDE.RutLog = ConfigurationManager.AppSettings[SFSRoot].ToString() + ConfigurationManager.AppSettings["LOG"].ToString();
            oDatosDE.HttFir = ConfigurationManager.AppSettings[SFSHttp].ToString() + ConfigurationManager.AppSettings["HttpFirma"].ToString();
            oDatosDE.HttEnv = ConfigurationManager.AppSettings[SFSHttp].ToString() + ConfigurationManager.AppSettings["HttpEnvio"].ToString();
            oDatosDE.HttAct = ConfigurationManager.AppSettings[SFSHttp].ToString() + ConfigurationManager.AppSettings["HttpActualizar"].ToString();
        }
        public static void GetPostBody()
        {
            JsonDoc jsonDoc = new JsonDoc
            {
                num_ruc = oDatosDE.RucEmi,
                tip_docu = oDatosDE.DocTyp,
                num_docu = oDatosDE.Serie + "-" + oDatosDE.FolNum
            };

            oDatosDE.PosBod = JsonConvert.SerializeObject(jsonDoc);
        }
        public static void GuardaJson()
        {
            System.IO.File.WriteAllText(oDatosDE.RutDat, json);
            json = null;
        }
    }
}