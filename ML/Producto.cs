using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioDolares { get; set; }
        public int Valoraciones { get; set; }
        public string Comentarios { get; set; }
        public string KeyWords { get; set; }
        public byte[] Imagen { get; set; }
        public SubCategoria SubCategoria { get; set; }
        public Proveedor Proveedor { get; set; }
        public int EnCurso { get; set; }
        public int Ventas { get; set; }
        public List<object> Productos { get; set; }
    }
}
