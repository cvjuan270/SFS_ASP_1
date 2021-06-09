using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail
{
    public class SendEmail
    {
        public static string[] oSendEmail(string DocType, string SerNumCor, string NomSocNeg, string FecEmi, string DocTot, string RazSoc, string Ruc, string RutPdf, string RutXml, string ToEmail)
        {
            string[] respuestaSendcorreo = new string[2];
            List<string> Archivo = new List<string>();
            try
            {
                //string Mensaje = Settings.Default.CuerpoCorreo;
                //Mensaje = Mensaje.Replace("@SerNumCor", SerNumCor);
                //Mensaje = Mensaje.Replace("@NomSocNeg", NomSocNeg);
                //Mensaje = Mensaje.Replace("@FecEmi", FecEmi);
                //Mensaje = Mensaje.Replace("@TotDoc", DocTot);
                //Mensaje = Mensaje.Replace("@RazSoc", RazSoc);
                //Mensaje = Mensaje.Replace("@Ruc", Ruc);
                //Mensaje = Mensaje.Replace("@DocType", DocType);

                string Mensaje = "Se adjunta a este mensaje la: " + DocType+" Por S/ "+DocTot;

                Archivo.Clear();
                Archivo.Add(RutPdf);
                Archivo.Add(RutXml);

                MailMessage mail = new MailMessage();
                mail.To.Add(new MailAddress(ToEmail));
                mail.From = new MailAddress("cvjuan270@gmail.com");
                mail.Subject = RazSoc + " | " + DocType + ": " + SerNumCor;
                mail.Body = Mensaje;
                mail.IsBodyHtml = true;

                /**/
                foreach (string Adjunto in Archivo)
                {
                    mail.Attachments.Add(new Attachment(Adjunto));
                }

                /**/

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

                client.Credentials = new System.Net.NetworkCredential("cvjuan270@gmail.com", "Gmail161290270");
                client.EnableSsl = true;
                client.Send(mail);
                mail.Dispose();
                Archivo.Clear();
                client.Dispose();
                respuestaSendcorreo[0] = "0";
                respuestaSendcorreo[1] = "Mensaje enviado con exito";
                return respuestaSendcorreo;
            }
            catch (Exception ex)
            {
                respuestaSendcorreo[0] = "1";
                respuestaSendcorreo[1] = "Excepción: " + ex.Message;
                return respuestaSendcorreo;
            }
        }
    }
}
