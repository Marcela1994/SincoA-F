<%@ Page Title="" Language="C#" MasterPageFile="~/navbar.Master" AutoEventWireup="true" CodeBehind="nuevo_pedido.aspx.cs" Inherits="SincoAF_project.nuevo_pedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function validarFecha(fecha) {
            var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
            if ((fecha.match(RegExPattern)) && (fecha != '')) {
                return true;
            } else {
                return false;
            }
        }

        function validarCantidad() {
            var cantidadElemento = "<%=txt_cantidad.ClientID%>";
            var cantidad = document.getElementById(cantidadElemento).value;
            var RegExPattern = /^([0-9])*$/;
            if ((cantidad.match(RegExPattern)) && (cantidad != '')) {
                return true;
            } else {
                alert('No ha ingresado la cantidad');
                return false;
            }
        }

        function validarFormulario() {
            try {
                var conceptoElemento = "<%=txt_conceptoPedido.ClientID%>";
                var concepto = document.getElementById(conceptoElemento).value;
                alert('concepto:' + concepto);
                if (concepto.length == undefined) {
                    alert('No ha ingresado el concepto');
                    return false;
                }
                var fechaPedidoElemento = "<%=txt_fechaPedido.ClientID%>";
                var fechaPedido = document.getElementById(fechaPedidoElemento).value;

                if (fechaPedido == undefined) {
                    alert('No ingreso la Fecha');
                    return false;
                }
                if (!validarFecha(fechaPedido)) {
                    alert('La fecha no esta en un formato valido DD/MM/YYYY');
                    return false;
                }
                return true;
            } catch (error) {
                alert(error);
            }
        }
    </script>

    <form id="formularioPedido" runat="server">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="usuario">USUARIO:</label>
                <asp:DropDownList runat="server" ID="ddl_usuarios" Height="39px" Width="200px"></asp:DropDownList>
            </div>
            <div class="form-group col-md-3">
                <label for="fecha">FECHA</label>
                <asp:TextBox type="text" ID="txt_fechaPedido" runat="server" placeHolder="DD/MM/AAAA"></asp:TextBox>
            </div>
        </div>
        <div class="form-group">
            <label for="concepto">CONCEPTO</label>
            <asp:TextBox type="text" ID="txt_conceptoPedido" runat="server" placeHolder="Concepto del pedido" Width="788px"></asp:TextBox>
        </div>
        <div class="form-group">

            <table class="table">
                <thead class="thead-dark">
                    <tr>
                        <th colspan="4">DETALLE DEL PEDIDO</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <th>
                            <label for="articulo">ARTICULO:&nbsp;&nbsp; </label>
                            &nbsp;<asp:DropDownList runat="server" ID="ddl_articulos" Height="33px" Width="134px"></asp:DropDownList>
                        </th>
                        <td>
                            <div>
                                <label for="cantidad">CANTIDAD</label>
                                <asp:TextBox type="text" ID="txt_cantidad" runat="server"></asp:TextBox>
                            </div>
                        </td>
                        <td>
                            <div class="form-check">
                                &nbsp;<asp:CheckBox ID="cb_importado" runat="server" Text="IMPORTADO" />
                            </div>
                        </td>
                        <td>
                            <asp:Button ID="btnAgregarArticulo" CssClass="btn btn-primary" Text="AGREGAR ARTICULO" runat="server" OnClientClick="return validarCantidad()" OnClick="btnAgregarArticulo_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>



        </div>

        <center><asp:GridView ID="gr_articulosPedido" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField AccessibleHeaderText="Id_Producto" DataField="Id_Producto" HeaderText="ID PRODUCTO" />
                <asp:BoundField AccessibleHeaderText="Nombre_Producto" DataField="Nombre_Producto" HeaderText="NOMBRE PRODUCTO" />
                <asp:BoundField AccessibleHeaderText="Cantidad" DataField="Cantidad" HeaderText="CANTIDAD" />
                <asp:BoundField AccessibleHeaderText="Importado" DataField="Importado" HeaderText="IMPORTADO" />
            </Columns>
            <RowStyle BackColor="#99CCFF" />
        </asp:GridView></center>
        <hr class="p-2" />
        <asp:Button ID="Button1" CssClass="btn-primary m-1" Text="CREAR PEDIDO" runat="server" OnClientClick="return validarFormulario()" OnClick="crearPedido_click" />
        
        
    </form>
</asp:Content>
