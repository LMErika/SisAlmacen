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
    public class Usuario
    {
        #region singleton
        private static readonly Usuario _instancia = new Usuario();
        public static Usuario Instancia
        {
            get { return Usuario._instancia; }
        }
        #endregion singleton

        #region metodos
        public entUsuario VerificarAcceso(String _Usuario, String _Contasena)
        {
            SqlCommand cmd = null;
            entUsuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsuario", _Usuario);
                cmd.Parameters.AddWithValue("@prmstrContasena", _Contasena);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.Nombre = dr["Nombre"].ToString();
                    u.ApellidoPaterno = dr["ApellidoPaterno"].ToString();
                    u.ApellidoMaterno = dr["ApellidoMaterno"].ToString();
                    u.dni = dr["dni"].ToString();
                    u.Usuario = dr["Usuario"].ToString();
                    u.Contasena = dr["Contasena"].ToString();
                    u.Fechanacimiento = Convert.ToDateTime(dr["Fechanacimiento"]);
                    u.Direccion = dr["Direccion"].ToString();
                    u.Email = dr["Email"].ToString();
                    u.fotografia = dr["fotografia"].ToString();
                }
            }
            catch (Exception ex)
            {
                
                throw;
            }
            return u;
        }
       #endregion metodos
    }
}
