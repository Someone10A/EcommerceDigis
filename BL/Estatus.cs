using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatus
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.EstatusGetAll().ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Estatus estatus = new ML.Estatus();
                            estatus.IdEstatus = item.IdEstatus;
                            estatus.Nombre = item.Nombre;
                            estatus.Descripcion = item.Descripcion;

                            result.Objects.Add(estatus);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudieron consultar los estatus";
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
        public static ML.Result UpdateEstatus(int IdPedido, int IdEstatus)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.PedidoUpdateEstatus(IdPedido, IdEstatus);
                    if (query > 0)
                    {
                        result.Message = "Se ha actualizado el estatus exitosamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se pudo cambiar el estatus";
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
