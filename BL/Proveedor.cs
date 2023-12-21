
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Proveedor
    {
        public static ML.Result AddEF( ML.Proveedor proveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProveedorAdd(proveedor.Nombre, proveedor.Direccion, proveedor.Telefono, proveedor.Email, proveedor.SitioWeb, proveedor.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Proveedor añadido";
                    }
                    else 
                    {
                        result.Correct = false;
                        result.Message = "No se pudo ingresar al proveeedor";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
                //throw;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Proveedor proveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProveedorUpdate(proveedor.IdProveedor,proveedor.Nombre, proveedor.Direccion, proveedor.Telefono, proveedor.Email, proveedor.SitioWeb, proveedor.Imagen);
                    if (query > 0)
                    {
                        result.Correct = true;
                        result.Message = "Proveedor actualizado";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo actualizar al proveeedor";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
                //throw;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProductoDelete(IdProveedor);
                    if (query >0)
                    {
                        result.Correct = true;
                        result.Message = "Se ha eliminado al proveedor";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha podido eliminar al proveedor";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message= ex.Message;
                //throw;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProveedorGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            
                            ML.Proveedor proveedor = new ML.Proveedor();
                            proveedor.IdProveedor = item.IdProveedor;
                            proveedor.Nombre = item.Nombre != null ? item.Nombre : " ";

                            proveedor.Direccion = item.Direccion;
                            proveedor.Telefono = item.Telefono;
                            proveedor.Email = item.Email;
                            proveedor.SitioWeb = item.SitioWeb;
                            proveedor.Imagen = item.Imagen;


                            result.Objects.Add(proveedor);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron proveedores";
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
                //throw;
            }
            return result;
        }
        public static ML.Result GetByIdEF(int IdProveedor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProveedorById(IdProveedor).FirstOrDefault();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        var item = query;

                        ML.Proveedor proveedor = new ML.Proveedor();
                            proveedor.IdProveedor = item.IdProveedor;
                            proveedor.Nombre = item.Nombre != null ? item.Nombre : " ";

                            proveedor.Direccion = item.Direccion;
                            proveedor.Telefono = item.Telefono;
                            proveedor.Email = item.Email;
                            proveedor.SitioWeb = item.SitioWeb;
                            proveedor.Imagen = item.Imagen;


                            result.Object = proveedor;
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron proveedores";
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
                //throw;
            }
            return result;
        }
    }
}
