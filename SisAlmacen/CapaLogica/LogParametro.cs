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
    public class LogParametro
    {
        #region Singleton
        private static readonly LogParametro _instancia = new LogParametro();

        public static LogParametro Instancia
        {
            get { return LogParametro._instancia; }
        }
        #endregion

        #region metodos
        public List<entParametro> ListarParametro()
        {
            try
            {
                return datParametro.Instancia.ListadoParametros();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarParametro(entParametro p)
        {
            try
            {
                return datParametro.Instancia.InsertarParametro(p);
            }
            catch (Exception e) { throw e; }
        }
        public entParametro BuscarParametro(int idParametro)
        {
            try
            {
                return datParametro.Instancia.BuscarParametro(idParametro);
            }
            catch (Exception e) { throw e; }
        }
        public Boolean EditarParametro(entParametro p)
        {
            try
            {
                return datParametro.Instancia.EditarParametro(p);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarParametro(int idParametro)
        {
            try
            {
                return datParametro.Instancia.EliminarParametro(idParametro);
            }
            catch (Exception e) { throw e; }
        }
        #endregion

    }
}
