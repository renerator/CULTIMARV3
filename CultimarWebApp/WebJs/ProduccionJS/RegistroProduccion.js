
function EditaProduccion(IdRegistroProduccion,
    idTipoIdentificacion,
    CantidadProductoresMachos,
    CantidadProductoresHembras,  
    CantidadFecundada,
    NumeroDesoveTemporada,
    CantidadSembrada,
    IdFactor,
    NumeroEstanquesUtilizado,
    DensidadSiembra,
    Observaciones) {

    var factores = IdFactor.split(',');
    var substr = factores;
    $.each(substr, function (index, val) {
        $("#FactorM").val(val);
    });
    
    $("#IdRegistro").val(IdRegistroProduccion);
    $("#selectNombreBatch").val(idTipoIdentificacion);
    $("#CantidadPMachos").val(CantidadProductoresMachos);
    $("#CantidadPHembras").val(CantidadProductoresHembras); 
    $("#CantidadFecundada").val(CantidadFecundada);
    $("#NroDesoveTemporada").val(NumeroDesoveTemporada);
    $("#CantidadSembrada").val(CantidadSembrada);
    $("#NroEstanque").val(NumeroEstanquesUtilizado);
    $("#DensidadSiembra").val(DensidadSiembra); 
    $("#txtObservaciones").val(Observaciones);
}

function validateDecimal(valor) {
    var RE = /^\d*\,?\d*$/;
    if (RE.test(valor)) {
        return true;
    } else {
        return false;
    }
}

$(document).ready(function () {
    $("#tblRegistroProduccion").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });

    


    $("#btnNuevo").click(function () {
        $("#IdRegistro").val("");
        $("#selectNombreBatch").val("");
        $("#CantidadPMachos").val("");
        $("#CantidadPHembras").val("");
        $("#CantidadFecundada").val("");
        $("#NroDesoveTemporada").val("");
        $("#CantidadSembrada").val("");
        $("#NroEstanque").val("");
        $("#DensidadSiembra").val(""); 
        $("#txtObservaciones").val("");
    });

    $("#btnGrabarDatos").click(function () {
        
        var factores = $("#FactorM").val();
        var densidad = validateDecimal($("#DensidadSiembra").val());
        if (!densidad) {
            alert("El campo Densidad Siembra es un campo decimal que debe ser separado por COMA (,) con formato 00,000");
        }
        else {
            var ID = $("#IdRegistro").val();
            if (ID != null && ID != "") {
                ID = ID;
            }
            else {
                ID = -1;
            }
            $.ajax({
                url: "GrabaDatosRegistroProduccion",
                type: "POST",
                data: {
                    _IdProduccion: ID,
                    _idTipoIdentificacion: $("#selectNombreBatch").val(),
                    _CantidadProductoresMachos: $("#CantidadPMachos").val(),
                    _CantidadProductoresHembras: $("#CantidadPHembras").val(),
                    _CantidadFecundada: $("#CantidadFecundada").val(),
                    _NumeroDesoveTemporada: $("#NroDesoveTemporada").val(),
                    _CantidadSembrada: $("#CantidadSembrada").val(),
                    _FactoresMedicion: factores,//$("#FactorM").val(),
                    _NumeroEstanquesUtilizado: $("#NroEstanque").val(),
                    _DensidadSiembra: $("#DensidadSiembra").val(),
                    _Observaciones: $("#txtObservaciones").val()
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
                error: function (xhr) { console.log(xhr.statusText); }
            });
        }
        
    });


});

