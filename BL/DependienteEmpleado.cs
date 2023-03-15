using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DependienteEmpleado
    {
        public static ML.Result DependienteGetByIdEmpleado(string NumeroEmpleado)
        {
            ML.Result result = new ML.Result();
            {
                try
                {
                    using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                    {
                        var query = context.Dependientes.FromSqlRaw($"DependienteGetByIdEmpleado '{NumeroEmpleado}'").ToList();

                        if (query != null)
                        {
                            result.Objects = new List<object>();

                            foreach (var obj in query)
                            {
                                ML.Dependiente dependiente = new ML.Dependiente();

                                dependiente.IdDependiente = obj.IdDependiente;

                                dependiente.Empleado = new ML.Empleado();
                                dependiente.Empleado.NumeroEmpleado = obj.NumeroEmpleado;

                                dependiente.Nombre = obj.Nombre;
                                dependiente.ApellidoPaterno = obj.ApellidoPaterno;
                                dependiente.ApellidoMaterno = obj.ApellidoMaterno;
                                dependiente.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                                dependiente.EstadoCivil = obj.EstadoCivil;
                                dependiente.Genero = obj.Genero;
                                dependiente.Telefono = obj.Telefono;
                                dependiente.RFC = obj.Rfc;

                                dependiente.DependienteTipo = new ML.DependienteTipo();
                                dependiente.DependienteTipo.IdDependienteTipo = obj.IdDependienteTipo;


                                result.Objects.Add(dependiente);


                            }
                        }
                    }
                    result.Correct = true;
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

        //public static ML.Result GetAll(ML.Dependiente dependiente)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
        //        {
        //            //var query = context.AlumnoGetAll().ToList();
        //            //                    var query = context.Empleados.FromSqlRaw("EmpleadoGetAll").ToList();
        //            var query = context.Dependientes.FromSqlRaw($"DependienteGetAll").ToList();

        //            if (query != null)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (var obj in query)
        //                {

        //                    dependiente = new ML.Dependiente();

        //                    dependiente.IdDependiente = query.
        //                    dependiente.Empleado.NumeroEmpleado = query.NumeroEmpleado;
        //                    dependiente.Nombre = query.Nombre;
        //                    dependiente.ApellidoPaterno = query.ApellidoPaterno;
        //                    dependiente.ApellidoMaterno = query.ApellidoMaterno;
        //                    dependiente.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
        //                    dependiente.EstadoCivil = query.EstadoCivil;
        //                    dependiente.Genero = query.Genero;
        //                    dependiente.Telefono = query.Telefono;
        //                    dependiente.RFC = query.Rfc;
        //                    dependiente.DependienteTipo.IdDependienteTipo = query.IdDependienteTipo;

        //                    empleado.Empresa = new ML.Empresa();
        //                    empleado.Empresa.IdEmpresa = obj.IdEmpresa.Value;

        //                    result.Objects.Add(empleado);
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
    }
}
