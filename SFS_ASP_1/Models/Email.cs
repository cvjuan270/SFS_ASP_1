using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SFS_ASP_1.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string ToEmail { get; set; }
        public string  RupPdf { get; set; }
        public string RutXml { get; set; }
        public string DocType { get; set; }
        public string SerNumCor { get; set; }
        public string NomSocNeg { get; set; }
        public string FecEmi { get; set; }
        public string TotDoc { get; set; }
        public string RazSoc { get; set; }
        public string Ruc { get; set; }
        public string Mensaje { get; set; }
    }
}