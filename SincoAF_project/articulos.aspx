<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="articulos.aspx.cs" Inherits="SincoAF_project.articulos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <br />
        <br />
        <asp:Label ID="lbl_nombre" runat="server">NOMBRE COMPLETO</asp:Label>
        <asp:TextBox type="text" ID="txt_nombreArt" runat="server" required="true"></asp:TextBox>
        <asp:Button ID="btnCrearUser" CssClass="btn btn-primary" Text="CREAR" runat="server" OnClick="crearArticulo_click" />
        <br />
        <br />
        <hr />
        <center><asp:GridView ID="gr_listadoArticulos" runat="server" AutoGenerateColumns="False" Font-Bold="True" Font-Italic="True" Height="194px" Width="391px">
            <Columns>
                <asp:BoundField AccessibleHeaderText="codigo_articulo" DataField="codigo_articulo" HeaderText="CODIGO DEL ARTICULO" />
                <asp:BoundField AccessibleHeaderText="nombre_articulo" DataField="nombre_articulo" HeaderText="NOMBRE DEL ARTICULO" />
            </Columns>
            <RowStyle BackColor="#99CCFF" BorderColor="#0033CC" />
        </asp:GridView>
        <br />
    </form>
    <br />
    <br />
    <hr />
    <br />
    <a class="boton_volver" href="index.aspx" role="button">REGRESAR</a>
</asp:Content>
