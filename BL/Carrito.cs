using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{   
    public class Carrito
    {
        public static ML.Result CarritoGetByUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    using (var transaction =context.Database.BeginTransaction())
                    {
                        try
                        {
                            var queryConsulta = context.CarritoGetByUsuario(IdUsuario).FirstOrDefault();
                            if (queryConsulta != null)
                            {
                                ML.Carrito carrito = new ML.Carrito();
                                carrito.IdCarrito = queryConsulta.Value;
                                var queryGet = context.CarritoDetalleGetByCarrito(carrito.IdCarrito).ToList();
                                if (queryGet != null)
                                {
                                    carrito.Detalles = new List<object>();

                                    foreach (var item in queryGet)
                                    {
                                        ML.DetalleCarrito detalle = new ML.DetalleCarrito();
                                        detalle.IdDetalleCarrito = item.IdDetalleCarrito;
                                        detalle.Carrito = new ML.Carrito();
                                        detalle.Carrito.IdCarrito = carrito.IdCarrito;
                                        detalle.Producto = new ML.Producto();
                                        detalle.Producto.IdProducto = item.IdProducto.Value;
                                        detalle.Producto.Nombre = item.Nombre;
                                        detalle.Producto.Precio = item.Precio.Value;
                                        detalle.Producto.Imagen = item.Imagen;
                                        detalle.Producto.Stock = item.Stock.Value;
                                        detalle.Cantidad = item.Cantidad.Value;
                                        detalle.Subtotal = item.Cantidad.Value * item.Precio.Value;

                                        carrito.Detalles.Add(detalle);
                                    }
                                    result.Correct = true;
                                    result.Object = carrito;
                                    transaction.Commit();
                                }
                                else
                                {
                                    transaction.Rollback();
                                    result.Correct = false;
                                    result.Message = "No se pudieron leer los productos del carrito";
                                }
                            }
                            else
                            {
                                result.Correct = true;
                                result.Message = "No tienes ningún producto añadido";
                                transaction.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            result.Correct = false;
                            result.Ex = ex;
                            result.Message = ex.Message;
                            throw;
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result CarritoAdd(ML.Orden orden)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var queryConsulta = context.CarritoGetByUsuario(orden.Usuario.IdUsuario).FirstOrDefault();
                            if (queryConsulta != null)
                            {
                                ML.Carrito carrito = new ML.Carrito();
                                carrito.IdCarrito = queryConsulta.Value;

                                var queryAdd = context.CarritoDetalleAdd(carrito.IdCarrito, orden.Producto.IdProducto, orden.Cantidad);
                                if (queryAdd > 0)
                                {
                                    transaction.Commit();
                                    result.Correct = true;
                                    result.Message = "Se añadió un articulo al carrito satisfactoriamente";
                                }
                                else
                                {
                                    transaction.Rollback();
                                    result.Correct = false;
                                    result.Message = "No se ha podido añadir al carrito";
                                }
                            }
                            else
                            {
                                var queryAddCar = context.CarritoCreate(orden.Usuario.IdUsuario);
                                if (queryAddCar > 0)
                                {
                                    var queryConsultaNueva = context.CarritoGetByUsuario(orden.Usuario.IdUsuario).FirstOrDefault();
                                    if (queryConsultaNueva != null)
                                    {
                                        ML.Carrito carrito = new ML.Carrito();
                                        carrito.IdCarrito = queryConsultaNueva.Value;
                                        var queryAdd = context.CarritoDetalleAdd(carrito.IdCarrito, orden.Producto.IdProducto, orden.Cantidad);
                                        if (queryAdd > 0)
                                        {
                                            transaction.Commit();
                                            result.Correct = true;
                                            result.Message = "Se añadió un articulo al carrito satisfactoriamente";
                                        }
                                        else
                                        {
                                            transaction.Rollback();
                                            result.Correct = false;
                                            result.Message = "No se ha podido añadir al carrito";
                                        }
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        result.Correct = false;
                                        result.Message = "No se ha podido crear el carrito";
                                    }
                                }
                                else
                                {
                                    transaction.Rollback();
                                    result.Correct = false;
                                    result.Message = "No se ha podido crear el carrito";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            result.Correct = false;
                            result.Ex = ex;
                            result.Message = ex.Message;
                            throw;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }
            return result;
        }
        public static ML.Result DetalleCarritoDelete(int IdCarrito)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var query = context.CarritoDelete(IdCarrito);
                            if (query > 0)
                            {
                                result.Correct = true;
                                result.Message = "Carrito eliminado";
                            }
                            else
                            {
                                transaction.Rollback();
                                result.Correct = false;
                                result.Message = "No se pudo eliminar el carrito";
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            result.Correct = false;
                            result.Ex = ex;
                            result.Message = ex.Message;
                            throw;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
