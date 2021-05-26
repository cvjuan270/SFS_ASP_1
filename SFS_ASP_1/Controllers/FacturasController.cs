using SFS_ASP_1.Controllers.GenDocEle;
using SFS_ASP_1.Model;
using SFS_ASP_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting.Processing;


namespace SFS_ASP_1.Controllers
{

    public class FacturasController : Controller
    {
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();

        // GET: Facturas
        public ActionResult Index()
        {
            List<DocumentosViewModel> documentos = new List<DocumentosViewModel>();

            ViewBag.FecIni = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.FecFin = DateTime.Now.ToString("yyyy-MM-dd");

            return View(documentos);

        }

        [method:HttpPost]
        public ActionResult Index(DateTime? FecIni, DateTime? FecFin, string Ruc, string RazSoc, int NumCor = 0)
        {
            var  atenciones = from cr in db.OINV select cr;
            if (String.IsNullOrEmpty(FecIni.ToString()) && String.IsNullOrEmpty(FecFin.ToString()))
            {
                atenciones = atenciones.Where(c => c.DocDate >= DateTime.Now && c.DocDate <= DateTime.Now);
            }

            if (!String.IsNullOrEmpty(FecIni.ToString()) && !String.IsNullOrEmpty(FecFin.ToString()))
            {
                atenciones = atenciones.Where(c => c.DocDate >= FecIni && c.DocDate <= FecFin);
            }

            if (!String.IsNullOrEmpty(Ruc))
            {
                atenciones = atenciones.Where(c => c.LicTradNum.Contains(Ruc));
            }
            if (!String.IsNullOrEmpty(RazSoc))
            {
                atenciones = atenciones.Where(c => c.CardName.Contains(RazSoc));
            }
            

            var Facturas = atenciones.ToList();
            List<DocumentosViewModel> facturas = (from fac in Facturas
                                               join ser in db.NNM1 on fac.Series equals ser.Series
                                               orderby fac.FolioNum ascending
                                               select new DocumentosViewModel { DocEntry = fac.DocEntry, DocDate = fac.DocDate, SeriesName = ser.SeriesName, FolioNum = fac.FolioNum,
                                                   LicTradNum = fac.LicTradNum, CardName = fac.CardName, GrosProfit = fac.GrosProfit, DocTotal = fac.DocTotal,
                                                   U_ResponseCode = fac.U_ResponseCode, U_Description = fac.U_Description, U_DigestValue = fac.U_DigestValue }).ToList();

            ViewBag.FecIni = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.FecFin = DateTime.Now.ToString("yyyy-MM-dd");
            return View(facturas);
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

        public ActionResult FacCreate(int Id)
        {
            CrearFT crearFT = new CrearFT(Id);

            string[] Respuesta = crearFT.respuestacdr;

            if (Respuesta[0].ToString()=="0")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, Respuesta[1]);
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
