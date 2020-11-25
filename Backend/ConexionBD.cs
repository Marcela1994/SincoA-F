using System;
using System.Data.SqlClient;

namespace Backend
{
    public class ConexionBD
    {
        static string cadenaConexion = "Server=(localdb)\\marcela;Initial Catalog=SincoAF_DB;Integrated Security=True";

        public SqlConnection crearConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            return conexion;
        }
    }
}
