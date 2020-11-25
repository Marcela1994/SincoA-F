<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="editar_usuario.aspx.cs" Inherits="SincoAF_project.editar_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <div class="form-group">
            <asp:Label ID="lbl_codigo" runat="server">CODIGO DE REGISTRO</asp:Label>
            <asp:TextBox type="text" CssClass="form-control" ID="txt_codigo" runat="server" Enabled="false"></asp:TextBox>
            <asp:Label ID="lbl_nombre" runat="server">NOMBRE COMPLETO</asp:Label>
            <asp:TextBox type="text" ID="txt_nombre" runat="server"></asp:TextBox>
            <asp:Button ID="btnEditarUsuario" CssClass="btn btn-secondary" Text="Editar Usuario" runat="server" OnClick="editarUsuario_click" />
        </div>
    </form>
    <a class="boton_volver" href="usuarios.aspx" role="button">LISTADO USUARIOS</a>
    <a class="boton_volver" href="index.aspx" role="button">REGRESAR</a>
</asp:Content>
