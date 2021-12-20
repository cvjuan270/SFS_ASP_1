using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFS_ASP_1.Models.Helpers
{
    public class BandejaFacturador
    {
        public string num_ruc { get; set; } = "";
        public string tip_docu { get; set; } = "";
        public string num_docu { get; set; } = "";
        public string fec_carg { get; set; } = "";
        public string fec_gene { get; set; } = "";
        public string fec_envi { get; set; } = "";
        public string des_obse { get; set; } = "";
        public string nom_arch { get; set; } = "";
        public string ind_situ { get; set; } = "";
        public string tip_arch { get; set; } = "";
        public string firm_digital { get; set; } = "";
    }

    public class RootSFS
    {
        public RootSFS()
        {
            this.listaBandejaFacturador = new List<BandejaFacturador>();
        }
        public string validacion { get; set; }
        public string mensaje { get; set; }
        public List<BandejaFacturador> listaBandejaFacturador { get; set; }
    }
}