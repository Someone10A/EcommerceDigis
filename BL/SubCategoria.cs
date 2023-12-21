using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SubCategoria
    {
        public static ML.Result GetSubCategoriasByCategoria()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.SubCategoriaGetByCategoria(1);
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.SubCategoria subCategoria = new ML.SubCategoria();
                            subCategoria.IdSubCategoria = item.IdSubCategoria;
                            subCategoria.Categoria = new ML.Categoria();
                            subCategoria.Categoria.IdCategoria = (int)item.IdCategoria;
                            subCategoria.Nombre = item.Nombre;
                            subCategoria.Descripcion = item.Descripcion != null ? item.Descripcion : " ";

                            result.Objects.Add(subCategoria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron subcategorias";
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
