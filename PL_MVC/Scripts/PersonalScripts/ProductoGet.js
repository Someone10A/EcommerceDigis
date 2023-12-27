function sumarValor() {
    document.getElementById('inputValor').stepUp();
}

function restarValor() {
    var input = document.getElementById('inputValor');
    if (parseInt(input.value) > 1) {
        input.stepDown();
    }
}


function agregarAlCarrito(Id) {

    var Cantidad = document.getElementById("inputValor");
    var PrecioProducto = document.getElementById("PrecioProducto");
    var IdProducto = document.getElementById("IdProducto");

    //window.location.href = `/CarritoCompra/AddToCar?UserName=${Nombre[0].id},${Cantidad.value},${IdProducto}`;
    window.location.href = `/Carrito/AddToCar?Orden=${Cantidad.value},${IdProducto.textContent}`;
}