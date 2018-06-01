function EditaSeguimientoMar(
_IdSeguimiento,
_IdRegistroInicial,
_IdMortalidad,
_FechaDesdoble,
_CantidadOrigen,
_IdCalibreOrigen,
_IdUbicacionOrigen,
_IdUbicacionDestino,
_IdTipoSistema,
_CantidadSistemaOrigen,
_IdSistemaOrigen,
_CantidadDestino,
_IdCalibreDestino,
_CantidadSistemaDestino,
_IdSistemaDestino,
_Observaciones,
_CantidadMuestra,
_VolumenMuestra,
_VolumenTotal,
_LitrosContenedor,
_UbicacionOceanica,
_CantidadMortalidad) {
    $("#IdRegistroSeguimiento").val(_IdSeguimiento);
    $("#NombreCultivo").val(_IdRegistroInicial);
    $("#selectTipoMortalidad").val(_IdMortalidad);
    $("#single_cal1").val(_FechaDesdoble);
    $("#CantidadOrigen").val(_CantidadOrigen);
    $("#CalibreOrigen").val(_IdCalibreOrigen);
    $("#selectTipoSistemaOrigen").val(_IdSistemaOrigen);
    $("#CantidadSistemaOrigen").val(_CantidadSistemaOrigen);
    $("#CantidadDestino").val(_CantidadDestino);
    $("#CalibreDestino").val(_IdCalibreDestino);
    $("#selectTipoSistemaDestino").val(_IdSistemaDestino);
    $("#CantidadSistemaDestino").val(_CantidadSistemaDestino);
    $("#txtObservaciones").val(_Observaciones);
    $("#selectUbicacionDestino").val(_IdUbicacionDestino);
    $("#selectUbicacionOrigen").val(_IdUbicacionOrigen);
    $("#cantidadMuestra").val(_CantidadMuestra);
    $("#VolumenMuestra").val(_VolumenMuestra);
    $("#volumenTotal").val(_VolumenTotal);
    $("#litrosContenedor").val(_LitrosContenedor);
    $("#selectubicacionOceanica").val(_UbicacionOceanica);
    $("#cantidadMortalidad").val(_CantidadMortalidad);
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

function validateDecimal(valor) {
    var RE = /^\d*\,?\d*$/;
    if (RE.test(valor)) {
        return true;
    } else {
        return false;
    }
}


$(document).ready(function () {
    $("#tblRegistroSeguimientoMar").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json"
        }
    });
    $("#btnPopUpRegistroSeguimientoMar").click(function () {
        $("#IdRegistroSeguimiento").val("");
        $("#NombreCultivo").val("");
        $("#selectTipoMortalidad").val("");
        $("#CantidadOrigen").val("");
        $("#CalibreOrigen").val("");
        $("#selectTipoSistemaOrigen").val("");
        $("#CantidadSistemaOrigen").val("");
        $("#CantidadDestino").val("");
        $("#CalibreDestino").val("");
        $("#selectTipoSistemaDestino").val("");
        $("#CantidadSistemaDestino").val("");
        $("#txtObservaciones").val("");
        $("#selectUbicacionDestino").val("");
        $("#selectUbicacionOrigen").val("");
        $("#cantidadMuestra").val(0);
        $("#VolumenMuestra").val(0);
        $("#volumenTotal").val(0);
        $("#litrosContenedor").val(0);
        $("#cantidadMortalidad").val(0);
        $("#selectubicacionOceanica").val("");

    });
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



    $("#btnGrabarDatos").click(function () {
        var ID = $("#IdRegistroSeguimiento").val();
        var IdRegistroInicial = $("#NombreCultivo").val();
        var IdMortalidad = $("#selectTipoMortalidad").val();
        var FechaDesdoble = formateaFecha($("#single_cal1").val());
        var CantidadOrigen = $("#CantidadOrigen").val();
        var IdCalibreOrigen = $("#CalibreOrigen").val();
        var IdUbicacionOrigen = $("#selectUbicacionOrigen").val();
        var CantidadSistemaOrigen = 0;//$("#CantidadSistemaOrigen").val();
        var IdSistemaOrigen = $("#selectTipoSistemaOrigen").val();
        var CantidadDestino = $("#CantidadDestino").val();
        var IdCalibreDestino = $("#CalibreDestino").val();
        var IdUbicacionDestino = $("#selectUbicacionDestino").val();
        var CantidadSistemaDestino = $("#CantidadSistemaDestino").val();
        var IdSistemaDestino = $("#selectTipoSistemaDestino").val();
        var Observaciones = $("#txtObservaciones").val();
        var CantidadMuestra = $("#cantidadMuestra").val();
        var VolumenMuestra = $("#VolumenMuestra").val();
        var VolumenTotal = $("#volumenTotal").val();
        var LitrosContenedor = $("#litrosContenedor").val();
        var ubicacionOceanica = $("#selectubicacionOceanica").val();
        var cantidadMortalidad = $("#cantidadMortalidad").val();
        VolumenTotal = VolumenTotal.replace(".", ",");
        LitrosContenedor = LitrosContenedor.replace(".", ",");

        if (!validateDecimal(CantidadOrigen) || !validateDecimal(CantidadDestino) || !validateDecimal(LitrosContenedor)) {
            alert("El campo Cantidad de Origen, LitrosContenedor y Cantidad Destino son campo decimal que debe ser separado por COMA (,) con formato 00,000");
        }
        else {
            if (ID != null && ID != "") {
                ID = ID;
            }
            else {
                ID = -1;
            }

            $.ajax({
                url: "GrabaSeguimientoMar",
                type: "POST",
                data: {
                    _IdSeguimiento: ID,
                    _IdRegistroInicial: IdRegistroInicial,
                    _IdMortalidad: IdMortalidad,
                    _FechaDesdoble: FechaDesdoble,
                    _CantidadOrigen: CantidadOrigen,
                    _IdCalibreOrigen: IdCalibreOrigen,
                    _IdUbicacionOrigen: IdUbicacionOrigen,
                    _CantidadSistemaOrigen: CantidadSistemaOrigen,
                    _IdSistemaOrigen: IdSistemaOrigen,
                    _CantidadDestino: CantidadDestino,
                    _IdCalibreDestino: IdCalibreDestino,
                    _IdUbicacionDestino: IdUbicacionDestino,
                    _CantidadSistemaDestino: CantidadSistemaDestino,
                    _IdSistemaDestino: IdSistemaDestino,
                    _Observaciones: Observaciones,
                    _CantidadMuestra: CantidadMuestra,
                    _VolumenMuestra: VolumenMuestra,
                    _VolumenTotal: VolumenTotal,
                    _LitrosContenedor: LitrosContenedor,
                    _UbicacionOceanica: ubicacionOceanica,
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
        }
        
        
    });

});
