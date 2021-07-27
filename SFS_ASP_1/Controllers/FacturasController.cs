using SFS_ASP_1.Controllers.GenDocEle;
using SFS_ASP_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting.Processing;


namespace SFS_ASP_1.Controllers
{

    public class FacturasController : Controller
    {
        
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();

        private static DateTime FecAct = DateTime.Now.Date;
        private static DateTime PriDia = new DateTime(FecAct.Year, FecAct.Month, 1);
        private  static DateTime  UltDia = PriDia.AddMonths(1).AddDays(-1);
        private static string Error, Success;

        public  IQueryable<DocumentosViewModel> queryable() 
        {
            IQueryable<DocumentosViewModel> query = (from ft in db.OINV
                                                     join ser in db.NNM1 on ft.Series equals ser.Series
                                                     orderby ft.FolioNum ascending
                                                     select new DocumentosViewModel
                                                     {
                                                         DocEntry = ft.DocEntry,
                                                         DocDate = ft.DocDate,
                                                         SeriesName = ser.SeriesName,
                                                         FolioNum = ft.FolioNum,
                                                         LicTradNum = ft.LicTradNum,
                                                         CardName = ft.CardName,
                                                         GrosProfit = ft.GrosProfit,
                                                         DocTotal = ft.DocTotal,
                                                         U_ResponseCode = ft.U_ResponseCode,
                                                         U_Description = ft.U_Description,
                                                         U_DigestValue = ft.U_DigestValue,
                                                         InvntStatus = ft.InvntSttus

                                                     });
            return query;
        }

        // GET: Facturas
        public ActionResult Index()
        {
            
            ViewBag.FecIni =PriDia.ToString("yyyy-MM-dd");
            ViewBag.FecFin = UltDia.ToString("yyyy-MM-dd");
            ViewBag.Error = Error;
            ViewBag.Success = Success;

            var query = queryable();
            query = query.Where(d => d.DocDate >= PriDia && d.DocDate <=UltDia);

            return View(query.ToList()); ;
        }

        [method:HttpPost]
        public ActionResult Index(DateTime? FecIni, DateTime? FecFin, string Ruc, string RazSoc, int FolioNum = 0)
        {
            ViewBag.FecIni = PriDia.ToString("yyyy-MM-dd");
            ViewBag.FecFin = UltDia.ToString("yyyy-MM-dd");
            var query = queryable();

            if (FolioNum != 0)
            {
                query = query.Where(c => c.FolioNum == FolioNum);
            }
            else
            {
                if (String.IsNullOrEmpty(FecIni.ToString()) && String.IsNullOrEmpty(FecFin.ToString()))
                {
                    query = query.Where(c => c.DocDate >= PriDia && c.DocDate <= UltDia);
                }

                if (!String.IsNullOrEmpty(FecIni.ToString()) && !String.IsNullOrEmpty(FecFin.ToString()))
                {
                    query = query.Where(c => c.DocDate >= FecIni && c.DocDate <= FecFin);
                }

                if (!String.IsNullOrEmpty(Ruc))
                {
                    query = query.Where(c => c.LicTradNum.Contains(Ruc));
                }
                if (!String.IsNullOrEmpty(RazSoc))
                {
                    query = query.Where(c => c.CardName.Contains(RazSoc));
                }
            }

            return View(query.ToList());
        }

        // GET: Facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OINV oINV = db.OINV.Find(id);
            if (oINV == null)
            {
                return HttpNotFound();
            }
            return View(oINV);
        }

        public async Task<ActionResult> FacCreate(int Id)
        {
            
            var datos= CreaDE._CreaDE("01", Id);

            var Respuesta =  await FirmaDE.PostFirmaXml(datos);
            await FirmaDE.PostEnvioXml(datos);

            if (Respuesta[0] == "02" || Respuesta[0]=="03"|| Respuesta[0] == "04"|| Respuesta[0] == "11"|| Respuesta[0] == "12")
            {
                Success = Respuesta[0] + "|" + Respuesta[1];
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, Respuesta[0]+"|"+ Respuesta[1]);
            }
        }

        public ActionResult GenReport( int Id) 
        {
            DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC  [dbo].[Consulta_Datos_Reporte_FT] @DocEntry = '{0}'", Id));
            if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[9].ToString()))
            {
                string RutImg = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["IMG"].ToString() + "Logo.png";

                Reportes.Report_FT_A4 reportToExport = new Reportes.Report_FT_A4(dt, RutImg);
                ReportProcessor reportProcessor = new ReportProcessor();
                Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                instanceReportSource.ReportDocument = reportToExport;
                RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

                string fileName = dt.Rows[0].ItemArray[0].ToString() + "-01-" + dt.Rows[0].ItemArray[10].ToString() + "." + result.Extension;
                string RutPdf = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["REPO"].ToString() + fileName;
                Response.Clear();
                Response.ContentType = result.MimeType;
                Response.Cache.SetCacheability(HttpCacheability.Private);
                Response.Expires = -1;
                Response.Buffer = true;

                Response.AddHeader("Content-Disposition",
                                   string.Format("{0};FileName=\"{1}\"",
                                                 "attachment",
                                                 fileName));
                Response.BinaryWrite(result.DocumentBytes);
                if (!System.IO.File.Exists(RutPdf))
                {
                    System.IO.File.WriteAllBytes(RutPdf, result.DocumentBytes);
                }
                Response.End();

                ViewBag.Confirmacion = "PDF generado";
                return File(result.DocumentBytes, "application/pdf");

            }
            ViewBag.Error = "Factura sin Firma digital";

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Documento electronico sin firma Digital");
        }
        public ActionResult MailCreate(int Id) 
        {

            return RedirectToAction("create","Emails",new {Id = Id,oDocType = "01"});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
