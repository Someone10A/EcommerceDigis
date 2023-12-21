using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Proveedor proveedor = new ML.Proveedor();
            ML.Result result = BL.Proveedor.GetAllEF();
            proveedor.Proveedores = result.Objects;
            return View(proveedor);
        }
        [HttpGet]
        public ActionResult Form(int? IdProveedor)
        {
            ML.Proveedor proveedor = new ML.Proveedor();
            if (IdProveedor == 0 || IdProveedor == null)
            {
                ViewBag.Accion = "Agregar Proveedor";
            }
            else
            {   
                ViewBag.Accion = "Actualizar Proveedor";
                ML.Result result = BL.Proveedor.GetByIdEF(IdProveedor.Value);
                proveedor = (ML.Proveedor)result.Object;
            }
                return View(proveedor);
        }
        [HttpPost]
        public ActionResult Form(ML.Proveedor proveedor, HttpPostedFileBase fuImagen)
        {
            if ((proveedor.Imagen != null && fuImagen != null) || (proveedor.Imagen == null && fuImagen != null))
            {
                proveedor.Imagen = convertFileToByteArray(fuImagen);
            }
            ML.Result result = new ML.Result();
            if (proveedor.IdProveedor == 0)
            {
                result = BL.Proveedor.AddEF(proveedor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha ingresado correctamente al proveedor";

                }
                else
                {
                    ViewBag.Mensaje = "No se ingreso, ocurrio " + result.Message;
                }
                return View("Modal");
            }
            else
            {
                result = BL.Proveedor.UpdateEF(proveedor);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente al proveedor";

                }
                else
                {
                    ViewBag.Mensaje = "No se actualizo, ocurrio " + result.Message;
                }
                return View("Modal");
            }
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