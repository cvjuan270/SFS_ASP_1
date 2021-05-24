using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFS_ASP_1.Controllers.GenDocEle;
using SFS_ASP_1.Models;
using Telerik.Reporting.Processing;

namespace SFS_ASP_1.Controllers
{
    public class GuiasController : Controller
    {
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();


        // GET: Guias
        [OutputCache(Duration = 180)]
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

            var guias = from gr in db.ODLN select gr;

            if (String.IsNullOrEmpty(FecIni.ToString()) && String.IsNullOrEmpty(FecFin.ToString()))
            {
                guias = guias.Where(c => c.DocDate >= DateTime.Now && c.DocDate <= DateTime.Now);
            }

            if (!String.IsNullOrEmpty(FecIni.ToString()) && !String.IsNullOrEmpty(FecFin.ToString()))
            {
                
                guias = guias.Where(c => c.DocDate >= FecIni && c.DocDate <= FecFin);
            }

            if (!String.IsNullOrEmpty(Ruc))
            {
                guias = guias.Where(c => c.LicTradNum.Contains(Ruc));
            }
            if (!String.IsNullOrEmpty(RazSoc))
            {
                guias = guias.Where(c => c.CardName.Contains(RazSoc));
            }

            var oGuias = guias.ToList();
            List<DocumentosViewModel> Guias = (from fac in oGuias
                                               join ser in db.NNM1 on fac.Series equals ser.Series
                                               orderby fac.FolioNum ascending
                                               select new DocumentosViewModel
                                               {
                                                   DocEntry = fac.DocEntry,
                                                   DocDate = fac.DocDate,
                                                   SeriesName = ser.SeriesName,
                                                   FolioNum = fac.FolioNum,
                                                   LicTradNum = fac.LicTradNum,
                                                   CardName = fac.CardName,
                                                   GrosProfit = fac.GrosProfit,
                                                   DocTotal = fac.DocTotal,
                                                   U_ResponseCode = fac.U_ResponseCode,
                                                   U_Description = fac.U_Description,
                                                   U_DigestValue = fac.U_DigestValue
                                               }).ToList();
            ViewBag.FecIni = DateTime.Now.ToString("yyyy-MM-dd");
            ViewBag.FecFin = DateTime.Now.ToString("yyyy-MM-dd");
            return View(Guias);
        }

        public List<DocumentosViewModel> Filtrar( DateTime? FecIni) 
        {
            List<DocumentosViewModel> Guias = new List<DocumentosViewModel>();

            var guias = from gr in db.ODLN select gr;

            if (!String.IsNullOrEmpty(FecIni.ToString()))
            {
                guias = guias.Where(c => c.DocDate== FecIni);

                var oGuias = guias.ToList();
                        Guias = (from fac in oGuias
                                                   join ser in db.NNM1 on fac.Series equals ser.Series
                                                   orderby fac.FolioNum ascending
                                                   select new DocumentosViewModel
                                                   {
                                                       DocEntry = fac.DocEntry,
                                                       DocDate = fac.DocDate,
                                                       SeriesName = ser.SeriesName,
                                                       FolioNum = fac.FolioNum,
                                                       LicTradNum = fac.LicTradNum,
                                                       CardName = fac.CardName,
                                                       GrosProfit = fac.GrosProfit,
                                                       DocTotal = fac.DocTotal,
                                                       U_ResponseCode = fac.U_ResponseCode,
                                                       U_Description = fac.U_Description,
                                                       U_DigestValue = fac.U_DigestValue
                                                   }).ToList();
            }

            return Guias;
        }

        public ActionResult GuiaCreate(int Id)
        {
            CrearGR crearFT = new CrearGR(Id);

            string[] Respuesta = crearFT.respuestacdr;

            if (Respuesta[0].ToString() == "0")
            {
                ViewBag.Success = Respuesta[1];
                
            }
            else
            {
                ViewBag.Failed = Respuesta[1];
            }
            return RedirectToAction("Index", "Guias");

        }

        public ActionResult GenReport(int Id)
        {
            DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC  [dbo].[Consulta_Datos_Reporte_GR] @DocEntry = '{0}'", Id));
            if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[9].ToString()))
            {
                string RutImg = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["IMG"].ToString() + "Logo.png";
                Reportes.Report_GR_A4 reportToExport = new Reportes.Report_GR_A4(dt, RutImg);
                ReportProcessor reportProcessor = new ReportProcessor();
                Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                instanceReportSource.ReportDocument = reportToExport;
                RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

                string fileName = dt.Rows[0].ItemArray[0].ToString() + "-09-" + dt.Rows[0].ItemArray[15].ToString() + "." + result.Extension;

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
                Response.End();
                ViewBag.Confirmacion = "PDF generado";
                return File(result.DocumentBytes, "application/pdf");
            }
            ViewBag.Error = "Factura sin firmar";
            return View();
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
