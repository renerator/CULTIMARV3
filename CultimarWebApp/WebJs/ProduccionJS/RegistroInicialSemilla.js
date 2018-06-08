
function EditaRegistroInicialSemilla(idRegistroInicialSemilla, idTipoContenedor, idRegistroLarval, idCalibre, FechaRegistro, FechaDesdoble, Ploidia, Muestreo, Observaciones, volumenMuestra, cantidadLitros, LitrosdecimalContenedor, CantidadTotal) {
    $("#IdRegistroInicialSemilla").val(idRegistroInicialSemilla);
    $("#selectTipoContenedor").val(idTipoContenedor);
    $("#selectRegistroInicial").val(idRegistroLarval);
    $("#selectParametroCalibre").val(idCalibre);
    $("#single_cal1").val(FechaRegistro);
    $("#single_cal2").val(FechaDesdoble);
    $("#ploidia").val(Ploidia);
    $("#muestreo").val(Muestreo);
    $("#txtObservaciones").val(Observaciones);
    $("#VolumenMuestra").val(volumenMuestra);
    $("#cantidadContada").val(cantidadLitros);
    $("#litrosContenedor").val(LitrosdecimalContenedor);
    $("#volumenTotal").val(CantidadTotal);

}


$(document).ready(function () {

    $("#tblRegistroInicialSemillas").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    $("#btnPopUpRegistroInicial").click(function () {
        $("#IdRegistroInicialSemilla").val("");
        $("#selectRegistroInicial").val("");
        $("#selectTipoContenedor").val("");
        $("#selectParametroCalibre").val("");
        $("#ploidia").val("");
        $("#muestreo").val("");
        $("#txtObservaciones").val("");
        $("#cantidadLitros").val("");
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
        var decimal = suma.toFixed(0);
        $("#volumenTotal").val(decimal);

    });
    $("#cantidadContada").change(function () {
        var cantidad = $("#cantidadContada").val();
        if (validarSiNumero(cantidad)) {
            var volumen = $("#VolumenMuestra").val();
            var litros = $("#litrosContenedor").val();
            var suma = (((cantidad * 1000) / volumen)) * litros;
            var decimal = suma.toFixed(0);
            $("#volumenTotal").val(decimal);
        }
        else {
            alert("El Campo Cantidad Contada debe ser numerico");
            $("#cantidadContada").val("");
        }
    });

    $("#litrosContenedor").change(function () {
        var litros = $("#litrosContenedor").val();
        var cantidad = $("#cantidadContada").val();
        var volumen = $("#VolumenMuestra").val();
        var litros = $("#litrosContenedor").val();
        litros = litros.replace(",", ".");
        var suma = (((cantidad * 1000) / volumen)) * litros;
        var decimal = suma.toFixed(0);
        $("#volumenTotal").val(decimal);
    });


    $("#btnGrabaRegistroInicialSemilla").click(function () {
        var ID = $("#IdRegistroInicialSemilla").val();
        var idTipoContenedor = $("#selectTipoContenedor").val();
        var idCultivo = $("#selectRegistroInicial").val();
        var idCalibre = $("#selectParametroCalibre").val();
        var FechaRegistro = formateaFecha($("#single_cal1").val());
        var FechaDesdoble = formateaFecha($("#single_cal2").val());
        var Ploidia = $("#ploidia").val();
        var Muestreo = 0;//$("#muestreo").val();
        var Obs = $("#txtObservaciones").val();
        
        var VolumenMuestra = $("#VolumenMuestra").val();
        var CantidadContada = $("#cantidadContada").val();
        var LitrosContenedor = $("#litrosContenedor").val();
        var Observaciones = $("#txtObservaciones").val();
        var CantidadTotal = $("#volumenTotal").val();
        CantidadTotal = CantidadTotal.replace(".", ",");
        CantidadContada = CantidadContada.replace(".", ",");
        LitrosContenedor = LitrosContenedor.replace(".", ",");

        
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }

        $.ajax({
            url: "GrabaRegistroInicialSemillas",
            type: "POST",
            data: {
                IdRegistroInicial: ID
                ,idTipoContenedor: idTipoContenedor
                ,idCultivo: idCultivo
                ,IdCalibre: idCalibre
                ,FechaRegistro: FechaRegistro
                ,FechaDesdoble: FechaDesdoble
                ,Ploidia: Ploidia
                ,Muestreo: Muestreo
                , Observaciones: Obs
                , cantidadLitros: CantidadContada
                , volumenMuestra: VolumenMuestra
                , _LitrosContenedor: LitrosContenedor
                , _CantidadTotal: CantidadTotal
            },
            async: true,
            success: function (data) {
                //if (data == 0) {
                //    $("#btnCerrarModal").click();
                //    alert("El Ingreso se ha realizado sin problemas.");
                //}
                if (data == 1) {
                    $("#btnCerrarModal").click();
                    alert("El Ingreso se ha realizado sin problemas.");
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
            }
        });
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
