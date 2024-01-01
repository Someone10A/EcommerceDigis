using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace BL
{
    public class Usuario
    {
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    string fechaNacimientoString;
                    if (DateTime.TryParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaNacimiento))
                    {
                        fechaNacimientoString = fechaNacimiento.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        fechaNacimientoString = DateTime.MinValue.ToString("yyyy-MM-dd");
                    }
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno,
                        usuario.ApellidoMaterno, usuario.Email, usuario.Password, fechaNacimientoString,
                        usuario.Sexo, usuario.Celular, usuario.Imagen, usuario.Rol.IdRol, usuario.Direccion.Calle,
                        usuario.Direccion.Colonia, usuario.Direccion.CodigoPostal, usuario.Direccion.NumeroExterior,
                        usuario.Direccion.NumeroInterior, usuario.Direccion.Municipio.IdMunicipio);
                    if (query > 0)
                    {
                        result.Message = "Usuario añadido correctamente";
                        result.Correct = true;
                    }   
                    else
                    {
                        result.Message = "No se pudo añadir al usuario";
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
        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    string fechaNacimientoString;
                    if (DateTime.TryParseExact(usuario.FechaNacimiento, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaNacimiento))
                    {
                        fechaNacimientoString = fechaNacimiento.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        fechaNacimientoString = DateTime.MinValue.ToString("yyyy-MM-dd");
                    }
                    var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoMaterno,
                        usuario.ApellidoMaterno, usuario.Email, fechaNacimientoString,
                        usuario.Sexo, usuario.Celular, usuario.Imagen, usuario.Rol.IdRol, usuario.Direccion.Calle,
                        usuario.Direccion.Colonia, usuario.Direccion.CodigoPostal, usuario.Direccion.NumeroExterior,
                        usuario.Direccion.NumeroInterior, usuario.Direccion.Municipio.IdMunicipio);
                    if (query > 0)
                    {
                        result.Message = "Usuario actualizado correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se pudo actualizar al usuario";
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
        public static ML.Result DeleteEF(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.UsuarioDelete(idUsuario);
                    if (query > 0)
                    {
                        result.Message = "Usuario eliminado correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se pudo eliminar al usuario";
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
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.UsuarioGetAll();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Estatus = (bool)item.Estatus;
                            usuario.UserName = item.UserName;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Email = item.Email;
                            usuario.Password = item.Password;
                            usuario.FechaNacimiento = item.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.Sexo = item.Sexo;
                            usuario.Celular = item.Celular;
                            usuario.Imagen = item.Imagen;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (int)item.IdRol;
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = item.IdDireccion;
                            usuario.Direccion.Calle = item.Calle;
                            usuario.Direccion.Colonia = item.Colonia;
                            usuario.Direccion.CodigoPostal = item.CodigoPostal;
                            usuario.Direccion.NumeroExterior = item.NumeroExterior;
                            usuario.Direccion.NumeroInterior = item.NumeroInterior;
                            usuario.Direccion.Municipio = new ML.Municipio();
                            usuario.Direccion.Municipio.IdMunicipio = (int)item.IdMunicipio;

                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron usuarios";
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
        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.UsuarioGetById(idUsuario).FirstOrDefault();
                    if (query != null)
                    {
                        var item = query;
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.UserName = item.UserName;
                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Estatus = (bool)item.Estatus;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.FechaNacimiento = item.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.Email = item.Email;
                            usuario.Sexo = item.Sexo;
                            usuario.Celular = item.Celular;
                            usuario.Imagen = item.Imagen;
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = (int)item.IdRol;
                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = item.IdDireccion;
                            usuario.Direccion.Calle = item.Calle;
                            usuario.Direccion.Colonia = item.Colonia;
                            usuario.Direccion.CodigoPostal = item.CodigoPostal;
                            usuario.Direccion.NumeroExterior = item.NumeroExterior;
                            usuario.Direccion.NumeroInterior = item.NumeroInterior;
                            usuario.Direccion.Municipio = new ML.Municipio();
                            usuario.Direccion.Municipio.IdMunicipio = (int)item.IdMunicipio;
                            usuario.Direccion.Municipio.Nombre = item.NombreMunicipio;
                            usuario.Direccion.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Municipio.Estado.IdEstado = item.IdEstado;
                            usuario.Direccion.Municipio.Estado.Nombre = item.NombreEstado;

                            
                        result.Object = usuario;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Message = "No se encontraron usuarios";
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
        public static ML.Result UpdateEstatusEF(int idUsuario, bool estatus)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.UsuarioEstatusUpdate(idUsuario, estatus);
                    {
                        if (query > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se actualizo el estatus";
                        }
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
        public static ML.Result Login(string email, string password)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var queryEmail = context.ConfirmUser(email).FirstOrDefault(); ;
                    if (queryEmail != null)
                    {
                        var item = queryEmail;
                        var queryPassword = context.ConfirmPassword(item, password).FirstOrDefault();

                        var confirm = queryPassword;
                        if (confirm != null)
                        {
                            result.Correct = true;
                            result.Message = "Contraseña coincide";
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "La contraseña no es correcta";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Correo no dado de alta";
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
        public static string GetNombre(string email)
        {
            string Nombre = "";
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.GetNombreByEmail(email).FirstOrDefault();
                    if (query != null)
                    {
                        Nombre = query;
                    }
                    else
                    {
                        Nombre = "Usuario";
                    }    
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                Nombre = "Usuario";
            }
            return Nombre;
        }
        public static int GetRol(string email)
        {
            int Rol = 0;
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.GetRolByEmail(email).FirstOrDefault();
                    if (query != null)
                    {
                        Rol = query.Value;
                    }
                    else
                    {
                        Rol = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Exception exception = ex;
                Rol = 0;
            }
            return Rol;
        }
        public static ML.Result GetSesion(string email)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EcommerceDigisEntities context = new DL_EF.EcommerceDigisEntities())
                {
                    var query = context.GetSesionByEmail(email).FirstOrDefault();
                    if (query != null)
                    {
                        var item = query;
                        ML.Sesion sesion = new ML.Sesion();
                        sesion.Nombre = item.Nombre;
                        sesion.IdRol = item.IdRol.Value;
                        sesion.IdUsuario = item.IdUsuario;

                        result.Object = sesion;
                    }
                    else
                    {
                        result.Correct = false;
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
