using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class PedidoAdminController : Controller
    {
        // GET: PedidoAdmin
        public ActionResult GetAll()
        {
            ML.Result result = BL.Pedido.GetAll();
            ML.Result resultEstatus = BL.Estatus.GetAll();

            ML.Pedido pedido = new ML.Pedido();
            pedido.Pedidos = result.Objects;
            pedido.Estatus = new ML.Estatus();
            pedido.Estatus.Estatuses = resultEstatus.Objects;

            return View(pedido);
        }

        public JsonResult UpdateStatus(int IdPedido, int IdEstatus)
        {
            ML.Result result = BL.Estatus.UpdateEstatus(IdPedido, IdEstatus);

            return Json(result);
        }
    }
}