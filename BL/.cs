using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {
        public int? IdEstado { get; set; }
        public string NombreEstado { get; set; }
        public List<object> Estados { get; set; }
    }
}
