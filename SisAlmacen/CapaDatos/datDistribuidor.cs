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
    public class datDistribuidor
    {
        #region Singleton

        public static readonly datDistribuidor _instancia = new datDistribuidor();

        public static datDistribuidor Instancia
        {
            get { return datDistribuidor._instancia; }
        }

        #endregion Singleton

        #region Metodos

        public List<entDistribuidor> ListarDistribuidor()
        {
            SqlCommand cmd = null;
            List<entDistribuidor> lista = new List<entDistribuidor>();
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("ListarDistribuidor", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entDistribuidor d = new entDistribuidor();
                    d.idDistribuidor = Convert.ToInt16(dr["idDistribuidor"]);
                    d.RazonSocial = dr["RazonSocial"].ToString();
                    d.Ruc = dr["Ruc"].ToString();
                    d.Direccion = dr["Direccion"].ToString();
                    d.Telefono = dr["Telefono"].ToString();
                    d.Email = dr["Email"].ToString();
                    d.estado = Convert.ToBoolean(dr["estado"]);
                    lista.Add(d);

                }
            }
            catch (Exception e) { throw e; }
            return lista;
        }

        public Boolean InsertarDistribuidor(entDistribuidor d)
        {
            SqlCommand cmd = null;
            Boolean inserto = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("InsertarDistribuidor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RazonSocial", d.RazonSocial);
                cmd.Parameters.AddWithValue("@Ruc", d.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", d.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", d.Telefono);
                cmd.Parameters.AddWithValue("@Email", d.Email);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { inserto = true; }
            }
            catch (Exception e) { throw e; }
            return inserto;
        }

        public entDistribuidor BuscarDistribuidor(int idDistribuidor)
        {
            SqlCommand cmd = null;
            entDistribuidor d = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("BuscarDistribuidor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idDistribuidor", idDistribuidor);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    d = new entDistribuidor();
                    d.idDistribuidor = Convert.ToInt16(dr["idDistribuidor"]);
                    d.RazonSocial = dr["RazonSocial"].ToString();
                    d.Ruc = dr["Ruc"].ToString();
                    d.Direccion = dr["Direccion"].ToString();
                    d.Telefono = dr["Telefono"].ToString();
                    d.Email = dr["Email"].ToString();
                    d.estado = Convert.ToBoolean(dr["estado"]);
                }
            }
            catch (Exception e) { throw e; }
            return d;
        }

        public Boolean EditarDistribuidor(entDistribuidor d)
        {
            SqlCommand cmd = null;
            Boolean edito = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EditarDistribuidor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RazonSocial", d.RazonSocial);
                cmd.Parameters.AddWithValue("@Ruc", d.Ruc);
                cmd.Parameters.AddWithValue("@Direccion", d.Direccion);
                cmd.Parameters.AddWithValue("@Telefono", d.Telefono);
                cmd.Parameters.AddWithValue("@Email", d.Email);
                cmd.Parameters.AddWithValue("@estado", d.estado);
                cmd.Parameters.AddWithValue("@idDistribuidor", d.idDistribuidor);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0) { edito = true; }
            }
            catch (Exception e) { throw e; }
            return edito;
        }

        public Boolean EliminarDistribuidor(entDistribuidor d)
        {
            SqlCommand cmd = null;
            Boolean elimino = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("EliminarDistribuidor", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", cn);
                cmd.Parameters.AddWithValue("@idDistribuidor", cn);
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
