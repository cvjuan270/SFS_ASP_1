using System;
using System.Collections.Generic;
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

        // GET: Emails/Create
        public ActionResult Create(int Id,string DocType)
        {
            Email email = new Email();

            return View();
        }

        // POST: Emails/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ToEmail,RupPdf,RutXml,MyProperty,DocType,SerNumCor,NomSocNeg,FecEmi,TotDoc,RazSoc,Ruc")] Email email)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
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
