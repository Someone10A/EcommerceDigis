using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllEF();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }
        public ActionResult Form(int? IdUsuario)
        {

            ML.Usuario usuario = new ML.Usuario();
            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Roles = resultRol.Objects;
            ML.Result resultEstado = BL.Estado.GetAllEF();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Municipio = new ML.Municipio();
            usuario.Direccion.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Municipio.Estado.Estados = resultEstado.Objects;

            if (IdUsuario == null)
            {
                ViewBag.Accion = "Agregar Usuario";
            }
            else
            {
                ViewBag.Accion = "Actualizar Usuario";
            }
            return View(usuario);
        }
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);

        }
    }
}
