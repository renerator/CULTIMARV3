function EditaSeguimientoInicialSemilla(
    IdSeguimientoSemilla,
    IdRegistroLarval,
    IdTipoContenedorOrigen,
    FechaRegistro,
    IdMortalidad,
    FactoresMedicion,
    CantidadOrigen,
    idOrigen,
    CantidadDestino,
    IdDestino,
    IdTipoContenedorDestino,
    CantidadMuestra,
    VolumenMuestra,
    VolumenTotal,
    Observaciones,
    ZonaCultivo,
    CantidadMortalidad,
    litrosContenedor) 
{
    $("#IdSemilla").val(IdSeguimientoSemilla);
    $("#NombreCultivo").val(IdRegistroLarval);
    $("#selectZonaCultivo").val(ZonaCultivo);
    $("#selectOrigen").val(IdTipoContenedorOrigen);
    $("#single_cal1").val(FechaRegistro);
    $("#selectMortalidad").val(IdMortalidad);
    $("#FactorM").val(FactoresMedicion);
    $("#CantidadOrigen").val(CantidadOrigen);
    $("#CalibreOrigen").val(idOrigen);
    $("#CantidadDestino").val(CantidadDestino)
    $("#CalibreDestino").val(IdDestino);
    $("#selectDestino").val(IdTipoContenedorDestino);
    $("#cantidadMuestra").val(CantidadMuestra);
    $("#VolumenMuestra").val(VolumenMuestra);
    $("#volumenTotal").val(VolumenTotal);
    $("#txtObservaciones").val(Observaciones);
    $("#CantidadMortalidad").val(CantidadMortalidad);
    $("#litrosContenedor").val(litrosContenedor);
}


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




$(document).ready(function () {

    $("#tblSeguimientosSemilla").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    $("#cantidadMuestra").val(0);
    $("#VolumenMuestra").val(0);
    $("#volumenTotal").val(0);
    $("#litrosContenedor").val(0);

    $("#VolumenMuestra").change(function () {
        //var suma = $("#cantidadMuestra").val() * $("#VolumenMuestra").val() * $("#litrosContenedor").val() * 1000;
        var volumen = $("#VolumenMuestra").val();
        var cantidad = $("#cantidadMuestra").val();
        var litros = $("#litrosContenedor").val();
        litros = litros.replace(",", ".");
        var suma = (((cantidad * 1000) / volumen)) * litros;
        var decimal = suma.toFixed(0);
        $("#volumenTotal").val(decimal);
    });
    $("#cantidadMuestra").change(function () {
        //var suma = $("#cantidadMuestra").val() * $("#VolumenMuestra").val() * $("#litrosContenedor").val() * 1000;
        var volumen = $("#VolumenMuestra").val();
        var cantidad = $("#cantidadMuestra").val();
        var litros = $("#litrosContenedor").val();
        litros = litros.replace(",", ".");
        var suma = (((cantidad * 1000) / volumen)) * litros;
        var decimal = suma.toFixed(0);
        $("#volumenTotal").val(decimal);
    });
    
    $("#litrosContenedor").change(function () {
        //var suma = $("#cantidadMuestra").val() * $("#VolumenMuestra").val() * $("#VolumenMuestra").val() * 1000;
        var volumen = $("#VolumenMuestra").val();
        var cantidad = $("#cantidadMuestra").val();
        var litros = $("#litrosContenedor").val();
        litros = litros.replace(",", ".");
        var suma = (((cantidad * 1000) / volumen)) * litros;
        var decimal = suma.toFixed(0);
        $("#volumenTotal").val(decimal);
    });



    $("#btnAgregaSeguimientoSemilla").click(function () {
        $("#IdSemilla").val("");
        $("#NombreCultivo").val("");
        $("#selectZonaCultivo").val("");
        $("#selectOrigen").val("");
        $("#selectMortalidad").val("");
        $("#CantidadOrigen").val(0);
        $("#CalibreOrigen").val("");
        $("#CantidadDestino").val(0)
        $("#CalibreDestino").val("");
        $("#selectDestino").val("");
        $("#cantidadMuestra").val(0);
        $("#VolumenMuestra").val(0);
        $("#volumenTotal").val(0);
        $("#txtObservaciones").val("");
        $("#CantidadMortalidad").val(0);
        $("#litrosContenedor").val(0);
    });


    $("#divAlert").hide();
    $("#btnGrabarDatos").click(function () {
        var ID = $("#IdSemilla").val();
        var batch = $("#NombreCultivo").val();
        var zonaCultivo = $("#selectZonaCultivo").val();
        var contenedorOrigen = $("#selectOrigen").val();
        var fechaRegistro = formateaFecha($("#single_cal1").val());
        var tipoMortalidad = $("#selectMortalidad").val();
        var factoresMedicion = $("#FactorM").val();
        var cantidadOrigen = $("#CantidadOrigen").val();
        var calibreOrigen = $("#CalibreOrigen").val();
        var cantidadDestino = $("#CantidadDestino").val();
        var calibreDestino = $("#CalibreDestino").val();
        var contenedorDestino = $("#selectDestino").val();
        var cantidadMuestra = $("#cantidadMuestra").val();
        var volumenMuestra = $("#VolumenMuestra").val();
        var volumenTotal = $("#volumenTotal").val();
        var observaciones = $("#txtObservaciones").val();
        var cantidadMortalidad = $("#CantidadMortalidad").val();
        var litrosContenedor = $("#litrosContenedor").val();
        volumenTotal = volumenTotal.replace(".", ",");

        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }

        $.ajax({
            url: "GrabaDatosSeguimientoSemilla",
            type: "POST",
            data: {
                _ID: ID,
                _batch: batch,
                _zonaCultivo: zonaCultivo,
                _contenedorOrigen: contenedorOrigen,
                _fechaRegistro: fechaRegistro,
                _tipoMortalidad: tipoMortalidad,
                _factoresMedicion: factoresMedicion,
                _cantidadOrigen: cantidadOrigen,
                _calibreOrigen: calibreOrigen,
                _cantidadDestino: cantidadDestino,
                _calibreDestino: calibreDestino,
                _contenedorDestino: contenedorDestino,
                _cantidadMuestra: cantidadMuestra,
                _volumenMuestra: volumenMuestra,
                _volumenTotal: volumenTotal,
                _litrosContenedor: litrosContenedor,
                _observaciones: observaciones,
                _cantidadMortalidad: cantidadMortalidad
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
            }
        });
    });


});