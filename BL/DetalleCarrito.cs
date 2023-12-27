using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DetalleCarrito
    {
        public ML.Result DetalleCarritoDelete(int IdDetalleCarrito)
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
                            var query = context.CarritoDetalleDelete(IdDetalleCarrito);
                            if (query >0)
                            {
                                result.Correct = true;
                                result.Message = "Producto Eliminado del carrito";
                            }
                            else 
                            {
                                transaction.Rollback();
                                result.Correct = false;
                                result.Message = "No se pudo eliminar el producto del carrito";
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
