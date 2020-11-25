using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Backend
{
    public class Usuarios
    {
        public int crearUsuario(string cc, string nombreUsuario)
        {
            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand crearUsuarioSP = new SqlCommand("sp_crear_usuario", connection);
                crearUsuarioSP.CommandType = System.Data.CommandType.StoredProcedure;
                crearUsuarioSP.Parameters.Add(new SqlParameter("@codigo", cc));
                crearUsuarioSP.Parameters.Add(new SqlParameter("@nombre", nombreUsuario));
                int resultado = crearUsuarioSP.ExecuteNonQuery();
                return resultado;
            }
            catch (Exception ex) {
                
                return 0;
            }
            
        }

        public DataTable listarUsuarios()
        {
            DataTable dt;
            SqlConnection con = new SqlConnection("Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True");
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_listar_usuarios", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public int eliminarUsuario(string codigo_usuario)
        {
            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand eliminarUsuarioSP = new SqlCommand("sp_eliminar_usuario", connection);
                eliminarUsuarioSP.CommandType = System.Data.CommandType.StoredProcedure;
                eliminarUsuarioSP.Parameters.Add(new SqlParameter("@codigo_usuario", codigo_usuario));
                int resultado = eliminarUsuarioSP.ExecuteNonQuery();
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int editarUsuario(string codigo_usuario, string nombre)
        {
            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand editarUsuarioSP = new SqlCommand("sp_modificar_usuario", connection);
                editarUsuarioSP.CommandType = System.Data.CommandType.StoredProcedure;
                editarUsuarioSP.Parameters.Add(new SqlParameter("@codigo_usuario", codigo_usuario));
                editarUsuarioSP.Parameters.Add(new SqlParameter("@nombre", nombre));
                int resultado = editarUsuarioSP.ExecuteNonQuery();
                return resultado;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
