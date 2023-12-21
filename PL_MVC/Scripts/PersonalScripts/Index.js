$(document).ready(function () {
    GetProductos();
    
});

function GetProductos() {
    $('.row').empty();
    $.ajax({
        type: 'GET',
        url: '/Home/GetProductos',
        dataType: 'json',
        success: function (response) {
            var productos = JSON.parse(response);
            $.each(productos, function (i, productos) {
                var idProducto = productos.IdProducto;
                var imagen = productos.Imagen;
                var nombre = productos.Nombre;
                var precio = parseFloat(productos.Precio);
                var cardTemplate = `
                        <div class="col-md-3">
		                    <div class="cardProduct" id="${idProducto}" onclick="ProductoGet(this.id)">
		                        <div class="cardProductHead">
		                            <img src="data:image;base64,${imagen}" class="img-fluid rounded-start" alt="${nombre}" >
		                        </div>
		                        <div class="cardProductBody">
                                    <div class="nombreProducto"> 
                                        <p>${nombre}</p>
                                    </div>
		                            <div class="precioProducto">
                                        <p>$ ${precio}.00</p>
                                    </div>
		                        </div>
		                    </div>
	                   </div>
                    `;

                $(".row").append(cardTemplate);
            });
            limitarNombre();
        },
        error: function (ex) {
            console.log("Adiós");
            alert('Error: ' + ex.status + ' - ' + ex.statusText);
        },
        complete: function (jqXHR, textStatus) {
            console.log("Complete - " + textStatus);
            console.log(jqXHR);
        }

    });
}


function limitarNombre() {
    var nombreParrafos = document.querySelectorAll('.nombreProducto p');

    var limiteCaracteres = 65;

    nombreParrafos.forEach(function (parrafo) {
        if (parrafo.textContent.length > limiteCaracteres) {
            var textoRecortado = parrafo.textContent.substring(0, limiteCaracteres) + "...";
            parrafo.textContent = textoRecortado;
        }
    });
}

function ProductoGet(Id) {
    window.location.href = `/Home/ProductoGet?Id=${Id}`;
}