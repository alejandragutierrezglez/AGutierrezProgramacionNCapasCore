using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DependienteEmpleadoController : Controller
    {
        //GET: Usuario

        [HttpGet]
        public ActionResult GetAll(string NumeroEmpleado)

        {
            
            ML.Result result = BL.DependienteEmpleado.DependienteGetByIdEmpleado(NumeroEmpleado);
            ML.Dependiente dependiente = new ML.Dependiente();
           // ML.Result resultDependiente = BL.Dependiente.GetAll();

            if (result.Correct)
            {

                dependiente.Dependientes = result.Objects;
                
                return View(dependiente);
            }
            else
            {
                return View(dependiente);
            }
        }




        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
    }
}
