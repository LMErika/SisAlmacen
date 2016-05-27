using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entDetalleParametro
    {
        public int idDetallepmt { get; set; }
        public String Descripcion { get; set; }
        public entParametro Parametro { get; set; }
        public Boolean estado { get; set; }

    }
}
