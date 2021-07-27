using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFS_ASP_1.Models
{
    public class JsonDoc
    {
        //"{\"num_ruc\":\"20603346735\",\"tip_docu\":\"01\",\"num_docu\":\"F002-1\"}"
        public string num_ruc { get; set; }
        public string tip_docu { get; set; }
        public string num_docu { get; set; }

        public JsonDoc()
        {

        }
    }
}
