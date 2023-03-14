using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado(int idEstado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.AgutierrezProgramacionNcapasContext context = new DL.AgutierrezProgramacionNcapasContext())
                {
                    //var query = context.MunicipioGetByIdEstado(idEstado).ToList();
                    var query = context.Municipios.FromSqlRaw($"MunicipioGetByIdEstado {idEstado}").ToList();
                   

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Municipio municipio = new ML.Municipio();

                            municipio.IdMunicipio = obj.IdMunicipio;
                            municipio.Nombre = obj.Nombre;


                            result.Objects.Add(municipio);
                        }
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
