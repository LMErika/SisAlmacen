using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class entUsuario
    {
        public int idUsuario { get; set; }
        public String Nombre { get; set; }
        public String ApellidoPaterno { get; set; }
        public String ApellidoMaterno { get; set; }
        public String dni { get; set; }
        public String Usuario { get; set; }
        public String Contasena { get; set; }
        public DateTime Fechanacimiento { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
        public String fotografia { get; set; }
    }
}
