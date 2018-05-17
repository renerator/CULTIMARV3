function EditaOrigen(idOrigen, nombreOrigen) {
    $("#Idorigen").val(idOrigen);
    $("#nombreOrigen").val(nombreOrigen);
}

function EditaDestino(idDestino, nombreDestino) {
    $("#IdDestino").val(idDestino);
    $("#nombreDestino").val(nombreDestino);
}

function EditaEspecies(idEspecies, nombreEspecies) {
    $("#IdEspecies").val(idEspecies);
    $("#nombreEspecies").val(nombreEspecies);
}

function EditaTipoContenedor(idTipoContenedor, nombreContenedor, tipoContenedor){
    $("#IdTipoContenedor").val(idTipoContenedor);
    $("#nombreContenedor").val(nombreContenedor);
    $("#tipoContenedor").val(tipoContenedor);
}

function EditaTipoIdentificacion(idTipoIdentificacion, nombreIdentificacion) {
    $("#idTipoIdentificacion").val(idTipoIdentificacion);
    $("#nombreTipoIdentificacion").val(nombreIdentificacion);
}

function EditaTipoMortalidad(idTipoMortalidad, nombreMortalidad) {
    $("#idTipoMortalidad").val(idTipoMortalidad);
    $("#nombreTipoMortalidad").val(nombreMortalidad);
}
function EditaTipoSistema(idtipoSistema, nombreSistema) {
    $("#idTipoSistema").val(idtipoSistema);
    $("#nombreTipoSistema").val(nombreSistema);
}

function EditaUbicacion(idUbicacion, nombreUbicacion)
{
    $("#IdtipoAlimento").val(idUbicacion);
    $("#nombreTipoAlimento").val(nombreUbicacion);
}

function EditaAlimento(idAlimento, nombreAlimento, idTipoAlimento)
{
    $("#IdAlimento").val(idAlimento);
    $("#nombreAlimento").val(nombreAlimento);
    $("#selectTipoAlimento").val(idTipoAlimento);
}

function EditaCalibre(idCalibre, nombreCalibre, descripcionCalibre)
{
    $("#idCalibre").val(idCalibre);
    $("#nombreCalibre").val(nombreCalibre);
    $("#descripcionCalibre").val(descripcionCalibre);
}

function EditaDestinoDespacho(idDestinoDespacho, nombreDestino)
{
    $("#idDestinoDespacho").val(idDestinoDespacho);
    $("#nombreDestinoDespacho").val(nombreDestino);
}

