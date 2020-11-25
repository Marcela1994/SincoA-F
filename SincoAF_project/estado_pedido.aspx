<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="estado_pedido.aspx.cs" Inherits="SincoAF_project.estado_pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="p-3">
            <h1>Listado de pedidos pendientes</h1>
        </div>
        <asp:GridView ID="gr_pedidos_pendientes" AllowPaging="True" runat="server" DataKeyNames="id_pedido" OnPageIndexChanging="gr_pedidos_pendientes_PageIndexChanging"
            OnSelectedIndexChanged="gr_pedidos_pendientes_SelectedIndexChanged" AutoGenerateColumns="False" PagerStyle-CssClass="thead-dark">
            <Columns>
                <asp:BoundField AccessibleHeaderText="id_pedido" DataField="id_pedido" HeaderText="ID DE PEDIDO" />
                <asp:BoundField AccessibleHeaderText="nombre_usuario" DataField="nombre_usuario" HeaderText="NOMBRE USUARIO" />
                <asp:BoundField AccessibleHeaderText="fecha_pedido" DataField="fecha_pedido" HeaderText="FECHA PEDIDO" />
                <asp:BoundField AccessibleHeaderText="fecha_ingreso" DataField="fecha_ingreso" HeaderText="FECHA INGRESO" />
                <asp:BoundField AccessibleHeaderText="concepto" DataField="concepto" HeaderText="CONCEPTO" />
                <asp:BoundField AccessibleHeaderText="articulo_principal" DataField="articulo_principal" HeaderText="ARTICULO PRINCIPAL" />
                <asp:BoundField AccessibleHeaderText="estado_pedido" DataField="estado_pedido" HeaderText="ESTADO DEL PEDIDO" />
                <asp:ButtonField AccessibleHeaderText="Completar" CommandName="Select" Text="COMPLETAR" />
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="15" Position="Bottom" />

<PagerStyle CssClass="thead-dark"></PagerStyle>
            <RowStyle BackColor="#99CCFF" />
        </asp:GridView>
        <p>
            <div class="p-3">
                <h1>Listado de pedidos completos</h1>
            </div>
        </p>
        <asp:GridView ID="gr_pedidos_completos" AllowPaging="true" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gr_pedidos_completos_PageIndexChanging" 
            DataKeyNames="id_pedido" PagerStyle-CssClass="thead-dark">
            <Columns>
                <asp:BoundField AccessibleHeaderText="id_pedido" DataField="id_pedido" HeaderText="ID PEDIDO" />
                <asp:BoundField AccessibleHeaderText="nombre_usuario" DataField="nombre_usuario" HeaderText="NOMBRE DE USUARIO" />
                <asp:BoundField AccessibleHeaderText="fecha_pedido" DataField="fecha_pedido" HeaderText="FECHA PEDIDO" />
                <asp:BoundField AccessibleHeaderText="fecha_ingreso" DataField="fecha_ingreso" HeaderText="FECHA INGRESO" />
                <asp:BoundField AccessibleHeaderText="concepto" DataField="concepto" HeaderText="CONCEPTO" />
                <asp:BoundField AccessibleHeaderText="articulo_principal" DataField="articulo_principal" HeaderText="ARTICULO PRINCIPAL" />
                <asp:BoundField AccessibleHeaderText="fecha_completado" DataField="fecha_completado" HeaderText="FECHA DE COMPLETADO" />
                <asp:BoundField AccessibleHeaderText="estado_pedido" DataField="estado_pedido" HeaderText="ESTADO DEL PEDIDO" />
            </Columns>
            <PagerSettings Mode="NumericFirstLast" PageButtonCount="15" Position="Bottom" />

<PagerStyle CssClass="thead-dark"></PagerStyle>
            <RowStyle BackColor="#99CCFF" />
        </asp:GridView>
    </form>
</asp:Content>
