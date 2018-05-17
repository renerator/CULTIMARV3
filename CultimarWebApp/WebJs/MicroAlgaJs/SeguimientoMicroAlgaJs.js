$(document).ready(function () {
    $("#tblSeguimientoMicroAlgas").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    $("#btnGrabarDatos").click(function () {
        var fechaRegistro = formateaFecha($("#single_cal1").val());
        var fechaSalida = formateaFecha($("#single_cal2").val());
        var resultadoTCBS = $("#resultadoTCBS").is(":checked");
        if (!resultadoTCBS) {
            var respuesta = confirm("El registro se grabara con el Resultado TCBS NEGATIVO. ¿Es Correcto?");
            if (respuesta) {
                $("#resultadoTCBS").prop("checked", false);
            }
            else {
                $("#resultadoTCBS").prop("checked", true);
            }
        }
        var estadoSeguimiento = $("#estadoSeguimiento").is(":checked");
        if (!estadoSeguimiento) {
            var respuesta = confirm("El registro se grabara con el estado INACTIVO. ¿Estas seguro?");
            if (respuesta) {
                $("#estadoSeguimiento").prop("checked", false);
            }
            else {
                $("#estadoSeguimiento").prop("checked", true);
            }
        }
        var idRegistroInicial = $("#selectRegistroInicial").val();
        var idEspecie = $("#selectEspecies").val();
        var idOrigen = $("#selectOrigen").val();
        var idDestino = $("#SelectDestino").val();
        var volumenCosechado = $("#volumenCosechado").val();
        var concentracion = $("#concentracion").val();
        var obs = $("#txtObservaciones").val();
        var ID = $("#IdMicroAlga").val();
        var puntuacion = $("#selectPuntuacion").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }

        $.ajax({
            url: "GrabaSeguimientoMicroAlga",
            type: "POST",
            data: {
                IdMicroAlga: ID,
                idRegistroInicial: idRegistroInicial,
                idEspecie: idEspecie,
                fechaRegistro: fechaRegistro,
                fechaSalida: fechaSalida,
                Origen: idOrigen,
                Destino: idDestino,
                resultadoTCBS: resultadoTCBS,
                volumenCosechado: volumenCosechado,
                concentracion: concentracion,
                estadoSeguimiento: estadoSeguimiento,
                observaciones: obs,
                puntuacion: puntuacion
            },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModal").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("Debe ingresar todos los datos, no podra grabar en la BD.");
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
            error: function (xhr, textStatus, error) {
                console.log(xhr.statusText);
                console.log(textStatus);
                console.log(error);
            }
        });
    });

    $("#btnPopUpMicroAlga").click(function () {
        $("#single_cal1").val("");
        $("#single_cal2").val("");
        $("#resultadoTCBS").prop("checked", false);
        $("#estadoSeguimiento").prop("checked", false);
        $("#selectRegistroInicial").val("");
        $("#selectEspecies").val("");
        $("#selectOrigen").val("");
        $("#SelectDestino").val("");
        $("#volumenCosechado").val("");
        $("#concentracion").val("");
        $("#txtObservaciones").val("");
        $("#IdMicroAlga").val("");
        $("#selectPuntuacion").val("0");
    });
});

function EditaSeguimientoMicroAlga(idSeguimientoMicroAlga, idMicroAlga, idEspecie, fechaIngreso, fechaSalida, idOrigen, idDestino, resultadoTCBS, volumenCosechado, concentracion, estado, obs, puntuacion) {
    $("#single_cal1").val(fechaIngreso);
    $("#single_cal2").val(fechaSalida);
    if (resultadoTCBS == "onclick") {
        $("#resultadoTCBS").prop("checked", true);
    }
    else { $("#resultadoTCBS").prop("checked", false);}
    if (estado == "onclick") {
        $("#estadoSeguimiento").prop("checked", true);
    }
    else { $("#estadoSeguimiento").prop("checked", false);}
    
    $("#selectRegistroInicial").val(idMicroAlga);
    $("#selectEspecies").val(idEspecie);
    $("#selectOrigen").val(idOrigen);
    $("#SelectDestino").val(idDestino);
    $("#volumenCosechado").val(volumenCosechado);
    $("#concentracion").val(concentracion);
    $("#txtObservaciones").val(obs);
    $("#IdMicroAlga").val(idSeguimientoMicroAlga);
    $("#selectPuntuacion").val(puntuacion);

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
