        using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PedidoUserController : Controller
    {
        // GET: PedidoUser
        public ActionResult Index()
        {
            ML.Sesion sesionActiva = (ML.Sesion)Session["SesionActiva"];
            ML.Result result = BL.Pedido.PedidoGetByUsuario(sesionActiva.IdUsuario);
            ML.Pedido pedido = new ML.Pedido();

            pedido = (ML.Pedido)result.Object;
            return View(pedido);
        }
    }
}