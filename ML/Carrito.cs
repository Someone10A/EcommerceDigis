using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Carrito
    {
        public int IdCarrito { get; set; }
        public ML.Usuario Usuario { get; set; }
        public List<object> Detalles { get; set; }
    }
}
