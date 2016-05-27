using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;
using CapaDatos;

namespace CapaLogica
{
    public class LogUsuario
    {
        #region singleton
        private static readonly LogUsuario _instancia = new LogUsuario();
        public static LogUsuario Instancia
        {
            get { return LogUsuario._instancia; }
        }
        #endregion singleton

        #region metodos
        public entUsuario VerificarAcceso(String _Usuario, String _Contasena)
        {
            try
            {
                return Usuario.Instancia.VerificarAcceso(_Usuario, _Contasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion metodos

    }
}
