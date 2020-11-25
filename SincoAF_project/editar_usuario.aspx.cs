using Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SincoAF_project
{
    public partial class editar_usuario : System.Web.UI.Page
    {
        private string codigo;
        private string nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.codigo = Context.Items["codigo_usuario"].ToString();
                this.nombre = Context.Items["nombre_usuario"].ToString();
                txt_codigo.Text = this.codigo;
                txt_nombre.Text = this.nombre;
            }
        }

        protected void editarUsuario_click(object sender, EventArgs e)
        {
            string codigo = txt_codigo.Text;
            string nombre = txt_nombre.Text;
            Usuarios usuario = new Usuarios();
            int resultado = usuario.editarUsuario(codigo, nombre);
            if(resultado > 0)
            {
                Response.Write("<script>alert('Usuario editado correctamente');</script>");
                Server.Transfer("usuarios.aspx");
            }
            else
            {
                Response.Write("<script>alert('No se pudo editar la informacion del usuario correctamente');</script>");
                Server.Transfer("usuarios.aspx");
            }
        }
    }
}