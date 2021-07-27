using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFS_ASP_1.Models
{
    public class RootListaSFS
    {
        [JsonProperty("validacion")]
        public string Validacion { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        [JsonProperty("listaBandejaFacturador")]
        public List<ListaBandejaFacturador> ListaBandejaFacturador { get; set; }
    }
    public class ListaBandejaFacturador
    {
        [JsonProperty("num_ruc")]
        public string NumRuc { get; set; }

        [JsonProperty("tip_docu")]
        public string TipDocu { get; set; }

        [JsonProperty("num_docu")]
        public string NumDocu { get; set; }

        [JsonProperty("fec_carg")]
        public string FecCarg { get; set; }

        [JsonProperty("fec_gene")]
        public string FecGene { get; set; }

        [JsonProperty("fec_envi")]
        public object FecEnvi { get; set; }

        [JsonProperty("des_obse")]
        public string DesObse { get; set; }

        [JsonProperty("nom_arch")]
        public string NomArch { get; set; }

        [JsonProperty("ind_situ")]
        public string IndSitu { get; set; }

        [JsonProperty("tip_arch")]
        public string TipArch { get; set; }

        [JsonProperty("firm_digital")]
        public object FirmDigital { get; set; }
    }

   
}