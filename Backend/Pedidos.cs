using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Backend
{
    public class Pedidos
    {
        public DataTable cargarPedidosPendientes()
        {
            DataTable dt;
            SqlConnection con = new SqlConnection("Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True");
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_cargar_pedidos_pendientes", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public DataTable cargarPedidosCompletos()
        {
            DataTable dt;
            SqlConnection con = new SqlConnection("Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True");
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_cargar_pedidos_completos", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public int completarPedido(string idPedido)
        {
            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand editarUsuarioSP = new SqlCommand("sp_completar_pedido", connection);
                editarUsuarioSP.CommandType = System.Data.CommandType.StoredProcedure;
                editarUsuarioSP.Parameters.Add(new SqlParameter("@id_pedido", idPedido));
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
