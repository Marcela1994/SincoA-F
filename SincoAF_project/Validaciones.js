function validarFecha(fecha) {
    var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
    if ((fecha.match(RegExPattern)) && (fecha != '')) {
        return true;
    } else {
        return false;
    }
}

function validarFormulario() {
    try {
        var conceptoElemento = "<%=txt_conceptoPedido.ClientID%>";
        var concepto = document.getElementById(conceptoElemento).value;
        alert(concepto.lenght);
        if (concepto.lenght == undefined || concepto.lenght < 1) {
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
        alert(error)
    }
}