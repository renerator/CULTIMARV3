$(document).ready(function () {
    $("#tblFactoresMedicion").DataTable({
        paging: true,
        retrieve: true,
        searching: true,
        responsive: true,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/1.10.11/i18n/Spanish.json",
            "lengthMenu": "Mostrar _MENU_ filas por Página",
            "zeroRecords": "No existen Registros en el sistema",
            "info": "Mostrando página _PAGE_ de _PAGES_",
            "infoEmpty": "No se han encontrado registros",
            "infoFiltered": "(Filtrando de un total de  _MAX_ registros)"
        }
    });


    $("#btnGrabarDatos").click(function () {
        var fechaConFormato = formateaFecha($("#single_cal1").val());
        var ID = $("#idFactor").val();
        if (ID != null && ID != "") {
            ID = ID;
        }
        else {
            ID = -1;
        }
        if ($("#selectTipoCalibre").val() != "") {
            if($("#nombreFactor").val() != "")
            {
                if ($("#ploidia").val() != "") {
                    if ($("#volumen").val() != "") {
                        $.ajax({
                            url: "GrabaFactoresMedicion",
                            type: "POST",
                            data: { idFactor: ID, nombreFactor: $("#nombreFactor").val(), ultimoTamizado: fechaConFormato, idCalibre: $("#selectTipoCalibre").val(), ploidia: $("#ploidia").val(), volumen: $("#volumen").val() },
                            async: true,
                            success: function (data) {
                                if (data == 1) {
                                    $("#btnCerrarModal").click();
                                    alert("El Ingreso se ha realizado sin problemas.");
                                }
                                if (data == 0) {
                                    alert("No se ha realizado la acción, intentalo nuevamente.");
                                }
                                if (data == 2) {
                                    alert("Hubo un error al tratar de grabar el Factor de medición: " + $("#nombreFactor").val() );
                                }
                            }
                        });
                    }
                    else { alert("Debes Ingresar el Volumen del factor a ingresar"); }
                }
                else { alert("Debes Ingresar la Ploidia del factor a ingresar"); }
            }
            else { alert("Debes Ingresar el nombre del factor a ingresar"); }
        }
        else { alert("Debes seleccionar el tipo de calibre a ingresar"); }
        
    });


});


function EditaFactorMedicion(idFactor, nombreFactor, ultimoTamizado, idCalibre, ploidia, volumen)
{
    $("#idFactor").val(idFactor);
    $("#nombreFactor").val(nombreFactor);
    $("#single_cal1").val(ultimoTamizado);
    $("#selectTipoCalibre").val(idCalibre);
    $("#ploidia").val(ploidia);
    $("#volumen").val(volumen);
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