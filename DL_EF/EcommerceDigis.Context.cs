﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EcommerceDigisEntities : DbContext
    {
        public EcommerceDigisEntities()
            : base("name=EcommerceDigisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Direccion> Direccions { get; set; }
        public virtual DbSet<Estado> Estadoes { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<SubCategoria> SubCategorias { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<Carrito> Carritoes { get; set; }
        public virtual DbSet<Estatu> Estatus { get; set; }
        public virtual DbSet<Pedido> Pedidoes { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidoes { get; set; }
        public virtual DbSet<DetalleCarrito> DetalleCarritoes { get; set; }
    
        public virtual int UsuarioDelete(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioDelete", idUsuarioParameter);
        }
    
        public virtual int UsuarioEstatusUpdate(Nullable<int> idUsuario, Nullable<bool> estatus)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var estatusParameter = estatus.HasValue ?
                new ObjectParameter("Estatus", estatus) :
                new ObjectParameter("Estatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioEstatusUpdate", idUsuarioParameter, estatusParameter);
        }
    
        public virtual ObjectResult<UsuarioGetAll_Result> UsuarioGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetAll_Result>("UsuarioGetAll");
        }
    
        public virtual ObjectResult<EstadoGetAll_Result> EstadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstadoGetAll_Result>("EstadoGetAll");
        }
    
        public virtual ObjectResult<RolGetAll_Result> RolGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<RolGetAll_Result>("RolGetAll");
        }
    
        public virtual ObjectResult<MunicipioGetByEstado_Result> MunicipioGetByEstado(Nullable<int> idEstado)
        {
            var idEstadoParameter = idEstado.HasValue ?
                new ObjectParameter("IdEstado", idEstado) :
                new ObjectParameter("IdEstado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<MunicipioGetByEstado_Result>("MunicipioGetByEstado", idEstadoParameter);
        }
    
        public virtual int UsuarioAdd(string nombre, string apellidoPaterno, string apellidoMaterno, string email, string password, string fechaNacimiento, string sexo, string celular, byte[] imagen, Nullable<int> idRol, string calle, string colonia, string codigoPostal, string numeroExterior, string numeroInterior, Nullable<int> idMunicipio)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var idMunicipioParameter = idMunicipio.HasValue ?
                new ObjectParameter("IdMunicipio", idMunicipio) :
                new ObjectParameter("IdMunicipio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioAdd", nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, passwordParameter, fechaNacimientoParameter, sexoParameter, celularParameter, imagenParameter, idRolParameter, calleParameter, coloniaParameter, codigoPostalParameter, numeroExteriorParameter, numeroInteriorParameter, idMunicipioParameter);
        }
    
        public virtual int UsuarioUpdate(Nullable<int> idUsuario, string nombre, string apellidoPaterno, string apellidoMaterno, string email, string fechaNacimiento, string sexo, string celular, byte[] imagen, Nullable<int> idRol, string calle, string colonia, string codigoPostal, string numeroExterior, string numeroInterior, Nullable<int> idMunicipio)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var apellidoPaternoParameter = apellidoPaterno != null ?
                new ObjectParameter("ApellidoPaterno", apellidoPaterno) :
                new ObjectParameter("ApellidoPaterno", typeof(string));
    
            var apellidoMaternoParameter = apellidoMaterno != null ?
                new ObjectParameter("ApellidoMaterno", apellidoMaterno) :
                new ObjectParameter("ApellidoMaterno", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var fechaNacimientoParameter = fechaNacimiento != null ?
                new ObjectParameter("FechaNacimiento", fechaNacimiento) :
                new ObjectParameter("FechaNacimiento", typeof(string));
    
            var sexoParameter = sexo != null ?
                new ObjectParameter("Sexo", sexo) :
                new ObjectParameter("Sexo", typeof(string));
    
            var celularParameter = celular != null ?
                new ObjectParameter("Celular", celular) :
                new ObjectParameter("Celular", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var calleParameter = calle != null ?
                new ObjectParameter("Calle", calle) :
                new ObjectParameter("Calle", typeof(string));
    
            var coloniaParameter = colonia != null ?
                new ObjectParameter("Colonia", colonia) :
                new ObjectParameter("Colonia", typeof(string));
    
            var codigoPostalParameter = codigoPostal != null ?
                new ObjectParameter("CodigoPostal", codigoPostal) :
                new ObjectParameter("CodigoPostal", typeof(string));
    
            var numeroExteriorParameter = numeroExterior != null ?
                new ObjectParameter("NumeroExterior", numeroExterior) :
                new ObjectParameter("NumeroExterior", typeof(string));
    
            var numeroInteriorParameter = numeroInterior != null ?
                new ObjectParameter("NumeroInterior", numeroInterior) :
                new ObjectParameter("NumeroInterior", typeof(string));
    
            var idMunicipioParameter = idMunicipio.HasValue ?
                new ObjectParameter("IdMunicipio", idMunicipio) :
                new ObjectParameter("IdMunicipio", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuarioUpdate", idUsuarioParameter, nombreParameter, apellidoPaternoParameter, apellidoMaternoParameter, emailParameter, fechaNacimientoParameter, sexoParameter, celularParameter, imagenParameter, idRolParameter, calleParameter, coloniaParameter, codigoPostalParameter, numeroExteriorParameter, numeroInteriorParameter, idMunicipioParameter);
        }
    
        public virtual ObjectResult<CategoriaGetAll_Result> CategoriaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CategoriaGetAll_Result>("CategoriaGetAll");
        }
    
        public virtual int ProductoDelete(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", idProductoParameter);
        }
    
        public virtual ObjectResult<ProveedorGetAll_Result> ProveedorGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProveedorGetAll_Result>("ProveedorGetAll");
        }
    
        public virtual ObjectResult<SubCategoriaGetAll_Result> SubCategoriaGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SubCategoriaGetAll_Result>("SubCategoriaGetAll");
        }
    
        public virtual ObjectResult<SubCategoriaGetByCategoria_Result> SubCategoriaGetByCategoria(Nullable<int> idCategoria)
        {
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("IdCategoria", idCategoria) :
                new ObjectParameter("IdCategoria", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SubCategoriaGetByCategoria_Result>("SubCategoriaGetByCategoria", idCategoriaParameter);
        }
    
        public virtual ObjectResult<UsuarioGetById_Result> UsuarioGetById(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuarioGetById_Result>("UsuarioGetById", idUsuarioParameter);
        }
    
        public virtual int ProveedorAdd(string nombre, string direccion, string telefono, string email, string sitioWeb, byte[] imagen)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var sitioWebParameter = sitioWeb != null ?
                new ObjectParameter("SitioWeb", sitioWeb) :
                new ObjectParameter("SitioWeb", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProveedorAdd", nombreParameter, direccionParameter, telefonoParameter, emailParameter, sitioWebParameter, imagenParameter);
        }
    
        public virtual int ProveedorDelete(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProveedorDelete", idProveedorParameter);
        }
    
        public virtual int ProveedorUpdate(Nullable<int> idProveedor, string nombre, string direccion, string telefono, string email, string sitioWeb, byte[] imagen)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var sitioWebParameter = sitioWeb != null ?
                new ObjectParameter("SitioWeb", sitioWeb) :
                new ObjectParameter("SitioWeb", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProveedorUpdate", idProveedorParameter, nombreParameter, direccionParameter, telefonoParameter, emailParameter, sitioWebParameter, imagenParameter);
        }
    
        public virtual ObjectResult<ProductoGetIndex_Result> ProductoGetIndex()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetIndex_Result>("ProductoGetIndex");
        }
    
        public virtual ObjectResult<Nullable<int>> ConfirmPassword(Nullable<int> idUsuario, string password)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ConfirmPassword", idUsuarioParameter, passwordParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> ConfirmUser(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ConfirmUser", emailParameter);
        }
    
        public virtual ObjectResult<string> GetNombreByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetNombreByEmail", emailParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GetRolByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetRolByEmail", emailParameter);
        }
    
        public virtual ObjectResult<ProductoGetAll_Result> ProductoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetAll_Result>("ProductoGetAll");
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual int ProductoUpdate(Nullable<int> idProducto, string nombre, string marca, string descripcion, Nullable<int> stock, Nullable<decimal> precio, Nullable<int> valoraciones, string comentarios, string keyWords, byte[] imagen, Nullable<int> idSubCategoria, Nullable<int> idProveedor, Nullable<int> enCurso, Nullable<int> vendidos)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var valoracionesParameter = valoraciones.HasValue ?
                new ObjectParameter("Valoraciones", valoraciones) :
                new ObjectParameter("Valoraciones", typeof(int));
    
            var comentariosParameter = comentarios != null ?
                new ObjectParameter("Comentarios", comentarios) :
                new ObjectParameter("Comentarios", typeof(string));
    
            var keyWordsParameter = keyWords != null ?
                new ObjectParameter("KeyWords", keyWords) :
                new ObjectParameter("KeyWords", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var idSubCategoriaParameter = idSubCategoria.HasValue ?
                new ObjectParameter("IdSubCategoria", idSubCategoria) :
                new ObjectParameter("IdSubCategoria", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            var enCursoParameter = enCurso.HasValue ?
                new ObjectParameter("EnCurso", enCurso) :
                new ObjectParameter("EnCurso", typeof(int));
    
            var vendidosParameter = vendidos.HasValue ?
                new ObjectParameter("Vendidos", vendidos) :
                new ObjectParameter("Vendidos", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", idProductoParameter, nombreParameter, marcaParameter, descripcionParameter, stockParameter, precioParameter, valoracionesParameter, comentariosParameter, keyWordsParameter, imagenParameter, idSubCategoriaParameter, idProveedorParameter, enCursoParameter, vendidosParameter);
        }
    
        public virtual int ProductoAdd(string nombre, string marca, string descripcion, Nullable<int> stock, Nullable<decimal> precio, Nullable<int> valoraciones, string comentarios, string keyWords, byte[] imagen, Nullable<int> idSubCategoria, Nullable<int> idProveedor)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var marcaParameter = marca != null ?
                new ObjectParameter("Marca", marca) :
                new ObjectParameter("Marca", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var valoracionesParameter = valoraciones.HasValue ?
                new ObjectParameter("Valoraciones", valoraciones) :
                new ObjectParameter("Valoraciones", typeof(int));
    
            var comentariosParameter = comentarios != null ?
                new ObjectParameter("Comentarios", comentarios) :
                new ObjectParameter("Comentarios", typeof(string));
    
            var keyWordsParameter = keyWords != null ?
                new ObjectParameter("KeyWords", keyWords) :
                new ObjectParameter("KeyWords", typeof(string));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var idSubCategoriaParameter = idSubCategoria.HasValue ?
                new ObjectParameter("IdSubCategoria", idSubCategoria) :
                new ObjectParameter("IdSubCategoria", typeof(int));
    
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", nombreParameter, marcaParameter, descripcionParameter, stockParameter, precioParameter, valoracionesParameter, comentariosParameter, keyWordsParameter, imagenParameter, idSubCategoriaParameter, idProveedorParameter);
        }
    
        public virtual ObjectResult<ProveedorById_Result> ProveedorById(Nullable<int> idProveedor)
        {
            var idProveedorParameter = idProveedor.HasValue ?
                new ObjectParameter("IdProveedor", idProveedor) :
                new ObjectParameter("IdProveedor", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProveedorById_Result>("ProveedorById", idProveedorParameter);
        }
    
        public virtual int CarritoCreate(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CarritoCreate", idUsuarioParameter);
        }
    
        public virtual int CarritoDetalleAdd(Nullable<int> idCarrito, Nullable<int> idProducto, Nullable<decimal> cantidad)
        {
            var idCarritoParameter = idCarrito.HasValue ?
                new ObjectParameter("IdCarrito", idCarrito) :
                new ObjectParameter("IdCarrito", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CarritoDetalleAdd", idCarritoParameter, idProductoParameter, cantidadParameter);
        }
    
        public virtual int CarritoDetalleDelete(Nullable<int> idDetalleCarrito)
        {
            var idDetalleCarritoParameter = idDetalleCarrito.HasValue ?
                new ObjectParameter("IdDetalleCarrito", idDetalleCarrito) :
                new ObjectParameter("IdDetalleCarrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CarritoDetalleDelete", idDetalleCarritoParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> CarritoGetByUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("CarritoGetByUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<CarritoDetalleGetByCarrito_Result> CarritoDetalleGetByCarrito(Nullable<int> idCarrito)
        {
            var idCarritoParameter = idCarrito.HasValue ?
                new ObjectParameter("IdCarrito", idCarrito) :
                new ObjectParameter("IdCarrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarritoDetalleGetByCarrito_Result>("CarritoDetalleGetByCarrito", idCarritoParameter);
        }
    
        public virtual int CarritoDelete(Nullable<int> idCarrito)
        {
            var idCarritoParameter = idCarrito.HasValue ?
                new ObjectParameter("IdCarrito", idCarrito) :
                new ObjectParameter("IdCarrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CarritoDelete", idCarritoParameter);
        }
    
        public virtual ObjectResult<GetSesionByEmail_Result> GetSesionByEmail(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetSesionByEmail_Result>("GetSesionByEmail", emailParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> PedidoGetByUsuario(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("PedidoGetByUsuario", idUsuarioParameter);
        }
    
        public virtual ObjectResult<PedidoGetByIdPedido_Result> PedidoGetByIdPedido(Nullable<int> idPedido)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PedidoGetByIdPedido_Result>("PedidoGetByIdPedido", idPedidoParameter);
        }
    
        public virtual ObjectResult<PedidoDetalleGetByPedido_Result> PedidoDetalleGetByPedido(Nullable<int> idPedido)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PedidoDetalleGetByPedido_Result>("PedidoDetalleGetByPedido", idPedidoParameter);
        }
    
        public virtual ObjectResult<CarritoGetByCarrito_Result> CarritoGetByCarrito(Nullable<int> idCarrito)
        {
            var idCarritoParameter = idCarrito.HasValue ?
                new ObjectParameter("IdCarrito", idCarrito) :
                new ObjectParameter("IdCarrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CarritoGetByCarrito_Result>("CarritoGetByCarrito", idCarritoParameter);
        }
    
        public virtual int PedidoAdd(Nullable<int> idUsuario, Nullable<System.DateTime> fecha)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("Fecha", fecha) :
                new ObjectParameter("Fecha", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PedidoAdd", idUsuarioParameter, fechaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> PedidoGetByStatus(Nullable<int> idUsuario, Nullable<int> idEstatus)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var idEstatusParameter = idEstatus.HasValue ?
                new ObjectParameter("IdEstatus", idEstatus) :
                new ObjectParameter("IdEstatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("PedidoGetByStatus", idUsuarioParameter, idEstatusParameter);
        }
    
        public virtual int PedidoDetalleAdd(Nullable<int> idPedido, Nullable<int> idProducto, Nullable<int> cantidad, Nullable<decimal> subtotal, Nullable<decimal> precioVendido)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            var subtotalParameter = subtotal.HasValue ?
                new ObjectParameter("Subtotal", subtotal) :
                new ObjectParameter("Subtotal", typeof(decimal));
    
            var precioVendidoParameter = precioVendido.HasValue ?
                new ObjectParameter("PrecioVendido", precioVendido) :
                new ObjectParameter("PrecioVendido", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PedidoDetalleAdd", idPedidoParameter, idProductoParameter, cantidadParameter, subtotalParameter, precioVendidoParameter);
        }
    
        public virtual int PedidoUpdateTotal(Nullable<int> idPedido, Nullable<decimal> total)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PedidoUpdateTotal", idPedidoParameter, totalParameter);
        }
    
        public virtual int PedidoUpdateEstatus(Nullable<int> idPedido, Nullable<int> idEstatus)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            var idEstatusParameter = idEstatus.HasValue ?
                new ObjectParameter("IdEstatus", idEstatus) :
                new ObjectParameter("IdEstatus", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PedidoUpdateEstatus", idPedidoParameter, idEstatusParameter);
        }
    
        public virtual ObjectResult<PedidoGetAll_Result> PedidoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PedidoGetAll_Result>("PedidoGetAll");
        }
    
        public virtual ObjectResult<EstatusGetAll_Result> EstatusGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EstatusGetAll_Result>("EstatusGetAll");
        }
    
        public virtual int CarritoEmpty(Nullable<int> idCarrito)
        {
            var idCarritoParameter = idCarrito.HasValue ?
                new ObjectParameter("IdCarrito", idCarrito) :
                new ObjectParameter("IdCarrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CarritoEmpty", idCarritoParameter);
        }
    
        public virtual ObjectResult<PedidoGetPrecios_Result> PedidoGetPrecios(Nullable<int> idPedido)
        {
            var idPedidoParameter = idPedido.HasValue ?
                new ObjectParameter("IdPedido", idPedido) :
                new ObjectParameter("IdPedido", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PedidoGetPrecios_Result>("PedidoGetPrecios", idPedidoParameter);
        }
    }
}
