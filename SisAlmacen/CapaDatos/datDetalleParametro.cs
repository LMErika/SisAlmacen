using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    public class datDetalleParametro
    {
        #region Singleton
        private static readonly datDetalleParametro _instancia = new datDetalleParametro();

        public static datDetalleParametro Instancia
        {
            get { return datDetalleParametro._instancia; }
        }
        #endregion Singleton

        #region Metodos
        public List<entDetalleParametro> ListadoDetalleParametro()
        {
            SqlCommand cmd = null;
            List<entDetalleParametro> lista = new List<entDetalleParametro>();

            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarDetalleParametro", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    entDetalleParametro dp = new entDetalleParametro();
                    dp.idDetallepmt = Convert.ToInt16(dr["idDetallepmt"]);
                    dp.Descripcion = dr["Descripcion"].ToString();
                    dp.estado = Convert.ToBoolean(dr["estado"]);
                    entParametro p = new entParametro();
                    p.idParametro = Convert.ToInt16(dr["idParametro"]);
                    p.Descripcion = dr["Parametro"].ToString();
                    dp.Parametro = p;
                    lista.Add(dp);   
                }
            }
            catch (Exception e) {
                throw e;
            }
            return lista;
        }

        public Boolean InsertarDetalleParametro(entDetalleParametro dp)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarDetalleParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", dp.Descripcion);
                cmd.Parameters.AddWithValue("@idParametro", dp.Parametro.idParametro);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        public entDetalleParametro DevolverDetalle(int idDetalle)
        {
            SqlCommand cmd = null;
            entDetalleParametro dp = null;

            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarDetalleParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDetalle", idDetalle);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dp = new entDetalleParametro();
                    dp.idDetallepmt = Convert.ToInt16(dr["idDetallepmt"]);
                    dp.Descripcion = dr["Descripcion"].ToString();
                    dp.estado = Convert.ToBoolean(dr["estado"]);
                    entParametro p = new entParametro();
                    p.idParametro = Convert.ToInt16(dr["idParametro"]);
                    p.Descripcion = dr["Parametro"].ToString();
                    dp.Parametro = p;
                }
            }
            catch (Exception e) { throw e; }
            return dp;
        }

        public Boolean EditarDetalleParametro(entDetalleParametro dp)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("editarDetalleParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@descripcion", dp.Descripcion);
                cmd.Parameters.AddWithValue("@idParametro", dp.Parametro.idParametro);
                cmd.Parameters.AddWithValue("@idDetalle", dp.idDetallepmt);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public Boolean EliminarDetalle(entDetalleParametro dp)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("eliminarDetalleParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", dp.estado);
                cmd.Parameters.AddWithValue("@idDetalle", dp.idDetallepmt);
                cn.Open();

                int i = cmd.ExecuteNonQuery();
                if (i > 0) { elimino = true; }
            }
            catch (Exception e) { throw e; }
            return elimino;
        }
        #endregion Metodos



    }
}
