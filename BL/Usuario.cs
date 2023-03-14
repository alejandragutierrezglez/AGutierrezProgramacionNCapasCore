using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    // var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    int query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.UserName}','{usuario.Passwordd}','{usuario.FechaNacimiento}', {usuario.Rol.IdRol},'{usuario.Sexo}','{usuario.Telefono}','{usuario.Celular}','{usuario.CURP}', '{usuario.Imagen}','{usuario.Direccion.Calle}','{usuario.Direccion.NumeroInterior}','{usuario.Direccion.NumeroExterior}',{usuario.Direccion.Colonia.IdColonia}");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        //public static ML.Result GetAll()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
        //        {
        //            //var query = context.AlumnoGetAll().ToList();
        //            var query = context.Usuarios.FromSqlRaw("UsuarioGetAll").ToList();


        //            if (query != null)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (var obj in query)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();

        //                    usuario.IdUsuario = obj.IdUsuario;
        //                    usuario.Nombre = obj.Nombre;
        //                    usuario.ApellidoPaterno = obj.ApellidoPaterno;
        //                    usuario.ApellidoMaterno = obj.ApellidoMaterno;
        //                    usuario.Email = obj.Email;
        //                    usuario.UserName = obj.UserName;
        //                    usuario.Passwordd = obj.Passwordd;
        //                    usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd/MM/yyyy");

        //                    usuario.Rol = new ML.Rol();
        //                    usuario.Rol.IdRol = obj.IdRol.Value;
        //                    usuario.Rol.Nombre = obj.Nombre_Rol;

        //                    usuario.Sexo = obj.Sexo;
        //                    usuario.Telefono = obj.Telefono;
        //                    usuario.Celular = obj.Celular;
        //                    usuario.CURP = obj.Curp;
        //                    usuario.Imagen = obj.Imagen;

        //                    result.Objects.Add(usuario);
        //                }
        //            }
        //        }



        //        result.Correct = true;


        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;

        //    }
        //    return result;
        //}
        public static ML.Result GetAll(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    //var query = context.AlumnoGetAll().ToList();

                    var query = context.Usuarios.FromSqlRaw($"UsuarioGetAll '{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}'").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.UserName = obj.UserName;
                            usuario.Passwordd = obj.Passwordd;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd/MM/yyyy");

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;
                            usuario.Rol.Nombre = obj.Nombre_Rol;

                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.Curp;
                            usuario.Imagen = obj.Imagen;
                            usuario.Status = obj.Status.Value;

                            result.Objects.Add(usuario);
                        }
                    }
                }



                result.Correct = true;


            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;

            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioDelete {IdUsuario}");

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                    {
                        var query = context.Usuarios.FromSqlRaw($"UsuarioGetById {IdUsuario}").AsEnumerable().FirstOrDefault();

                        if (query != null)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = query.IdUsuario;
                            usuario.Nombre = query.Nombre;
                            usuario.ApellidoPaterno = query.ApellidoPaterno;
                            usuario.ApellidoMaterno = query.ApellidoMaterno;
                            usuario.Email = query.Email;
                            usuario.UserName = query.UserName;
                            usuario.Passwordd = query.Passwordd;
                            usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd/MM/yyyy");
                            usuario.Sexo = query.Sexo;
                            usuario.Telefono = query.Telefono;
                            usuario.Celular = query.Celular;
                            usuario.CURP = query.Curp;
                            usuario.Imagen = query.Imagen;
                            usuario.Status = query.Status;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = query.IdRol.Value;
                            usuario.Rol.Nombre = query.Nombre_Rol;


                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.IdDireccion = query.IdDireccion;
                            usuario.Direccion.Calle = query.Calle;
                            usuario.Direccion.NumeroInterior = query.NumeroInterior;
                            usuario.Direccion.NumeroExterior = query.NumeroExterior;

                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                            usuario.Direccion.Colonia.Nombre = query.Nombre_Colonia;
                            usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;

                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                            usuario.Direccion.Colonia.Municipio.Nombre = query.Nombre_Municipio;

                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                            usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.Nombre_Estado;


                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.Nombre_Pais;


                            result.Object = usuario;

                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }

        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
            {
                Result result = new ML.Result();
                try
                {

                    //var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    int query = context.Database.ExecuteSqlRaw($"UsuarioUpdate {usuario.IdUsuario},'{usuario.Nombre}', '{usuario.ApellidoPaterno}', '{usuario.ApellidoMaterno}','{usuario.Email}','{usuario.UserName}','{usuario.Passwordd}','{usuario.FechaNacimiento}', {usuario.Rol.IdRol},'{usuario.Sexo}','{usuario.Telefono}','{usuario.Celular}','{usuario.CURP}', '{usuario.Imagen}','{usuario.Direccion.Calle}','{usuario.Direccion.NumeroInterior}','{usuario.Direccion.NumeroExterior}',{usuario.Direccion.Colonia.IdColonia}");



                    if (Convert.ToInt32(query) > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
                catch (Exception ex)
                {

                    result.ErrorMessage = ex.Message;
                    result.Ex = ex;
                    result.Correct = false;
                }
                return result;

            }
        }

        public static ML.Result UsuarioChangeStatus(int idUsuario, bool status)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    // var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    int query = context.Database.ExecuteSqlRaw($"UsuarioChangeStatus {idUsuario}, '{status}'");

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetByUsername(string username)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                    {
                        var query = context.Usuarios.FromSqlRaw($"UsuarioGetByUsername {username}").AsEnumerable().FirstOrDefault();

                        if (query != null)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            //usuario.IdUsuario = query.IdUsuario;
                            //usuario.Nombre = query.Nombre;
                            //usuario.ApellidoPaterno = query.ApellidoPaterno;
                            //usuario.ApellidoMaterno = query.ApellidoMaterno;
                            //usuario.Email = query.Email;
                            usuario.UserName = query.UserName;
                            usuario.Passwordd = query.Passwordd;
                            //usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd/MM/yyyy");
                            //usuario.Sexo = query.Sexo;
                            //usuario.Telefono = query.Telefono;
                            //usuario.Celular = query.Celular;
                            //usuario.CURP = query.Curp;
                            //usuario.Imagen = query.Imagen;
                            //usuario.Rol.IdRol = query.IdRol.Value;

                            //usuario.Rol = new ML.Rol();
                            //usuario.Rol.IdRol = query.IdRol.Value;


                            //usuario.Direccion = new ML.Direccion();
                            //usuario.Direccion.IdDireccion = query.IdDireccion;
                            //usuario.Direccion.Calle = query.Calle;
                            //usuario.Direccion.NumeroInterior = query.NumeroInterior;
                            //usuario.Direccion.NumeroExterior = query.NumeroExterior;

                            //usuario.Direccion.Colonia = new ML.Colonia();
                            //usuario.Direccion.Colonia.IdColonia = query.IdColonia;
                            //usuario.Direccion.Colonia.Nombre = query.Nombre_Colonia;
                            //usuario.Direccion.Colonia.CodigoPostal = query.CodigoPostal;

                            //usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            //usuario.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                            //usuario.Direccion.Colonia.Municipio.Nombre = query.Nombre_Municipio;

                            //usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            //usuario.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                            //usuario.Direccion.Colonia.Municipio.Estado.Nombre = query.Nombre_Estado;


                            //usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            //usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                            //usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.Nombre_Pais;


                            result.Object = usuario;

                            result.Correct = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    result.Correct = false;
                    result.Ex = ex;
                    result.ErrorMessage = ex.Message;
                }
                return result;
            }

        }

        public static ML.Result ConvertXSLXtoDataTable(string connString)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OleDbConnection context = new OleDbConnection(connString))
                {
                    string query = "SELECT * FROM [Sheet1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;


                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;

                        DataTable tableUsuario = new DataTable();

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.Nombre = row[0].ToString();
                                usuario.ApellidoPaterno = row[1].ToString();
                                usuario.ApellidoMaterno = row[2].ToString();
                                usuario.Email = row[3].ToString();
                                usuario.UserName = row[4].ToString();
                                usuario.Passwordd = row[5].ToString();
                                usuario.FechaNacimiento = row[6].ToString();
                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[7].ToString());
                                usuario.Sexo = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();
                                usuario.Status = bool.Parse(row[12].ToString());

                                usuario.Direccion = new ML.Direccion();
                                usuario.Direccion.Calle = row[13].ToString();
                                usuario.Direccion.NumeroInterior = row[14].ToString();
                                usuario.Direccion.NumeroExterior = row[15].ToString();
                                usuario.Direccion.Colonia = new ML.Colonia();
                                usuario.Direccion.Colonia.IdColonia = int.Parse(row[16].ToString());


                                result.Objects.Add(usuario);
                            }

                            result.Correct = true;

                        }

                        result.Object = tableUsuario;

                        if (tableUsuario.Rows.Count > 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en el excel";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;


        }
        public static ML.Result ValidarExcel(List<object> Object)
        
        {
            ML.Result result = new ML.Result();

            try
            {
                result.Objects = new List<object>();
                //DataTable  //Rows //Columns
                int i = 1;
                foreach (ML.Usuario usuario in Object)
                {
                    ML.ErrorExcel error = new ML.ErrorExcel();
                    error.IdRegistro = i++;

                    if (usuario.Nombre == "")
                    {
                        error.Mensaje += "Ingresar el nombre  ";
                    }
                    if (usuario.ApellidoPaterno == "")
                    {
                        error.Mensaje += "Ingresa tu Apellido Paterno ";
                    }
                    if (usuario.ApellidoMaterno == "")
                    {
                        error.Mensaje += "Ingresar tu Apellido Materno ";
                    }
                    if (usuario.Email == "")
                    {
                        error.Mensaje += "Ingresar el Email ";
                    }
                    if (usuario.UserName == "")
                    {
                        error.Mensaje += "Ingresar el Username ";
                    }
                    if (usuario.Passwordd == "")
                    {
                        error.Mensaje += "Ingresar el Password ";
                    }
                    if (usuario.FechaNacimiento == "")
                    {
                        error.Mensaje += "Ingresar la Fecha de Nacimiento ";
                    }
                    if (usuario.Rol.IdRol.ToString() == "")
                    {
                        error.Mensaje += "Ingresar el Idrol ";
                    }
                    if (usuario.Sexo == "")
                    {
                        error.Mensaje += "Ingresar el Sexo ";
                    }
                    if (usuario.Telefono == "")
                    {
                        error.Mensaje += "Ingresar el Telefono ";
                    }
                    if (usuario.Celular == "")
                    {
                        error.Mensaje += "Ingresar el Celular ";
                    }
                    if (usuario.CURP == "")
                    {
                        error.Mensaje += "Ingresar el CURP ";
                    }
                    if (usuario.Status.ToString() == "")
                    {
                        error.Mensaje += "Ingresar el Status ";
                    }
                    if (usuario.Direccion.Calle == "")
                    {
                        error.Mensaje += "Ingresar la Calle ";
                    }
                    if (usuario.Direccion.NumeroInterior == "")
                    {
                        error.Mensaje += "Ingresar el Numero Interior ";
                    }
                    if (usuario.Direccion.NumeroExterior == "")
                    {
                        error.Mensaje += "Ingresar el Numero Exterior ";
                    }
                    if (usuario.Direccion.Colonia.IdColonia.ToString() == "")
                    {
                        error.Mensaje += "Ingresar el Id de la Colonia ";
                    }


                    if (error.Mensaje != null)
                    {
                        result.Objects.Add(error);
                    }


                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }

    }
}

