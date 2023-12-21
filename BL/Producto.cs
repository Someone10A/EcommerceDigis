using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                   
                    var query = context.ProductoAdd(producto.Nombre, producto.Marca, producto.Descripcion, producto.Stock,producto.Precio,producto.Valoraciones, producto.Comentarios, producto.KeyWords, producto.Imagen, producto.SubCategoria.IdSubCategoria, producto.Proveedor.IdProveedor);

                    if (query > 0)
                    {
                        result.Message = "Producto añadido correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se pudo añadir el producto";
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
        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {

                    var query = context.ProductoUpdate(producto.IdProducto,producto.Nombre, producto.Marca, producto.Descripcion, producto.Stock, producto.Precio, producto.Valoraciones, producto.Comentarios, producto.KeyWords, producto.Imagen, producto.SubCategoria.IdSubCategoria, producto.Proveedor.IdProveedor, producto.EnCurso,producto.Ventas);
                    if (query > 0)
                    {
                        result.Message = "Producto actualizado correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se pudo actualizar el producto";
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
        public static ML.Result DeleteEF(int idProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProductoDelete(idProducto);
                    if (query > 0)
                    {
                        result.Message = "Producto eliminado correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se pudo eliminar el producto";
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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProductoGetAll();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.NombreProducto;
                            producto.Marca = item.Marca;
                            //producto.Descripcion = item.Descripcion;
                            producto.Descripcion = item.Descripcion != null ? item.Descripcion : " ";

                            producto.Stock = item.Stock.Value;
                            producto.Precio = item.Precio.Value;
                            producto.Valoraciones = item.Valoraciones.Value;
                            producto.Comentarios = item.Comentarios;
                            producto.KeyWords = item.KeyWords;
                            producto.Imagen = item.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = item.IdSubCategoria.Value;
                            producto.SubCategoria.Nombre  = item.NombreSubCategoria;
                            producto.SubCategoria.Categoria = new ML.Categoria();
                            producto.SubCategoria.Categoria.IdCategoria = item.IdSubCategoria.Value;
                            producto.SubCategoria.Categoria.Nombre = item.NombreCategoria;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = item.IdProveedor != null ? item.IdProveedor.Value : 0;
                            producto.Proveedor.Nombre = item.NombreProveedor != null ? item.NombreProveedor : "Sin proveedor registrado";
                            producto.EnCurso = item.EnCurso.Value;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron productos";
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
        public static ML.Result GetByIdEF(int idProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProductoGetById(idProducto).FirstOrDefault();

                    if (query != null)
                    {
                        var item = query;

                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.NombreProducto;
                            producto.Marca = item.Marca;
                            //producto.Descripcion = item.Descripcion;
                            producto.Descripcion = item.Descripcion != null ? item.Descripcion : " ";

                            producto.Stock = item.Stock.Value;
                            producto.Precio = item.Precio.Value;
                            producto.Valoraciones = item.Valoraciones.Value;
                            producto.Comentarios = item.Comentarios;
                            producto.KeyWords = item.KeyWords;
                            producto.Imagen = item.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = item.IdSubCategoria.Value;
                            producto.SubCategoria.Nombre = item.NombreSubCategoria;
                            producto.SubCategoria.Categoria = new ML.Categoria();
                            producto.SubCategoria.Categoria.IdCategoria = item.IdSubCategoria.Value;
                            producto.SubCategoria.Categoria.Nombre = item.NombreCategoria;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = item.IdProveedor != null ? item.IdProveedor.Value : 0;
                            producto.Proveedor.Nombre = item.NombreProveedor != null ? item.NombreProveedor : "Sin proveedor registrado";
                            producto.EnCurso = item.EnCurso.Value;

                            result.Object = producto;
                        
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron productos";
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
        public static ML.Result GetIndexEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.ProductoGetIndex();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = item.IdProducto;
                            producto.Nombre = item.NombreProducto;
                            producto.Marca = item.Marca;
                            //producto.Descripcion = item.Descripcion;
                            producto.Descripcion = item.Descripcion != null ? item.Descripcion : " ";

                            producto.Stock = item.Stock.Value;
                            producto.Precio = item.Precio.Value;
                            producto.Valoraciones = item.Valoraciones.Value;
                            producto.Comentarios = item.Comentarios;
                            producto.KeyWords = item.KeyWords;
                            producto.Imagen = item.Imagen;
                            producto.SubCategoria = new ML.SubCategoria();
                            producto.SubCategoria.IdSubCategoria = item.IdSubCategoria.Value;
                            producto.SubCategoria.Nombre = item.NombreSubCategoria;
                            producto.SubCategoria.Categoria = new ML.Categoria();
                            producto.SubCategoria.Categoria.IdCategoria = item.IdSubCategoria.Value;
                            producto.SubCategoria.Categoria.Nombre = item.NombreCategoria;
                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = item.IdProveedor != null ? item.IdProveedor.Value : 0;
                            producto.Proveedor.Nombre = item.NombreProveedor != null ? item.NombreProveedor : "Sin proveedor registrado";
                            producto.EnCurso = item.EnCurso.Value;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron productos";
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
