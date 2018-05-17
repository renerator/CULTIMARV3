
function EditaFijacion(
    _IdSeguimientoFijacion,
    _IdCultivo,
    _FechaRegistro,
    _LarvasCantidad,
    _LarvasCalibre,
    _FijacionCantidad,
    _FijacionCalibre,
    _CosechaSemilla,
    _SemillaCalibre,
    _CosechaCantidad,
    _NumeroEstanque,
    _DensidadSiembra,
    _IdMortalidad,
    _CantidadMortalidad,
    _Observaciones
) {
    $("#IdSeguimientoFijacion").val(_IdSeguimientoFijacion);
    $("#selectNombreCultivo").val(_IdCultivo);
    $("#selectCalibreLarvas").val(_LarvasCalibre);
    $("#cantidadLarvas").val(_LarvasCantidad);
    $("#cantidadFijacion").val(_FijacionCantidad);
    $("#selectCalibreFijación").val(_FijacionCalibre);
    $("#cosechaSemillas").val(_CosechaSemilla);
    $("#selectCalibreSemillas").val(_SemillaCalibre);
    $("#cantidadSemillas").val(_CosechaCantidad);
    $("#idNumeroEstanque").val(_NumeroEstanque);
    $("#IdDensidadSiembra").val(_DensidadSiembra);
    $("#selectTipoM").val(_IdMortalidad);
    $("#IdCantidadMortalidad").val(_CantidadMortalidad);
    $("#txtObservaciones").val(_Observaciones);
}


$(document).ready(function () {



    $("#tblSeguimientosFijacion").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    $("#btnNuevaFijacion").click(function () {
        $("#IdSeguimientoFijacion").val("");
        $("#selectNombreCultivo").val("");
        $("#selectCalibreLarvas").val("");
        $("#cantidadLarvas").val("");
        $("#cantidadFijacion").val("");
        $("#selectCalibreFijación").val("");
        $("#cosechaSemillas").val("");
        $("#selectCalibreSemillas").val("");
        $("#cantidadSemillas").val("");
        $("#idNumeroEstanque").val("");
        $("#IdDensidadSiembra").val("");
        $("#selectTipoM").val("");
        $("#IdCantidadMortalidad").val("");
        $("#txtObservaciones").val("");
    });


    $("#divAlert").hide();
    $("#btnGrabarDatos").click(function () {
        var ID = $("#IdSeguimientoFijacion").val();
        var idCultivo = $("#selectNombreCultivo").val();
        var FechaRegistro = formateaFecha($("#single_cal1").val());
        var LarvasCalibre = $("#selectCalibreLarvas").val();
        var LarvasCantidad = $("#cantidadLarvas").val();
        var CantidadFijacion = $("#cantidadFijacion").val();
        var CalibreFijacion = $("#selectCalibreFijación").val();
        var CosechaSemillas = $("#cosechaSemillas").val();
        var CalibreSemillas = $("#selectCalibreSemillas").val();
        var CantidadSemillas = $("#cantidadSemillas").val();
        var NumeroEstanque = $("#idNumeroEstanque").val();
        var DensidadSiembra = $("#IdDensidadSiembra").val();
        var IdMortalidad = $("#selectTipoM").val();
        var CantidadMortalidad = $("#IdCantidadMortalidad").val();
        var FactoresMedicion = $("#FactorM").val();
        var Observaciones = $("#txtObservaciones").val();




        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }

        $.ajax({
            url: "GrabaSeguimientoFijacion",
            type: "POST",
            data: {
                _IdSeguimientoFijacion: ID,
                _idCultivo: idCultivo,
                _FechaRegistro: FechaRegistro,
                _LarvasCalibre: LarvasCalibre,
                _LarvasCantidad: LarvasCantidad,
                _CantidadFijacion: CantidadFijacion,
                _CalibreFijacion: CalibreFijacion,
                _CosechaSemillas: CosechaSemillas,
                _CalibreSemillas: CalibreSemillas,
                _CantidadSemillas: CantidadSemillas,
                _NumeroEstanque: NumeroEstanque,
                _DensidadSiembra: DensidadSiembra,
                _IdMortalidad: IdMortalidad,
                _CantidadMortalidad: CantidadMortalidad,
                _FactoresMedicion: FactoresMedicion,
                _Observaciones: Observaciones
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