using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Backend
{
    public class NuevoPedido
    {
        public DataTable listarUsuarios()
        {
            DataTable dt;
            SqlConnection con = new SqlConnection("Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True");
            con.Open();
            using (SqlCommand cmd = new SqlCommand("sp_seleccionar_usuario", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
        }

        public string registrarPedido(string codigoUsuario, string fechaPedido, string concepto)
        {
            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand crearArticuloSP = new SqlCommand("sp_registrar_pedido", connection);
                crearArticuloSP.CommandType = System.Data.CommandType.StoredProcedure;
                crearArticuloSP.Parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
                crearArticuloSP.Parameters.Add(new SqlParameter("@fecha_pedido", fechaPedido));
                crearArticuloSP.Parameters.Add(new SqlParameter("@concepto", concepto));

                SqlParameter RuturnValue = new SqlParameter("@idPedido", SqlDbType.Int);
                RuturnValue.Direction = ParameterDirection.Output;

                SqlDataReader resultado = crearArticuloSP.ExecuteReader();
                string id_pedido = (string)crearArticuloSP.Parameters["@idPedido"].Value;
                return id_pedido;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public string obtenerIdPedido(string codigoUsuario, string fechaPedido, string concepto)
        {
            try
            {
                DataTable dt;
                SqlConnection con = new SqlConnection("Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_registrar_pedido", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@codigoUsuario", codigoUsuario));
                    cmd.Parameters.AddWithValue("@fecha_pedido", Convert.ToDateTime(fechaPedido));
                    cmd.Parameters.Add(new SqlParameter("@concepto", concepto));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    da.Fill(dt);
                    string idPedido = dt.Rows[0].ItemArray[0].ToString();
                    con.Close();
                    return idPedido;
                }
            }catch(Exception e)
            {
                return e.Message;
            }
        }

        public int registrarArticulo_x_Pedido(ArticuloXpedido articulo, int id_pedido)
        {
            try
            {
                ConexionBD con = new ConexionBD();
                SqlConnection connection = con.crearConexion();
                connection.Open();
                SqlCommand crearArticuloSP = new SqlCommand("sp_articulo_x_pedido", connection);
                crearArticuloSP.CommandType = CommandType.StoredProcedure;
                crearArticuloSP.Parameters.Add(new SqlParameter("@id_pedido", id_pedido));
                crearArticuloSP.Parameters.Add(new SqlParameter("@id_articulo", articulo.idProducto));
                crearArticuloSP.Parameters.Add(new SqlParameter("@cantidad", articulo.cantidad));
                crearArticuloSP.Parameters.Add(new SqlParameter("@importado", articulo.importado));
                int resultado = crearArticuloSP.ExecuteNonQuery();
                return resultado;
            }
            catch (Exception e)
            {

                return 0;
            }
        }
    }
}
