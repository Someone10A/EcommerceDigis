using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration;
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
            ViewBag.Carrito = null;
            if (Session["SesionActiva"] == null)
            {
                ViewBag.SutitleModa = "Carrito";
                ViewBag.Mensaje = "Necesitas iniciar sesion primero para poder realizar esta acción";
                string[] OrdenListTest = Orden.Split(',');
                ViewBag.Carrito = OrdenListTest[1];
                return View("Modal");
            }
            ML.Sesion sesionActiva = (ML.Sesion)Session["SesionActiva"];
            string[] OrdenList = Orden.Split(',');
            ML.Orden orden = new ML.Orden();
            orden.Usuario = new ML.Usuario();
            orden.Usuario.IdUsuario = sesionActiva.IdUsuario;
            orden.Cantidad = int.Parse(OrdenList[0]);
            orden.Producto = new ML.Producto();
            orden.Producto.IdProducto = int.Parse(OrdenList[1]);

            ML.Result result = BL.Carrito.CarritoAdd(orden);
            ViewBag.SutitleModa = "Carrito";
            ViewBag.Mensaje = result.Message;
            return View("Modal");
        }

        public ActionResult AddPedido(int IdCarrito) 
        {
            ML.Result result = BL.Pedido.AddPedido(IdCarrito);
            ViewBag.Mensaje = result.Message;
            ViewBag.Subtitle = "Realizar Pedido";
            return View("Modal");
        }
    }
}