using ML;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;


namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            ML.Result result = BL.Usuario.GetAllEF();
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }
        [HttpGet]
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
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                    usuario.Direccion.Municipio.Estado.Estados = resultEstado.Objects;
                    usuario.Rol.Roles = resultRol.Objects;
                    string fecha = usuario.FechaNacimiento.ToString();
                    string[] fechaParse = fecha.Split('/');
                    fecha = fechaParse[2] + "-" + fechaParse[1] + "-" + fechaParse[0];
                    usuario.FechaNacimiento = fecha;
                    ML.Result resultMunicipios = BL.Municipio.GetByIdEstado(usuario.Direccion.Municipio.Estado.IdEstado);
                    usuario.Direccion.Municipio.Municipios = resultMunicipios.Objects;
                }
                else
                {
                    return View("Modal");
                }
            }
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Form([Bind(Exclude = "idUsuario")] ML.Usuario usuario, HttpPostedFileBase fuImagen)
        {
            {
                ML.Result result = new ML.Result();

                if (ModelState.IsValid)
                {
                    if ((usuario.Imagen != null && fuImagen != null) || (usuario.Imagen == null && fuImagen != null))
                    {
                        usuario.Imagen = convertFileToByteArray(fuImagen);
                    }

                    if (usuario.IdUsuario == 0)
                    {
                        result = BL.Usuario.AddEF(usuario);

                        if (result.Correct)
                        {
                            ViewBag.Mensaje = "Se ha ingresado correctamente al usuario";

                        }
                        else
                        {
                            ViewBag.Mensaje = "No se ingreso, ocurrio " + result.Message;
                        }
                        return View("Modal");
                    }
                    else
                    {
                        if (usuario.Direccion.IdDireccion == 0 || usuario.Direccion.IdDireccion == null)
                        {
                            usuario.Accion = 0;
                        }
                        else
                        {
                            usuario.Accion = 1;
                        }
                        result = BL.Usuario.UpdateEF(usuario);
                        if (result.Correct)
                        {
                            ViewBag.Mensaje = "Se ha actualizado correctamente al usuario";
                        }
                        else
                        {
                            ViewBag.Mensaje = "No se pudo actualizar";
                        }
                        return View("Modal");
                    }
                }
                else
                {
                    ML.Result resultRol = BL.Rol.GetAllEF();
                    usuario.Rol = new ML.Rol();
                    usuario.Rol.Roles = resultRol.Objects;

                    ML.Result resultEstado = BL.Estado.GetAllEF();
                    usuario.Direccion.Municipio.Estado.Estados = resultEstado.Objects;
                    return View(usuario);
                }
            }
        }

        [HttpPost]
        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);
        }
        public byte[] convertFileToByteArray(HttpPostedFileBase fuImagen)
        {
            MemoryStream target = new MemoryStream();
            fuImagen.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }
    }
}