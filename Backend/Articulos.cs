using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Backend
{
    public class Articulos
    {
        public int crearArticulo(string nombre) {

            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand crearArticuloSP = new SqlCommand("sp_crear_articulo", connection);
                crearArticuloSP.CommandType = System.Data.CommandType.StoredProcedure;
                crearArticuloSP.Parameters.Add(new SqlParameter("@nombre", nombre));
                int resultado = crearArticuloSP.ExecuteNonQuery();
                return resultado;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }


        public DataTable listarArticulos()
        {
            DataTable dt;
            SqlConnection con = new SqlConnection("Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True");
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_listar_articulos", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

    }
}
