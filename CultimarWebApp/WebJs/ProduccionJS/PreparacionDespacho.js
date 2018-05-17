function EditDespacho(
    _IdPreparoDespacho,
    _FechaEnvio,
    _FechaPreparado,
    _IdOrigen,
    _IdDestino,
    _PesoNeto,
    _PesoBruto,
    _Cantidad,
    _Calibre,
    _cliente,
    _NombreOrigen,
    _NumeroLote,
    _IdDestino,
    _PesoNetoEstimado,
    _Ploidia,
    _CantidadCajas,
    _VolumenMuestra,
    _CantidadContada,
    _LitrosContenedor,
    _CantidadTotal,
    _Observaciones,
    _FechaEnvio,
    _FechaPreparado



) {
        $("#idDespacho").val(_IdPreparoDespacho),
        //$("#single_cal1").val(_FechaEnvio),
        //$("#single_cal3").val(_FechaPreparado),
        $("#selectOrigen").val(_IdOrigen),
        $("#selectDestino").val(_IdDestino),
        $("#idPesoNeto").val(_PesoNeto),
        $("#idCantidadCalibres").val(_Cantidad),
        $("#idCalibre").val(_Calibre),
        $("#idCliente").val(_cliente)
        $("#PesoBruto").val(_PesoBruto);
        $("#NombreOrigen").val(_NombreOrigen);
        $("#numeroLote").val(_NumeroLote);
        $("#selectDestino").val(_IdDestino);
        $("#PesoNetoEstimado").val(_PesoNetoEstimado);
        $("#ploidia").val(_Ploidia);
        $("#numeroCajas").val(_CantidadCajas);
        $("#VolumenMuestra").val(_VolumenMuestra);
        $("#cantidadContada").val(_CantidadContada);
        $("#litrosContenedor").val(_LitrosContenedor);
        $("#txtObservaciones").val(_Observaciones);
        $("#volumenTotal").val(_CantidadTotal);
}

function validateDecimal(valor) {
    var RE = /^\d*\,?\d*$/;
    if (RE.test(valor)) {
        return true;
    } else {
        return false;
    }
}

function validarSiNumero(numero) {
    if (!/^([0-9])*$/.test(numero)) {
        return false;
    }
    else {
        return true;
    }
}