$(document).ready(function () {
    
    
    $("#tblParametrosCalibre").DataTable();

    $("#tblParametrosAlimentos").DataTable();
    
    $("#tblParametrosTipoAlimentos").DataTable();
   
    $("#tblParametrosTipoSistema").DataTable();

    $("#tblParametrosTipoMortalidad").DataTable();

    $("#tblParametrosTipoIdentificacion").DataTable();

    $("#tblParametrosTipoContenedor").DataTable();

    $("#tblParametrosOrigen").DataTable();

    $("#tblParametrosEspecies").DataTable();

    $("#tblParametrosDestino").DataTable();

    $("#tblParametrosDestinoDespacho").DataTable();

    //GrabaParametroCalibre(int idCalibre, string nombrecalibre, string descripcionCalibre)
    //btnGrabaDestinoDespacho

    $("#btnGrabaDestinoDespacho").click(function () {
        var ID = $("#idDestinoDespacho").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaDestinoDespacho",
            type: "POST",
            data: { idDestinoDespacho: ID, nombreDestinoDespacho: $("#nombreDestinoDespacho").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalDestinoDespacho").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });


    $("#btnGrabarParametrosCalibre").click(function () {
        var ID = $("#idCalibre").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroCalibre",
            type: "POST",
            data: { idCalibre: ID, nombreCalibre: $("#nombreCalibre").val(), descripcionCalibre: $("#descripcionCalibre").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalCalibre").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });


    
    $("#btnGrabarParametrosTipoAlimento").click(function () {

       
        var nombreUbicacion = $("#nombreTipoAlimento").val();


        var ID = $("#IdtipoAlimento").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroAlimento",
            type: "POST",
            data: { idAlimento: ID, nombreAlimento: nombreUbicacion},
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalAlimentos").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });

    //$("#btnGrabarParametrosTipoAlimento").click(function () {
    //    var ID = $("#IdtipoAlimento").val();
    //    if (ID != null && ID != "") {
    //        ID = ID;
    //    }
    //    else {
    //        ID = -1;
    //    }
    //    $.ajax({
    //        url: "GrabaParametroTipoAlimento",
    //        type: "POST",
    //        data: { idTipoAlimento: ID, nombreTipoAlimento: $("#nombreTipoAlimento").val(), descripcionTipoAlimento: $("#descripcionTipoAlimento").val() },
    //        async: true,
    //        success: function (data) {
    //            if (data == 1) {
    //                $("#btnCerrarModalTipoAlimento").click();
    //                alert("El Ingreso se ha realizado sin problemas.");
    //            }
    //            if (data == 2) {
    //                alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
    //            }
    //            if (data == 3) {
    //                alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
    //            }
    //            if (data == -1) {
    //                top.location.href = 'ErrorPage?error=101';
    //            }
    //            if (data == 0) {
    //                alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
    //            }
    //        }
    //    });
    //});

    $("#btnGrabarParametrosTipoSistema").click(function () {
        var ID = $("#idTipoSistema").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroTipoSistema",
            type: "POST",
            data: { idTipoSistema: ID, nombreSistema: $("#nombreTipoSistema").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalTipoSistema").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });
    
    $("#btnGrabarParametrosTipoMortalidad").click(function () {
        var ID = $("#idTipoMortalidad").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroTipoMortalidad",
            type: "POST",
            data: { idTipoMortalidad: ID, nombreMortalidad: $("#nombreTipoMortalidad").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalTipoMortalidad").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });
    
    $("#btnGrabarParametrosTipoIdentificacion").click(function () {
        var ID = $("#idTipoIdentificacion").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroTipoIdentificacion",
            type: "POST",
            data: { idTipoIdentificacion: ID, nombreIdentificacion: $("#nombreTipoIdentificacion").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalTipoIdentificacion").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });
    
    $("#btnGrabarParametrosTipoContenedor").click(function () {
        var ID = $("#IdTipoContenedor").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroTipoContenedor",
            type: "POST",
            data: { idContenedor: ID, nombreContenedor: $("#nombreContenedor").val(), tipoContenedor : $("#tipoContenedor").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalTipoContenedor").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });

    $("#btnGrabarParametrosEspecies").click(function () {
        var ID = $("#IdEspecies").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroEspecie",
            type: "POST",
            data: { idEspecie: ID, nombreEspecie: $("#nombreEspecies").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalEspecies").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });

    $("#btnGrabarParametrosOrigen").click(function () {
        var ID = $("#Idorigen").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametroOrigen",
            type: "POST",
            data: { idOrigen: ID, nombreOrigen: $("#nombreOrigen").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalOrigen").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });
    $("#btnGrabarParametrosDestino").click(function () {
        var ID = $("#IdDestino").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        $.ajax({
            url: "GrabaParametrosDestino",
            type: "POST",
            data: { idDestino: ID, nombreDestino: $("#nombreDestino").val() },
            async: true,
            success: function (data) {
                if (data == 1) {
                    $("#btnCerrarModalDestino").click();
                    alert("El Ingreso se ha realizado sin problemas.");
                }
                if (data == 2) {
                    alert("No se puede grabar el dato en la BD, intentalo nuevamente.");
                }
                if (data == 3) {
                    alert("El nombre del parametro no puede estar vacio, no se ha realizado la operación.");
                }
                if (data == -1) {
                    top.location.href = 'ErrorPage?error=101';
                }
                if (data == 0) {
                    alert("Hay un problema con el metodo de grabación, reinicia la sesión e intentalo nuevamente.");
                }
            }
        });
    });

    $("#btnAgregaUbicacion").click(function () {
        $("#IdtipoAlimento").val("");
        $("#nombreTipoAlimento").val("");
    });
    
    $("#btnNuevoDestinoDespacho").click(function () {
        $("#idDestinoDespacho").val("");
        $("#nombreDestinoDespacho").val("");
    });

});