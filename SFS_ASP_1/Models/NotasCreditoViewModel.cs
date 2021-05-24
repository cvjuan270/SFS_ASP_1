using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFS_ASP_1.Models
{
    public class NotasCreditoViewModel
    {
        public IEnumerable<DocumentosViewModel> NotasCredito { get; set; }
        public int RegistrosXpagina { get; set; }
        public int NumRegistros { get; set; }
    }
}