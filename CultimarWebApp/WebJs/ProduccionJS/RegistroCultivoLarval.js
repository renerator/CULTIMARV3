/**
 * 
 * @param {any} idCultivoLarval
 * @param {any} idRegistro
 * @param {any} idMortalidad
 * @param {any} CantidadLarvas
 * @param {any} CosechaLarvas
 * @param {any} DensidadCultivo
 * @param {any} FactoresMedicion
 * @param {any} idEstanqueOrigen
 * @param {any} idEstanqueDestino
 * @param {any} idCalibre
 * @param {any} cantidadMortalidad
 * @param {any} obs
 */
function EditaSeguimientoLarval(idCultivoLarval, idRegistro,idMortalidad,CantidadLarvas,CosechaLarvas,DensidadCultivo,FactoresMedicion,idEstanqueOrigen,idEstanqueDestino,idCalibre,cantidadMortalidad,obs)
{  
    $("#selectTipoM").val(idMortalidad);
    $("#selectRegistroInicial").val(idRegistro);
    $("#IdCultivoLarval").val(idCultivoLarval);
    $("#CantidadLarvas").val(CantidadLarvas);
    $("#CosechaLarvas").val(CosechaLarvas);
    $("#selectOrigen").val(idEstanqueOrigen);
    $("#selectDestino").val(idEstanqueDestino);
    $("#selectCalibre").val(idCalibre);
    $("#DensidadCultivo").val(DensidadCultivo);
    $("#FactorM").val(FactoresMedicion);
    $("#cantidadMortalidad").val(cantidadMortalidad);
    $("#txtObservaciones").val(obs);
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

    $("#btnNuevoSeguimiento").click(function () {
        $("#selectTipoM").val("");
        $("#selectRegistroInicial").val("");
        $("#IdCultivoLarval").val("");
        $("#CantidadLarvas").val("");
        $("#CosechaLarvas").val("");
        $("#selectOrigen").val("");
        $("#selectDestino").val("");
        $("#selectCalibre").val("");
        $("#DensidadCultivo").val("");
        $("#cantidadMortalidad").val("");
        $("#txtObservaciones").val("");
    });


    $("#tblLarvas").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    }); 

    $("#btnGrabarDatos").click(function () {
        var calibre = $("#selectCalibre").val();
        var idRegistro = $("#selectRegistroInicial").val();
        var estanqueOrigen = $("#selectOrigen").val();
        var estanqueDestino = $("#selectDestino").val();
        var cantidadMortalidad = $("#cantidadMortalidad").val();
        var obs = $("#txtObservaciones").val();
        var ID = $("#IdCultivoLarval").val();
        var cantidadLarvas = $("#CantidadLarvas").val();
        var cosechaLarvas = validateDecimal($("#CosechaLarvas").val());
        var densidadCultivo = validateDecimal($("#DensidadCultivo").val());

        var cosecha = $("#CosechaLarvas").val();
        var densidad = $("#DensidadCultivo").val();


        var Factores = $("#FactorM").val();
        var tipoMortalidad = $("#selectTipoM").val();

        if (!cosechaLarvas || !densidadCultivo) {
            alert("El campo Densidad Cultivo y Cosecha Larvas es un campo decimal que debe ser separado por COMA (,) con formato 00,000");
            
        }
        else {
            if (ID != null && ID != "") {
                ID = ID;
            }
            else {
                ID = -1;
            }
            $.ajax({
                url: "GrabaDatosLarval",
                type: "POST",
                data: {
                    _idCultivoLarval: ID,
                    _idRegistro: idRegistro,
                    _CantidadLarvas: cantidadLarvas,
                    _CosechaLarvas: cosecha,
                    _NumeroEstanque: 0,
                    _DensidadCultivo: densidad,
                    _IdFactoresM: Factores,
                    _selectTipoM: tipoMortalidad,
                    _idCalibre: calibre,
                    _idEstanqueOrigen: estanqueOrigen,
                    _idEstanqueDestino: estanqueDestino,
                    _cantidadMortalidad: cantidadMortalidad,
                    _observaciones: obs
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
        }

        
    });


});
 