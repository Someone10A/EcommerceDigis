//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL_EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleCarrito
    {
        public int IdDetalleCarrito { get; set; }
        public Nullable<int> IdCarrito { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public Nullable<int> Cantidad { get; set; }
    
        public virtual Carrito Carrito { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
