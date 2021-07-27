using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes
{
    public class Datos
    {
        public string Contacto { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cta { get; set; }
        public string Facebook { get; set; }
        public string TextoLibre { get; set; }
        public Datos() 
        {
            this.Contacto = "-";
            this.Celular = "-";
            this.Email = "-";
            this.Cta = "-";
            this.Facebook = "-";
            this.TextoLibre = "-";
        }
    }
}
