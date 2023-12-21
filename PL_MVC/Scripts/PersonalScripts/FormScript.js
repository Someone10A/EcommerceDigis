$(document).ready(function () {
    $("#ddlEstado").change(function () {
        $("#ddlMunicipio").empty();
        $.ajax({
            type: 'POST',
            url: '/Usuario/GetMunicipio',
            dataType: 'json',
            data: { IdEstado: $("#ddlEstado").val() },
            success: function (municipios) {
                $("#ddlMunicipio").append('<option value="0">' + '--Seleccione un Municipio--' + '</option>');
                $.each(municipios, function (i, municipios) {
                    $("#ddlMunicipio").append('<option value="'
                        + municipios.IdMunicipio + '">'
                        + municipios.Nombre + '</option>');
                });
            },
            error: function (ex) {
                alert('Failed.' + ex);
            }
        });
    });
    
});

function PreviewImagen(event) {

    var output = document.getElementById('imgUsuario');
    output.src = URL.createObjectURL(event.target.files[0]);
    output.onload = function () {
        URL.revokeObjectURL(output.src)//free memoryxd
    }
}