using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SFS_ASP_1.Controllers.Helper
{
    public class CorreoElectronico
    {
        public void SendEmail(CorreoElectronico correoElectronico) 
        {
            //string[] respuestaSendcorreo;
            //   List<string> Archivo = new List<string>();
            //string Mensaje = "";
               

            //        Archivo.Clear();
            //        Archivo.Add(RutaPdf);
            //        Archivo.Add(RutaXml);

            //        MailMessage mail = new MailMessage();
            //        mail.To.Add(new MailAddress(destinatario));
            //        mail.From = new MailAddress(ConfigurationManager.AppSettings["UsuarioSMTP"].ToString());
            //        mail.Subject =  NomDoc;
            //        mail.Body = Mensaje;
            //        //mail.IsBodyHtml = true;

            //        /**/
            //        foreach (string Adjunto in Archivo)
            //        {
            //            mail.Attachments.Add(new Attachment(Adjunto));
            //        }

            //        /**/

            //        SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["ServidorSMTP"].ToString(),int.Parse(ConfigurationManager.AppSettings["PuertoSMTP"].ToString()));

            //        client.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UsuarioSMTP"].ToString(), ConfigurationManager.AppSettings["PassUsuaSMTP"].ToString());
            //        client.EnableSsl = true;
            //        client.Send(mail);
            //        mail.Dispose();
            //        Archivo.Clear();
            //        client.Dispose();

        }
    }
}