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
    
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            this.DetallePedidoes = new HashSet<DetallePedido>();
            this.DetalleCarritoes = new HashSet<DetalleCarrito>();
        }
    
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public Nullable<int> Stock { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> Valoraciones { get; set; }
        public string Comentarios { get; set; }
        public string KeyWords { get; set; }
        public byte[] Imagen { get; set; }
        public Nullable<int> IdSubCategoria { get; set; }
        public Nullable<int> IdProveedor { get; set; }
        public Nullable<int> EnCurso { get; set; }
        public Nullable<int> Vendidos { get; set; }
    
        public virtual Proveedor Proveedor { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedidoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCarrito> DetalleCarritoes { get; set; }
    }
}
