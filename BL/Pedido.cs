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
       
    }
}
