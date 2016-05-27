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
    public class LogDetalleParametro
    {
        #region Singleton
        private static readonly LogDetalleParametro _instancia = new LogDetalleParametro();

        public static LogDetalleParametro Instancia
        {
            get { return LogDetalleParametro._instancia; }
        }        
        #endregion Singleton

        #region Metodos

        public List<entDetalleParametro> ListarDetalleParametro()
        {
            try {
                return datDetalleParametro.Instancia.ListadoDetalleParametro();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarDetalleParametro(entDetalleParametro dp)
        {
            try {
                return datDetalleParametro.Instancia.InsertarDetalleParametro(dp);
            }
            catch (Exception e) { throw e; }
        }

        public entDetalleParametro DevolverDetalle(int idDetalle)
        {
            try {
                return datDetalleParametro.Instancia.DevolverDetalle(idDetalle);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarDetalleParametro(entDetalleParametro dp)
        {
            try {
                return datDetalleParametro.Instancia.EditarDetalleParametro(dp);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarDetalleParametro(entDetalleParametro dp)
        {
            try {
                return datDetalleParametro.Instancia.EliminarDetalle(dp);
            }
            catch (Exception e) { throw e; }
        }
        #endregion Metodos
    }
}
