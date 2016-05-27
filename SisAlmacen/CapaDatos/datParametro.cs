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
    public class datParametro
    {
        #region Singleton
        private static readonly datParametro _instancia = new datParametro();

        public static datParametro Instancia
        {
            get { return datParametro._instancia; }
        }
        #endregion

        #region metodos
        public List<entParametro> ListadoParametros()
        {
            SqlCommand cmd = null;
            List<entParametro> lista = new List<entParametro>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarParametro", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entParametro p = new entParametro();
                    p.idParametro = Convert.ToInt16(dr["idParametro"]);
                    p.Codigo = dr["Codigo"].ToString();
                    p.Descripcion = dr["Descripcion"].ToString();
                    lista.Add(p);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return lista;
        }

        public Boolean InsertarParametro(entParametro p)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("insertarParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            return inserto;
        }

        public entParametro BuscarParametro(int idParametro)
        {
            SqlCommand cmd = null;
            entParametro p = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("buscarParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idparametro", idParametro);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new entParametro();
                    p.idParametro = Convert.ToInt16(dr["idParametro"]);
                    p.Codigo = dr["Codigo"].ToString();
                    p.Descripcion = dr["Descripcion"].ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return p;
        }

        public Boolean EditarParametro(entParametro p)
        {
            SqlCommand cmd = null;
            Boolean editar = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("editarParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@idParametro", p.idParametro);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { editar = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            return editar;
        }

        public Boolean EliminarParametro(int idProducto)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("eliminarParametro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idParametro", idProducto);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { elimino = true; }
            }
            catch (Exception e)
            {
                throw e;
            }
            return elimino;
        }
        #endregion
    }
}
