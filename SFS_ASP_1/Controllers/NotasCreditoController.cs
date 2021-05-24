using SFS_ASP_1.Controllers.GenDocEle;
using SFS_ASP_1.Model;
using SFS_ASP_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Telerik.Reporting.Processing;



namespace SFS_ASP_1.Controllers
{
    public class NotasCreditoController : Controller
    {
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();
        // GET: NotasCredito
        public ActionResult Index() 
        {
            var atenciones = from cr in db.ORIN select cr;




           var NC = atenciones.Where(c => c.DocDate >= DateTime.Now);


            var Facturas = atenciones.ToList();
            List<DocumentosViewModel> notas = (from fac in NC
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

            return View(notas);
        }

        [HttpPost]
        public ActionResult Index(DateTime? FecIni, DateTime? FecFin, string Ruc, string RazSoc, int NumCor = 0)
        {
            var atenciones = from cr in db.ORIN select cr;
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

            var Notas = atenciones.ToList();
            List<DocumentosViewModel> notas = (from fac in Notas
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
            return View(notas);
        }

        [HttpPost]
        public ActionResult NotCredCreate(int Id)
        {
           CrearNC crearNC = new CrearNC(Id);

            string[] Respuesta = crearNC.respuestacdr;

            if (Respuesta[0].ToString() == "0")
            {
                ViewBag.Success = Respuesta[1];
            }
            else
            {
                if (Respuesta[0].ToString() == "100")
                {
                    ViewBag.Failed = Respuesta[1];
                }
                ViewBag.Failed = Respuesta[1];
            }


            return RedirectToAction("Index", "NotasCredito");
        }

        public ActionResult GenReport(int Id)
        {
            DataTable dt = Conexion.Ejecutar_dt(string.Format("EXEC  [dbo].[Consulta_Datos_Reporte_NC] @DocEntry = '{0}'", Id));
            if (!string.IsNullOrEmpty(dt.Rows[0].ItemArray[9].ToString()))
            {
                string RutImg = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["IMG"].ToString() + "Logo.png";
                Reportes.Report_NC_A4 reportToExport = new Reportes.Report_NC_A4(dt, RutImg);
                ReportProcessor reportProcessor = new ReportProcessor();
                Telerik.Reporting.InstanceReportSource instanceReportSource = new Telerik.Reporting.InstanceReportSource();
                instanceReportSource.ReportDocument = reportToExport;
                RenderingResult result = reportProcessor.RenderReport("PDF", instanceReportSource, null);

                string fileName = dt.Rows[0].ItemArray[0].ToString() + "-07-" + dt.Rows[0].ItemArray[10].ToString() + "." + result.Extension;

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