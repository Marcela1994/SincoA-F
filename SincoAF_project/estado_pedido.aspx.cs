using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SincoAF_project
{
    public partial class estado_pedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarListadoPedidosPendientes();
            cargarListadoPedidosCompletos();
        }

        private void cargarListadoPedidosPendientes()
        {
            Pedidos pedidos = new Pedidos();
            gr_pedidos_pendientes.DataSource = pedidos.cargarPedidosPendientes();
            gr_pedidos_pendientes.DataBind();
        }

        private void cargarListadoPedidosCompletos()
        {
            Pedidos pedidos = new Pedidos();
            gr_pedidos_completos.DataSource = pedidos.cargarPedidosCompletos();
            gr_pedidos_completos.DataBind();
        }

        protected void gr_pedidos_pendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gr_pedidos_pendientes.SelectedRow;
            int index = row.RowIndex;
            var rowValues = gr_pedidos_pendientes.DataKeys[index].Values;
            string id_pedido = rowValues["id_pedido"].ToString();
            Pedidos pedidos = new Pedidos();
            int resultado = pedidos.completarPedido(id_pedido);
            if (resultado > 0)
            {
                Response.Write("<script>alert('Pedido Completado Correctamente');</script>");
            }
            else
            {
                Response.Write("<script>alert('No se pudo completar el pedido');</script>");
            }
            cargarListadoPedidosPendientes();
            cargarListadoPedidosCompletos();
        }

        protected void gr_pedidos_pendientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr_pedidos_pendientes.PageIndex = e.NewPageIndex;
            Pedidos pedidos = new Pedidos();
            gr_pedidos_pendientes.DataSource = pedidos.cargarPedidosPendientes();
            gr_pedidos_pendientes.DataBind();

        }

        protected void gr_pedidos_completos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gr_pedidos_completos.PageIndex = e.NewPageIndex;
            Pedidos pedidos = new Pedidos();
            gr_pedidos_completos.DataSource = pedidos.cargarPedidosCompletos();
            gr_pedidos_completos.DataBind();
        }
    }
}