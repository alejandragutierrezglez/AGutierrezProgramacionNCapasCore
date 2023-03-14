using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class DependienteEmpleadoController : Controller
    {
        //GET: Usuario

        //[HttpGet]
        // public ActionResult GetAll()
        // {
        //     ML.Result result = BL.Empleado.GetAll();
        //     ML.Empleado empleado = new ML.Empleado();

        //     if (result.Correct)
        //     {

        //         empleado.Empleados = result.Objects;
        //         return View(empleado);
        //     }
        //     else
        //     {
        //         return View(empleado);
        //     }
        // }




        [HttpPost] //Hacer el registro
        public ActionResult Form(ML.Empleado empleado)
        {
            IFormFile file = Request.Form.Files["fuImage"];

            if (file != null)
            {
                byte[] imagen = ConvertToBytes(file);

                empleado.Foto = Convert.ToBase64String(imagen);
            }

            ML.Result result = new ML.Result();

            if (empleado.NumeroEmpleado != null)
            {
                //Agregar
                //result = BL.Empleado.Add(empleado);
                //ViewBag.Message = "Se ha agregado el registro";
                //Modificar
                result = BL.Empleado.Update(empleado);
                ViewBag.Message = "Se ha modificado el registro";
            }
            else
            {
                //Add
                result = BL.Empleado.Update(empleado);
                ViewBag.Message = "salio del if";
            }
            if (result.Correct)
            {
                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
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
