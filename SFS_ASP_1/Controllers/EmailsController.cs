using SFS_ASP_1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Net.Mail;
using System.Web.Mvc;


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
        public ActionResult Create([Bind(Include = "Id,ToEmail,RupPdf,RutXml,MyProperty,DocType,SerNumCor,NomSocNeg,FecEmi,TotDoc,RazSoc,Ruc,Mensaje")] Email email)
        {
            if (ModelState.IsValid)
            {
                string[] respuestaSendcorreo = new string[2];
                List<string> Archivo = new List<string>();

               string path= Server.MapPath("~") + @"\Resources\EmailTemplate.txt";
                string Mensaje = System.IO.File.ReadAllText(path);
                try
                {
                    Mensaje = Mensaje.Replace("@SerNumCor", email.SerNumCor);
                    Mensaje = Mensaje.Replace("@NomSocNeg", email.NomSocNeg);
                    Mensaje = Mensaje.Replace("@FecEmi", email.FecEmi);
                    Mensaje = Mensaje.Replace("@TotDoc", email.TotDoc);
                    Mensaje = Mensaje.Replace("@RazSoc", email.RazSoc);
                    Mensaje = Mensaje.Replace("@Ruc", email.Ruc);
                    Mensaje = Mensaje.Replace("@DocType", email.DocType);



                    Archivo.Clear();
                    Archivo.Add(email.RupPdf);
                    Archivo.Add(email.RutXml);

                    MailMessage mail = new MailMessage();
                    mail.To.Add(new MailAddress(email.ToEmail));
                    mail.From = new MailAddress(ConfigurationManager.AppSettings["UsuarioSMTP"].ToString());
                    mail.Subject = email.RazSoc + " | " + email.DocType + ": " + email.SerNumCor;
                    mail.Body = Mensaje;
                    mail.IsBodyHtml = true;

                    /**/
                    foreach (string Adjunto in Archivo)
                    {
                        mail.Attachments.Add(new Attachment(Adjunto));
                    }

                    /**/

                    SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["ServidorSMTP"].ToString(), Int32.Parse(ConfigurationManager.AppSettings["PuertoSMTP"].ToString()));

                    client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UsuarioSMTP"].ToString(), ConfigurationManager.AppSettings["PassUsuaSMTP"].ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    mail.Dispose();
                    Archivo.Clear();
                    client.Dispose();
                    respuestaSendcorreo[0] = "0";
                    respuestaSendcorreo[1] = "Mensaje enviado con exito";
                    ViewBag.Confirmacion = respuestaSendcorreo[0] + "|" + respuestaSendcorreo[1];
                }
                catch (Exception ex)
                {
                    respuestaSendcorreo[0] = "1";
                    respuestaSendcorreo[1] = "Excepción: " + ex.Message;
                    ViewBag.Error = respuestaSendcorreo[0] + "|" + respuestaSendcorreo[1];
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
