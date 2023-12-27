using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {
            ML.Sesion sesionActiva = (ML.Sesion)Session["SesionActiva"];
            ML.Result result = BL.Carrito.CarritoGetByUsuario(sesionActiva.IdUsuario);
            ML.Carrito carrito = result.Correct ? (ML.Carrito)result.Object : new ML.Carrito();
            return View(carrito);
        }
        public ActionResult AddToCar(string Orden) 
        {
            ML.Sesion sesionActiva = (ML.Sesion)Session["SesionActiva"];
            string[] OrdenList = Orden.Split(',');
            ML.Orden orden = new ML.Orden();
            orden.Usuario = new ML.Usuario();
            orden.Usuario.IdUsuario = sesionActiva.IdUsuario;
            orden.Cantidad = int.Parse(OrdenList[0]);
            orden.Producto = new ML.Producto();
            orden.Producto.IdProducto = int.Parse(OrdenList[1]);

            ML.Result result = BL.Carrito.CarritoAdd(orden);
            ViewBag.Mensaje = result.Message;
            return View("Modal");
        }
    }
}