using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SFS_ASP_1.Models;

namespace SFS_ASP_1.Controllers
{
    public class EmailsController : Controller
    {
        private SEGURIMAX02Entities db = new SEGURIMAX02Entities();

        private string cmd;
        // GET: Emails/Create
        public ActionResult Create(int Id,string oDocType)
        {
           
            Email email = new Email();
     
            switch (oDocType)
            {
                case "01":
                    cmd = string.Format("EXEC [dbo].[Consulta_DatosCorreo_FT] @DocEntry = {0}", Id);
                    email.DocType = "Factura";
                    break;
                case "09":
                    cmd = string.Format("EXEC [dbo].[Consulta_DatosCorreo_GR] @DocEntry = {0}", Id);
                    email.DocType = "Guia de remisión";
                    break;
                case "07":
                    cmd = string.Format("EXEC [dbo].[Consulta_DatosCorreo_NC] @DocEntry = {0}", Id);
                    email.DocType = "Nota de Credito";
                    break;      
            }

            DataTable dt = Conexion.Ejecutar_dt(cmd);
            email.RazSoc = dt.Rows[0].ItemArray[0].ToString();
            email.Ruc = dt.Rows[0].ItemArray[1].ToString();
            email.SerNumCor = dt.Rows[0].ItemArray[2].ToString();
            email.NomSocNeg = dt.Rows[0].ItemArray[3].ToString();
            email.ToEmail = dt.Rows[0].ItemArray[4].ToString();
            email.FecEmi = dt.Rows[0].ItemArray[5].ToString();
            email.TotDoc = dt.Rows[0].ItemArray[6].ToString();

            switch (oDocType)
            {
                case "01":
                    email.RupPdf = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["REPO"].ToString() + email.Ruc + "-" + "01" + "-" + email.SerNumCor + ".pdf";
                    email.RutXml = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["FIRMA"].ToString() + email.Ruc + "-" + "01" + "-" + email.SerNumCor + ".xml";
                    break;
                case "07":
                    email.RupPdf = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["REPO"].ToString() + email.Ruc + "-" + "07" + "-" + email.SerNumCor + ".pdf";
                    email.RutXml = ConfigurationManager.AppSettings["RutSerFT"].ToString() + ConfigurationManager.AppSettings["FIRMA"].ToString() + email.Ruc + "-" + "07" + "-" + email.SerNumCor + ".xml";
                    break;
                case "09":
                    email.RupPdf = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["REPO"].ToString() + email.Ruc + "-" + "09" + "-" + email.SerNumCor + ".pdf";
                    email.RutXml = ConfigurationManager.AppSettings["RutSerGR"].ToString() + ConfigurationManager.AppSettings["FIRMA"].ToString() + email.Ruc + "-" + "09" + "-" + email.SerNumCor + ".xml";
                    break;
            }


            return View(email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ToEmail,RupPdf,RutXml,MyProperty,DocType,SerNumCor,NomSocNeg,FecEmi,TotDoc,RazSoc,Ruc")] Email email)
        {
            if (ModelState.IsValid)
            {
               
                    var resEmail = SendEmail.SendEmail.oSendEmail(email.DocType, email.SerNumCor, email.NomSocNeg, email.FecEmi, email.TotDoc, email.RazSoc, email.Ruc, email.RupPdf, email.RutXml, email.ToEmail);

                if (resEmail[0]=="0")
                {
                    ViewBag.Confirmacion = resEmail[0] + "|" + resEmail[1];
                }
                else
                {
                    ViewBag.Error = resEmail[0] + "|" + resEmail[1];
                }
                
                
            }

            return View(email);
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
