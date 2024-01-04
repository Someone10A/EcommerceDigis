using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pedido
    {
        public static ML.Result PedidoGetByUsuario(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var queryConsulta = context.PedidoGetByUsuario(IdUsuario).ToList();
                    if (queryConsulta != null || queryConsulta.Count > 0)
                    {
                        ML.Pedido pedidoGeneral = new ML.Pedido();
                        pedidoGeneral.Pedidos = new List<object>();
                        foreach (var itemPedido in queryConsulta)
                        {
                            ML.Pedido pedido = new ML.Pedido();
                            pedido.IdPedido = itemPedido.Value;
                            var queryPedido = context.PedidoGetByIdPedido(pedido.IdPedido).FirstOrDefault();
                            if (queryPedido != null)
                            {
                                var itemResultadoPedido = queryPedido;
                                pedido.Usuario = new ML.Usuario();
                                pedido.Usuario.IdUsuario = itemResultadoPedido.IdUsuario.Value;
                                pedido.Estatus = new ML.Estatus();
                                pedido.Estatus.IdEstatus = itemResultadoPedido.IdEstatus.Value;
                                pedido.Estatus.Nombre = itemResultadoPedido.Nombre;
                                pedido.Estatus.Descripcion = itemResultadoPedido.Descripcion;
                                pedido.Fecha = itemResultadoPedido.Fecha.Value;
                                pedido.Total = itemResultadoPedido.Total.Value;


                                result.Object = pedidoGeneral;
                                result.Correct = true;
                                result.Message = "Pedidos Consultados";
                            }
                            else
                            {
                                result.Correct = false;
                                result.Message = "No se pudo recuperar un pedido";
                            }
                            pedidoGeneral.Pedidos.Add(pedido);
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No hay pedidos recuperados";
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
        public static ML.Result Inutil(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var queryConsulta = context.PedidoGetByUsuario(IdUsuario).ToList();
                    if (queryConsulta != null || queryConsulta.Count > 0)
                    {
                        ML.Pedido pedidoGeneral = new ML.Pedido();
                        pedidoGeneral.Pedidos = new List<object>();
                        foreach (var itemPedido in queryConsulta)
                        {
                            ML.Pedido pedido = new ML.Pedido();
                            pedido.IdPedido = itemPedido.Value;
                            var queryPedido = context.PedidoGetByIdPedido(pedido.IdPedido).FirstOrDefault();
                            if (queryPedido != null)
                            {
                                var itemResultadoPedido = queryPedido;
                                pedido.Usuario = new ML.Usuario();
                                pedido.Usuario.IdUsuario = itemResultadoPedido.IdUsuario.Value;
                                pedido.Estatus = new ML.Estatus();
                                pedido.Estatus.IdEstatus = itemResultadoPedido.IdEstatus.Value;
                                pedido.Estatus.Nombre = itemResultadoPedido.Nombre;
                                pedido.Estatus.Descripcion = itemResultadoPedido.Descripcion;
                                pedido.Fecha = itemResultadoPedido.Fecha.Value;
                                pedido.Total = itemResultadoPedido.Total.Value;

                                var queryDetallePedido = context.PedidoDetalleGetByPedido(pedido.IdPedido).ToList();
                                if (queryDetallePedido != null)
                                {
                                    pedido.DetallesPedidos = new List<object>();
                                    foreach (var itemDetalle in queryDetallePedido)
                                    {
                                        ML.DetallePedido detalle = new ML.DetallePedido();
                                        detalle.IdDetallePedido = itemDetalle.IdDetallePedido;
                                        detalle.Pedido = new ML.Pedido();
                                        detalle.Pedido.IdPedido = itemDetalle.IdPedido.Value;
                                        detalle.Producto = new ML.Producto();
                                        detalle.Producto.IdProducto = itemDetalle.IdProducto;
                                        detalle.Producto.Nombre = itemDetalle.Nombre;
                                        detalle.Producto.Imagen = itemDetalle.Imagen;
                                        detalle.PrecioVendido = itemDetalle.PrecioVendido.Value;
                                        detalle.Cantidad = itemDetalle.Cantidad.Value;
                                        detalle.SubTotal = itemDetalle.Cantidad.Value * itemDetalle.PrecioVendido.Value;

                                        pedido.DetallesPedidos.Add(detalle);
                                    }
                                }
                                result.Object = pedidoGeneral;
                                result.Correct = true;
                                result.Message = "Pedidos Consultados";
                            }
                            else
                            {
                                result.Correct = false;
                                result.Message = "No se pudo recuperar un pedido";
                            }
                            pedidoGeneral.Pedidos.Add(pedido);
                        }

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No hay pedidos recuperados";
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
        public static ML.Result AddPedido(int IdCarrito)
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
                            var consultaCarrito = context.CarritoGetByCarrito(IdCarrito).SingleOrDefault();

                            if (consultaCarrito != null)
                            {
                                var itemCarrito = consultaCarrito;
                                ML.Pedido pedido = new ML.Pedido();
                                pedido.Usuario = new ML.Usuario();
                                pedido.Usuario.IdUsuario = itemCarrito.IdUsuario.Value;
                                pedido.Fecha = DateTime.Now;

                                var crearPedido = context.PedidoAdd(pedido.Usuario.IdUsuario, pedido.Fecha);

                                if (crearPedido > 0)
                                {
                                    var consultaPedido = context.PedidoGetByStatus(pedido.Usuario.IdUsuario,1).SingleOrDefault();
                                    if (consultaPedido != null)
                                    {
                                        var idPedido = consultaPedido;

                                        var consultaCarritoDetalle = context.CarritoDetalleGetByCarrito(IdCarrito).ToList();

                                        if (consultaCarritoDetalle != null)
                                        {
                                            pedido.DetallesPedidos = new List<object>();

                                            foreach (var itemConsultaDetalle in consultaCarritoDetalle)
                                            {
                                                ML.DetallePedido detalle = new ML.DetallePedido();
                                                detalle.Pedido = new ML.Pedido();
                                                detalle.Pedido.IdPedido = idPedido.Value;
                                                detalle.Producto = new ML.Producto();
                                                detalle.Producto.IdProducto = itemConsultaDetalle.IdProducto.Value;

                                                detalle.Cantidad = itemConsultaDetalle.Cantidad.Value;

                                                detalle.PrecioVendido = BL.Producto.GetPrecio(detalle.Producto.IdProducto);

                                                detalle.SubTotal = detalle.Cantidad * detalle.PrecioVendido;

                                                pedido.DetallesPedidos.Add(detalle);
                                            }

                                            foreach (var itemAdd in pedido.DetallesPedidos)
                                            {
                                                ML.DetallePedido detalleAdd = (ML.DetallePedido)itemAdd;
                                                var addItem = context.PedidoDetalleAdd(detalleAdd.Pedido.IdPedido, detalleAdd.Producto.IdProducto, detalleAdd.Cantidad, detalleAdd.SubTotal, detalleAdd.PrecioVendido);

                                                if (addItem < 1)
                                                {
                                                    throw new ApplicationException("No se añadió algo al pedido, y se canceló la operación");
                                                }
                                            }

                                            var vaciarCarrito = context.CarritoEmpty(IdCarrito);
                                            if (vaciarCarrito > 0)
                                            {
                                                var EliminarCarrito = context.CarritoDelete(IdCarrito);
                                                if (EliminarCarrito > 0)
                                                {
                                                    var consultaTotal = context.PedidoGetPrecios(idPedido).ToList();

                                                    if (consultaTotal != null)
                                                    {
                                                        decimal total = 0;
                                                        foreach (var item in consultaTotal)
                                                        {
                                                            string precioNormal = item.ToString();
                                                            total = total + decimal.Parse(precioNormal);
                                                        }

                                                        var setTotal = context.PedidoUpdateTotal(idPedido, total);
                                                        if (setTotal > 0)
                                                        {
                                                            var updateStatus = context.PedidoUpdateEstatus(idPedido, 2);

                                                            if (updateStatus > 0) 
                                                            {
                                                                transaction.Commit();
                                                                result.Correct = true;
                                                                result.Message = "Se creó satisfactoriamente el pedido";
                                                            }
                                                            else
                                                            {
                                                                transaction.Rollback();
                                                                result.Correct = false;
                                                                result.Message = "Hubo un error al actualizar el estatus del pedido";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            transaction.Rollback();
                                                            result.Correct = false;
                                                            result.Message = "Hubo un error al asignar el total";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        transaction.Rollback();
                                                        result.Correct = false;
                                                        result.Message = "No pudieron consultarse los precios para asignar el total";
                                                    }

                                                }
                                                else
                                                {
                                                    transaction.Rollback();
                                                    result.Correct = false;
                                                    result.Message = "No pudo eliminarse el carrito";
                                                }
                                            }
                                            else
                                            {
                                                transaction.Rollback();
                                                result.Correct = false;
                                                result.Message = "No pudo vaciarse el carrito";
                                            }
                                        }
                                        else
                                        {
                                            transaction.Rollback();
                                            result.Correct = false;
                                            result.Message = "No pudo consultarse el carrito";
                                        }

                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        result.Correct = false;
                                        result.Message = "No pudo consultar el pedido";
                                    }
                                }
                                else
                                {
                                    transaction.Rollback();
                                    result.Correct = false;
                                    result.Message = "No pudo crear el pedido";
                                }
                            }
                            else
                            {
                                transaction.Rollback();
                                result.Correct = false;
                                result.Message = "No pudo consultarse el carrito";
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.PedidoGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var itemResultadoPedido in query)
                        {
                            ML.Pedido pedido = new ML.Pedido();

                            pedido.IdPedido = itemResultadoPedido.IdPedido;
                            pedido.Usuario = new ML.Usuario();
                            pedido.Usuario.IdUsuario = itemResultadoPedido.IdUsuario.Value;
                            pedido.Estatus = new ML.Estatus();
                            pedido.Estatus.IdEstatus = itemResultadoPedido.IdEstatus.Value;
                            pedido.Estatus.Nombre = itemResultadoPedido.Nombre;
                            pedido.Estatus.Descripcion = itemResultadoPedido.Descripcion;
                            pedido.Fecha = itemResultadoPedido.Fecha.Value;
                            pedido.Total = itemResultadoPedido.Total.Value;

                            result.Objects.Add(pedido);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudieron consultar los Pedidos";
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
