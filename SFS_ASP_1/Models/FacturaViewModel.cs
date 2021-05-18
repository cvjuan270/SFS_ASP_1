using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SFS_ASP_1.Models
{
    public class FacturaViewModel
    {
        public int DocEntry { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DocDate { get; set; }
        public string SeriesName { get; set; }
        public int? FolioNum { get; set; }
        public string LicTradNum { get; set; }
        public string CardName { get; set; }
        public decimal? GrosProfit { get; set; }
        public decimal? DocTotal { get; set; }
        public string U_ResponseCode { get; set; }
        public string U_Description { get; set; }
        public string U_DigestValue { get; set; }
    }
}