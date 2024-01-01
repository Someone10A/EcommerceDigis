using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["SesionActiva"] == null)
            { 
                Session["SesionActiva"] = null;
            }
           
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public JsonResult GetProductos()
        {
            
            var result = BL.Producto.GetIndexEF();

            var json = JsonConvert.SerializeObject(result.Objects);

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ProductoGet(int Id)
        {
            ML.Result resultSubCategoria = BL.SubCategoria.GetSubCategoriasByCategoria();
            ML.Result resultProveedores = BL.Proveedor.GetAllEF();
            ML.Result result = BL.Producto.GetByIdEF(Id);

            ML.Producto producto = (ML.Producto)result.Object;
            
            producto.SubCategoria.SubCategorias = resultSubCategoria.Objects;
            producto.Proveedor.Proveedores = resultProveedores.Objects;
            return View(producto);
        }
        public ActionResult Login(string email, string password)
        {
            if (email == "" || password == "")
            {
                ViewBag.Error = "Debes llenar todos los campos";
                return View();
            }
            else
            {
                ML.Result result = BL.Usuario.Login(email, password);
                if (result.Correct)
                {
                    

                    ML.Result resultSesion = BL.Usuario.GetSesion(email);
                    Session["SesionActiva"] = (ML.Sesion)resultSesion.Object;

                    //string resultNombre = BL.Usuario.GetNombre(email);
                    //Session["UserName"] = resultNombre;
                    //int resultRol = BL.Usuario.GetRol(email);
                    //Session["Rol"] = resultRol;


                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "La contraseña no coincide";
                    return View();
                }
                
            }
        }
        public ActionResult Logout()
        {
            Session["SesionActiva"] = null;
            return RedirectToAction("Index");
        }
    }
}