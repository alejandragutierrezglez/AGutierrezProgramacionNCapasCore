
using DL;
using Microsoft.EntityFrameworkCore;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    //var query = context.AlumnoGetAll().ToList();
                    //                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();
                    var query = context.Empleados.FromSqlRaw($"EmpleadoGetAll '{empleado.Nombre}'").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            empleado = new ML.Empleado();

                            empleado.NumeroEmpleado = obj.NumeroEmpleado;
                            empleado.RFC = obj.Rfc;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;
                            empleado.Email= obj.Email;
                            empleado.Telefono = obj.Telefono;
                            empleado.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            empleado.NSS = obj.Nss;
                            empleado.FechaIngreso = obj.FechaIngreso.Value.ToString("dd/MM/yyyy");
                            empleado.Foto = obj.Foto;
                          
                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = obj.IdEmpresa.Value;

                            result.Objects.Add(empleado);
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
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    // var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    int query = context.Database.ExecuteSqlRaw($"EmpleadoAdd '{empleado.NumeroEmpleado}', '{empleado.RFC}', '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}','{empleado.Email}','{empleado.Telefono}','{empleado.FechaNacimiento}','{empleado.NSS}','{empleado.FechaIngreso}','{empleado.Foto}',{empleado.Empresa.IdEmpresa}");

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
        public static ML.Result Update(ML.Empleado empleado)
        {
            using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
            {
                Result result = new ML.Result();
                try
                {

                    //var query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.UserName, usuario.Passwordd, DateTime.Parse(usuario.FechaNacimiento), usuario.Rol.IdRol, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoUpdate '{empleado.NumeroEmpleado}', '{empleado.RFC}', '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}','{empleado.Email}','{empleado.Telefono}','{empleado.FechaNacimiento}','{empleado.NSS}','{empleado.FechaIngreso}','{empleado.Foto}',{empleado.Empresa.IdEmpresa}");



                    if (query > 0)
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

        public static ML.Result GetById(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                    {
                        var query = context.Empleados.FromSqlRaw($"EmpleadoGetById {numeroEmpleado}").AsEnumerable().FirstOrDefault();

                        if (query != null)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.NumeroEmpleado = query.NumeroEmpleado;
                            empleado.RFC = query.Rfc;
                            empleado.Nombre = query.Nombre;
                            empleado.ApellidoPaterno= query.ApellidoPaterno;
                            empleado.ApellidoMaterno= query.ApellidoMaterno;
                            empleado.Email = query.Email;
                            empleado.Telefono= query.Telefono;
                            empleado.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            empleado.NSS = query.Nss;
                            empleado.FechaIngreso = query.FechaIngreso.Value.ToString("dd/MM/yyyy");
                            empleado.Foto = query.Foto;
                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.IdEmpresa = query.IdEmpresa.Value;
                            empleado.Empresa.Nombre = query.Nombre_Empresa;
                            empleado.Empresa.Telefono = query.Telefono_Empresa;
                            empleado.Empresa.Email = query.Email_Empresa;
                            empleado.Empresa.DireccionWeb = query.DireccionWeb_Empresa;
                            empleado.Empresa.Logo = query.Logo_Empresa;

                            result.Object = empleado;

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
        public static ML.Result Delete(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EmpleadoDelete {numeroEmpleado}");

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

    }
}