$(document).ready(function () {
    $("#tblPreparacionDespacho").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    $("#btnNuevoDespacho").click(function () {
        $("#idDespacho").val("");
        $("#NombreOrigen").val("");
        $("#numeroLote").val(0);
        $("#selectDestino").val("");
        $("#idPesoNeto").val(0);
        $("#PesoBruto").val(0);
        $("#PesoNetoEstimado").val(0);
        $("#ploidia").val("");
        $("#numeroCajas").val(0);
        $("#idCantidadCalibres").val(0);
        $("#idCalibre").val("");
        $("#idCliente").val("");
        $("#VolumenMuestra").val(0);
        $("#cantidadContada").val(0);
        $("#litrosContenedor").val(0);
        $("#txtObservaciones").val("");
        $("#volumenTotal").val(0);
    });


    $("#VolumenMuestra").change(function () {
        var volumen = $("#VolumenMuestra").val();
        var cantidad = $("#cantidadContada").val();
        var litros = $("#litrosContenedor").val();
        var suma = (((cantidad * 1000) / volumen)) * litros;
        var decimal = suma.toFixed(3);
        $("#volumenTotal").val(decimal);
        
        
    });
    $("#cantidadContada").change(function () {
        var cantidad = $("#cantidadContada").val();
        if (validarSiNumero(cantidad)) {
            var volumen = $("#VolumenMuestra").val();
            var litros = $("#litrosContenedor").val();
            var suma = (((cantidad * 1000) / volumen)) * litros;
            var decimal = suma.toFixed(3);
            $("#volumenTotal").val(decimal);
        }
        else {
            alert("El Campo Cantidad Contada debe ser numerico");
            $("#cantidadContada").val("");
        }


        
    });

    $("#litrosContenedor").change(function () {
        var litros = $("#litrosContenedor").val();
        if (validarSiNumero(litros)) {
            var cantidad = $("#cantidadContada").val();
            var volumen = $("#VolumenMuestra").val();
            var litros = $("#litrosContenedor").val();
            var suma = (((cantidad * 1000) / volumen)) * litros;
            var decimal = suma.toFixed(3);
            $("#volumenTotal").val(decimal);
        }
        else {
            alert("El Campo Litros Contenedor debe ser numerico");
            $("#litrosContenedor").val("");
        }


    });
    /*
        A = volumen Muestra
        B = Unidades/Muestra
        C = Total Litros
        D = Total Unidades
        suma = ((cantidad*1000)/volumen)*litros
        D=(B*1000/A)*C


    */
    $("#btnGrabarDatos").click(function () {
        var ID = $("#idDespacho").val();
        var p_FechaEnvio = formateaFecha($("#single_cal1").val());
        var p_FechaPreparado = formateaFecha($("#single_cal3").val());
        var nombreOrigen = $("#NombreOrigen").val();
        var numeroLote = $("#numeroLote").val();
        var p_IdDestino = $("#selectDestino").val();
        var p_PesoNeto = $("#idPesoNeto").val();
        var p_PesoBruto = $("#PesoBruto").val();
        var p_PesoEstimado = $("#PesoNetoEstimado").val();
        var ploidia = $("#ploidia").val();
        var ncajas = $("#numeroCajas").val();
        var p_Cantidad = $("#idCantidadCalibres").val();
        var p_Calibre = $("#idCalibre").val();
        var p_Cliente = $("#idCliente").val();
        var VolumenMuestra = $("#VolumenMuestra").val();
        var CantidadContada = $("#cantidadContada").val();
        var LitrosContenedor = $("#litrosContenedor").val();
        var Observaciones = $("#txtObservaciones").val();
        var CantidadTotal = $("#volumenTotal").val();
        CantidadTotal = CantidadTotal.replace(".", ",");
        p_PesoNeto = p_PesoNeto.replace(".", ",");
        p_PesoEstimado = p_PesoEstimado.replace(".", ",");
        p_PesoBruto = p_PesoBruto.replace(".", ",");
        CantidadContada = CantidadContada.replace(".", ",");
        LitrosContenedor = LitrosContenedor.replace(".", ",");

        if (!validateDecimal(p_PesoNeto) || !validateDecimal(p_PesoEstimado) || !validateDecimal(p_PesoBruto) || !validateDecimal(CantidadContada) || !validateDecimal(LitrosContenedor)) {
            alert("Los campos Peso Neto, Peso Estimado, Peso Bruto, Cantidad Contada y Litros en el Contenedor, son campo decimal que debe ser separado por COMA (,) con formato 00,000");
        }
        else {
            if (ID != null && ID != "") {
                ID = ID;
            }
            else {
                ID = -1;
            }

            $.ajax({
                url: "GrabaPdespacho",
                type: "POST",
                data: {
                    _IdPreparoDespacho: ID,
                    _p_FechaEnvio: p_FechaEnvio,
                    _p_FechaPreparado: p_FechaPreparado,
                    _nombreOrigen: nombreOrigen,
                    _numeroLote: numeroLote,
                    _p_IdDestino: p_IdDestino,
                    _p_PesoNeto: p_PesoNeto,
                    _p_PesoBruto: p_PesoBruto,
                    _p_PesoEstimado: p_PesoEstimado,
                    _ploidia: ploidia,
                    _ncajas: ncajas,
                    _p_Cantidad: p_Cantidad,
                    _p_Calibre: p_Calibre,
                    _p_Cliente: p_Cliente,
                    _VolumenMuestra: VolumenMuestra,
                    _CantidadMuestra: 0,
                    _CantidadContada: CantidadContada,
                    _LitrosContenedor: LitrosContenedor,
                    _Observaciones: Observaciones,
                    _CantidadTotal: CantidadTotal
                },
                async: true,
                success: function (data) {
                    if (data == 1) {
                        $("#btnCerrarModal").click();
                        alert("El Ingreso se ha realizado sin problemas.");
                        window.location.reload(true);
                    }
                    if (data == 3) {
                        alert("Ha ocurrido un error al grabar los datos, intentalo nuevamente.");
                    }
                    if (data == 4) {
                        alert("No tienes permiso para modificar, Hemos enviado un correo al administrador del sistema solicitando autorización para la modificación del registro, cuando te den autorización, te llegara un Email con la información.");
                    }
                    if (data == 5) {
                        alert("Tu perfil de usuario no te permite realizar ninguna acción, solo puedes leer la información ingresada al sistema.");
                    }
                    if (data == 0) {
                        alert("No se ha realizado la acción, intentalo nuevamente.");
                    }
                },
                error: function (jqXHR, exception) {
                    console.log(jqXHR);
                    console.log(exception);
                }
            });
        }

        
        
    });


});

function formateaFecha(fechaInput) {
    var fecha = fechaInput;
    var formattedDate = new Date(fecha);
    var d = formattedDate.getDate();
    if (d < 10) {
        d = "0" + d;
    }
    var m = formattedDate.getMonth();
    m += 1;  // JavaScript months are 0-11
    if (m < 10) {
        m = "0" + m;
    }
    var y = formattedDate.getFullYear();
    fecha = d + "-" + m + "-" + y;
    return fecha;
}

function formateaFechaalReves(fechaInput) {
    var fecha = fechaInput;
    var formattedDate = new Date(fecha);
    var d = formattedDate.getDate();
    if (d < 10) {
        d = "0" + d;
    }
    var m = formattedDate.getMonth();
    m += 1;  // JavaScript months are 0-11
    if (m < 10) {
        m = "0" + m;
    }
    var y = formattedDate.getFullYear();
    fecha = m + "/" + d + "/" + y;
    return fecha;
}


