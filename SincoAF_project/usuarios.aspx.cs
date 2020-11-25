using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SincoAF_project
{
    public partial class usuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarListadoUsuarios();
        }

        public void cargarListadoUsuarios()
        {
            Usuarios usuario = new Usuarios();
            gr_listadoUsuarios.DataSource = usuario.listarUsuarios();
            gr_listadoUsuarios.DataBind();
        }

        protected void crearUsuario_click(object sender, EventArgs e)
        {
            string codigo = txt_codigo.Text;
            string nombre = txt_nombre.Text;
            Usuarios usuario = new Usuarios();
            int resultado = usuario.crearUsuario(codigo, nombre);

            if (resultado > 0)
            {
                Response.Write("<script>alert('Usuario registrado correctamente');</script>");
                cargarListadoUsuarios();
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el usuario');</script>");
            }
        }

        protected void gr_listadoUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gr_listadoUsuarios.SelectedRow;
            int index = row.RowIndex;
            var rowValues = gr_listadoUsuarios.DataKeys[index].Values;
            string codigo = rowValues["codigo_usuario"].ToString();
            string nombre = rowValues["nombre_usuario"].ToString();
            Context.Items.Add("codigo_usuario", codigo);
            Context.Items.Add("nombre_usuario", nombre);
            Server.Transfer("editar_usuario.aspx");
        }

        protected void gr_listadoUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            string codigo = gr_listadoUsuarios.DataKeys[e.RowIndex].Values["codigo_usuario"].ToString();
            Usuarios usuario = new Usuarios();
            usuario.eliminarUsuario(codigo);
            cargarListadoUsuarios();
        }
    }
}