using Backend;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SincoAF_project
{
    public partial class nuevo_pedido : System.Web.UI.Page
    {
        static List<ArticuloXpedido> listadoArticulos;
        static DataTable tablaArticulos;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)

            {
                cargarListadoUsuarios();
                cargarListadoArticulos();
                ddl_articulos.DataBind();
                listadoArticulos = new List<ArticuloXpedido>();
                tablaArticulos = new DataTable("TablaArticulos");
                tablaArticulos.Columns.Add(new DataColumn("Id_Producto", typeof(int)));
                tablaArticulos.Columns.Add(new DataColumn("Nombre_Producto", typeof(string)));
                tablaArticulos.Columns.Add(new DataColumn("Cantidad", typeof(int)));
                tablaArticulos.Columns.Add(new DataColumn("Importado", typeof(string)));
            }
        }

        public void cargarListadoUsuarios()
        {
            Usuarios usuario = new Usuarios();
            ddl_usuarios.DataSource = usuario.listarUsuarios();
            ddl_usuarios.DataTextField = "nombre_usuario";
            ddl_usuarios.DataValueField = "codigo_usuario";
            ddl_usuarios.DataBind();
        }

        public void cargarListadoArticulos()
        {
            Articulos art = new Articulos();
            ddl_articulos.DataSource = art.listarArticulos();
            ddl_articulos.DataTextField = "nombre_articulo";
            ddl_articulos.DataValueField = "codigo_articulo";
            ddl_articulos.DataBind();
        }


        protected void crearPedido_click(object sender, EventArgs e)
        {
            string nombre = ddl_usuarios.SelectedValue;
            string fecha = txt_fechaPedido.Text;
            string concepto = txt_conceptoPedido.Text;

            int resultado = 0;
            int id_pedido = 0;
            try
            {
                NuevoPedido np = new NuevoPedido();
                id_pedido = int.Parse(np.obtenerIdPedido(nombre, fecha, concepto));
                foreach (ArticuloXpedido articulo in listadoArticulos)
                {
                    np = new NuevoPedido();
                    np.registrarArticulo_x_Pedido(articulo, id_pedido);
                }
                resultado = 1;
            }
            catch(Exception ex)
            {
                resultado = 0;
            }
            
            if (resultado > 0)
            {
                Response.Write("<script>alert('Pedido '"+ id_pedido +"' Creado correctamente');</script>");
                Server.Transfer("estado_pedido.aspx");
            }
            else
            {
                Response.Write("<script>alert('No se pudo crear el pedido correctamente');</script>");
            }
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            ArticuloXpedido articulo = new ArticuloXpedido();
            articulo.idProducto = int.Parse(ddl_articulos.SelectedItem.Value);
            articulo.nombreProducto = ddl_articulos.SelectedItem.Text;
            articulo.cantidad = int.Parse(txt_cantidad.Text);
            articulo.importado = cb_importado.Checked ? "S" : "N";
            listadoArticulos.Add(articulo);

            DataRow row = tablaArticulos.NewRow();
            row["Id_Producto"] = articulo.idProducto;
            row["Nombre_Producto"] = articulo.nombreProducto;
            row["Cantidad"] = articulo.cantidad;
            row["Importado"] = articulo.importado;
            tablaArticulos.Rows.Add(row);

            gr_articulosPedido.DataSource = tablaArticulos;
            gr_articulosPedido.DataBind();

        }
    }
}