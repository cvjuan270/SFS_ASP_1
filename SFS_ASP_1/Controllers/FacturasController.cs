using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SFS_ASP_1.Model;
using SFS_ASP_1.Models;
using System.IO;
using SFS_ASP_1.Controllers.GenDocEle;

namespace SFS_ASP_1.Controllers
{
    public class FacturasController : Controller
    {
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();

        // GET: Facturas
        public ActionResult Index(DateTime? FecIni, DateTime? FecFin, string Ruc, string RazSoc, int NumCor = 0)
        {
            
            var atenciones = db.OINV.Include(m => m.DocDate);
            atenciones = from cr in db.OINV select cr;

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
            List<FacturaViewModel> facturas = (from fac in Facturas
                                               join ser in db.NNM1 on fac.Series equals ser.Series
                                               orderby fac.FolioNum ascending
                                               select new FacturaViewModel { DocEntry = fac.DocEntry, DocDate = fac.DocDate, SeriesName = ser.SeriesName, FolioNum = fac.FolioNum,
                                                   LicTradNum = fac.LicTradNum, CardName = fac.CardName, GrosProfit = fac.GrosProfit, DocTotal = fac.DocTotal,
                                                   U_ResponseCode = fac.U_ResponseCode, U_Description = fac.U_Description, U_DigestValue = fac.U_DigestValue }).ToList();

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
                ViewBag.Success = Respuesta[1];  
            }
            else
            {
                ViewBag.Failed = Respuesta[1];
            }

            return RedirectToAction("Index", "Facturas");
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
