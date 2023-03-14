using BL;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        [HttpGet]

        public ActionResult GetAll()
        {
            ML.Empleado empleado = new ML.Empleado();

            ML.Result resultEmpleado = BL.Empleado.GetAll(empleado);
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            empleado.Empresa = new ML.Empresa();



            if (resultEmpleado.Correct && resultEmpresa.Correct)
            {
                empleado.Empleados = resultEmpleado.Objects;
                empleado.Empresa.Empresas = resultEmpresa.Objects;
                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpPost]
        public ActionResult GetAll(ML.Empleado empleado)
        {

            ML.Result result = new ML.Result();
            result = BL.Empleado.GetAll(empleado);
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            if (result.Correct)

            {
                empleado.Empleados = result.Objects;
                empleado.Empresa.Empresas = resultEmpresa.Objects;

                return View(empleado);
            }
            else
            {
                return View(empleado);
            }
        }

        [HttpGet]
        public ActionResult Form(string numeroEmpleado)
        {
            ML.Result resultEmpresa = BL.Empresa.GetAll();

            ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();


            if (resultEmpresa.Correct)
            {

                empleado.Empresa.Empresas = resultEmpresa.Objects;
            }
            if (numeroEmpleado == null)
            {
                //add //formulario vacio
                return View(empleado);
            }
            else
            {
                //getById
                ML.Result result = BL.Empleado.GetById(numeroEmpleado); //2

                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object;//unboxing
                    empleado.Empresa.Empresas = resultEmpresa.Objects;
                    //update
                    return View(empleado);
                }
                else
                {
                    ViewBag.Message = "Ocurrio al consultar la información del empleado";
                    return View("Modal");
                }


            }


        }

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

        public ActionResult Delete(string numeroEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(numeroEmpleado);

            if (result.Correct)
            {
                ViewBag.Message = "Se ha eliminado el empleado";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha podido eliminar el registro del empleado seleccionado" + result.ErrorMessage;
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
