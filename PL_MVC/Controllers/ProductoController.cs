using ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetIndexEF();
            producto.Productos = result.Objects;
            return View(producto);
        }
        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result resultSubCategoria = BL.SubCategoria.GetSubCategoriasByCategoria();
            ML.Result resultProveedores = BL.Proveedor.GetAllEF();
            
            if (IdProducto == 0 || IdProducto == null)
            {
                ViewBag.Accion = "Agregar Producto";
                producto.SubCategoria = new ML.SubCategoria();
                producto.Proveedor = new ML.Proveedor();
            }
            else
            {
                ViewBag.Accion = "Actualizar Producto";
                ML.Result result = BL.Producto.GetByIdEF(IdProducto.Value);
                producto = (ML.Producto)result.Object;
            }
            producto.SubCategoria.SubCategorias = resultSubCategoria.Objects;
            producto.Proveedor.Proveedores = resultProveedores.Objects;
            return View(producto);
        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto, HttpPostedFileBase fuImagen)
        {
            ML.Result result = new ML.Result();
            if ((producto.Imagen != null && fuImagen != null) || (producto.Imagen == null && fuImagen != null))
            {
                producto.Imagen = convertFileToByteArray(fuImagen);
            }

            if (producto.IdProducto == 0)
            {
                result = BL.Producto.AddEF(producto);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha ingresado correctamente el producto";

                }
                else
                {
                    ViewBag.Mensaje = "No se ingreso, ocurrio " + result.Message;
                }
                return View("Modal");
            }
            else
            {
                result = BL.Producto.UpdateEF(producto);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Se ha actualizado correctamente el producto";

                }
                else
                {
                    ViewBag.Mensaje = "No se actulizo, ocurrio " + result.Message;
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