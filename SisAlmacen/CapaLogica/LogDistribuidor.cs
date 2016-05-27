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
    public class LogDistribuidor
    {
        #region Singleton
        private static readonly LogDistribuidor _instancia = new LogDistribuidor();

        public static LogDistribuidor Instancia
        {
            get { return LogDistribuidor._instancia; }
        }
        #endregion Singleton

        #region Metodos

        public List<entDistribuidor> ListarDistribuidor()
        {
            try {
                return datDistribuidor.Instancia.ListarDistribuidor();
            }
            catch (Exception e) { throw e; }
        }

        public Boolean InsertarDistribuidor(entDistribuidor d)
        {
            try {
                return datDistribuidor.Instancia.InsertarDistribuidor(d);
            }
            catch (Exception e) { throw e; }
        }

        public entDistribuidor BuscarDistribuidor(int idDistribuidor)
        {
            try {
                return datDistribuidor.Instancia.BuscarDistribuidor(idDistribuidor);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EditarDistribuidro(entDistribuidor d)
        {
            try {
                return datDistribuidor.Instancia.EditarDistribuidor(d);
            }
            catch (Exception e) { throw e; }
        }

        public Boolean EliminarDistribuidor(entDistribuidor d)
        {
            try {
                return datDistribuidor.Instancia.EliminarDistribuidor(d);
            }
            catch (Exception e) { throw e; }
        }

        #endregion Metodos
    }
}
