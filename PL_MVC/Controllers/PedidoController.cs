using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Index()
        {
            ML.Sesion sesionActiva = (ML.Sesion)Session["SesionActiva"];
            ML.Result result = BL.Pedido.PedidoGetByUsuario(sesionActiva.IdUsuario);
            ML.Pedido pedido = result.Correct ? (ML.Pedido)result.Object : new ML.Pedido();
            return View(pedido); 
        }
    }
}