using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.Nombre = (empleado.Nombre == null) ? "" : empleado.Nombre;
            
            ML.Result result = BL.Empleado.GetAll(empleado);
            ML.Result resultEmpresa = BL.Empresa.GetAll();
           
            empleado.Empresa = new ML.Empresa();
            empleado.Empresa.Empresas = resultEmpresa.Objects;

            if (result.Correct && resultEmpresa.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Empleado/GetById/{numEmpleado}")]
        public ActionResult GetById(string numEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(numEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/Empleado/Get/{id}")]
        public ActionResult Get(string numEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(numEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/Empleado/Add")]
        public ActionResult Add([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Add(empleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }

        [HttpPost]
        [Route("api/Empleado/Update/{numEmpleado}")]
        public ActionResult Update([FromBody] ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);
           
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpGet]
        [Route("api/Empleado/Delete/{numEmpleado}")]
        public ActionResult Delete(string numEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numEmpleado;
            ML.Result result = BL.Empleado.Delete(numEmpleado);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}
