using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {

        // GET: Usuario

        //Inyeccion de dependencias-- patron de diseño
        private readonly IConfiguration _configuration;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public UsuarioController(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }

        //AQUI SE CONSUMIA A TRAVES DE SWAGGER O POSTMAN // GETALL

        //exponer la logica de negocio a internet 


        //HTTP 
        //URL 
        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    ML.Result result = BL.Usuario.GetAll(usuario);


        //    if (result.Correct)
        //    {
        //        usuario.Usuarios = result.Objects;
        //        return View(usuario);
        //    }
        //    else
        //    {
        //        return View(usuario);
        //    }
        //}


        //[HttpGet]
        //public ActionResult GetAll()
        //{
        //    ML.Usuario usuario = new ML.Usuario();
        //    ML.Result result = BL.Usuario.GetAll(usuario);

        //    usuario.Usuarios = result.Objects;


        //}

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Usuario usuario = new ML.Usuario();

            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            try
            {
                using (var client = new HttpClient())
                {
                    string urlApi = _configuration["urlApi"];
                    client.BaseAddress = new Uri(urlApi);

                    var responseTask = client.GetAsync("Usuario/GetAll");
                    responseTask.Wait();

                    var resultServicio = responseTask.Result;

                    if (resultServicio.IsSuccessStatusCode)
                    {
                        var readTask = resultServicio.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        foreach (var resultItem in readTask.Result.Objects)
                        {
                            ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                            result.Objects.Add(resultItemList);
                        }
                    }
                    usuario.Usuarios = result.Objects;
                }

            }
            catch (Exception ex)
            {
            }

            return View(usuario);
        } //Visualizar los registros // AQUI SE HACE CONSUMO MEDIANTE CONTROLADOR DE GETALL



        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            //ML.Usuario usuario = new ML.Usuario();
            //ML.Result result = BL.Usuario.GetAll(usuario);
            ML.Result result = new ML.Result();
            result = BL.Usuario.GetAll(usuario);

            if (result.Correct)

            {
                usuario.Usuarios = result.Objects;

                return View(usuario);
            }
            else
            {
                return View(usuario);
            }
        }


        //AQUI SE CONSUMIA A TRAVES DE SWAGGER O POSTMAN      //para obtener nuevamente la vista con GetById
        //[HttpGet]//para mostrar la vista
        //public ActionResult Form(int? IdUsuario)
        //{
        //    ML.Result resultRol = BL.Rol.GetAll();
        //    ML.Result resultPais = BL.Pais.GetAll();

        //    ML.Usuario usuario = new ML.Usuario();

        //    usuario.Rol = new ML.Rol();
        //    usuario.Direccion = new ML.Direccion();
        //    usuario.Direccion.Colonia = new ML.Colonia();
        //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
        //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

        //    if (resultRol.Correct && resultPais.Correct)
        //    {

        //        usuario.Rol.Roles = resultRol.Objects;
        //        usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
        //    }
        //    if (IdUsuario == null)
        //    {
        //        //add //formulario vacio
        //        return View(usuario);
        //    }
        //    else
        //    {
        //        //getById

        //        ML.Result result = BL.Usuario.GetById(IdUsuario.Value); //2

        //        if (result.Correct)
        //        {
        //            usuario = (ML.Usuario)result.Object;//unboxing
        //            usuario.Rol.Roles = resultRol.Objects;
        //            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

        //            ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
        //            ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
        //            ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

        //            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
        //            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
        //            usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
        //            //update
        //            return View(usuario);
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Ocurrio al consultar la información del alumno";
        //            return View("Modal");
        //        }
        //    }
        //}



        //AQUI SE CONSUMIA A TRAVES DE SWAGGER O POSTMAN
        //[HttpPost] //Hacer el registro
        //public ActionResult Form(ML.Usuario usuario)
        //{
        //    IFormFile file = Request.Form.Files["fuImage"];

        //    if (file != null)
        //    {
        //        byte[] imagen = ConvertToBytes(file);

        //        usuario.Imagen = Convert.ToBase64String(imagen);
        //    }


        //    ML.Result result = new ML.Result();
        //    //if (ModelState.IsValid == true)
        //    //{

        //    if (usuario.IdUsuario != null)
        //    {
        //        //Update
        //        result = BL.Usuario.Update(usuario);
        //        ViewBag.Message = "Se ha actualizado el registro";
        //    }
        //    else
        //    {
        //        //Add
        //        result = BL.Usuario.Add(usuario);
        //        ViewBag.Message = "Se ha agregado el registro";
        //    }
        //    if (result.Correct)
        //    {
        //        return PartialView("Modal");
        //    }
        //    else
        //    {
        //        return PartialView("Modal");
        //    }
        //    //}
        //    //else {

        //    //    usuario.Rol = new ML.Rol();
        //    //    usuario.Direccion = new ML.Direccion();
        //    //    usuario.Direccion.Colonia = new ML.Colonia();
        //    //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
        //    //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //    //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

        //    //    ML.Result resultRol = BL.Rol.GetAll();
        //    //    ML.Result resultPais = BL.Pais.GetAll();

        //    //    usuario.Rol.Roles = resultRol.Objects;
        //    //    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

        //    //    return View(usuario);
        //    //}
        //}
        //para obtener nuevamente la vista con GetById

        [HttpGet]//para mostrar la vista
        public ActionResult Form(int? IdUsuario) //AQUI SE HACE CONSUMO MEDIANTE CONTROLADOR DE GETBYID
        {
            ML.Result resultRol = BL.Rol.GetAll();
            ML.Result resultPais = BL.Pais.GetAll();

            ML.Usuario usuario = new ML.Usuario();

            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (resultRol.Correct && resultPais.Correct)
            {

                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
            }
            if (IdUsuario == null)
            {
                //add //formulario vacio
                return View(usuario);
            }
            else
            {
                //getById
                //ML.Result result = BL.Usuario.GetById(IdUsuario.Value); //2
                ML.Result result = new ML.Result();

                using (var client = new HttpClient())
                    try
                    {
                        client.BaseAddress = new Uri(_configuration["urlApi"]);
                        var responseTask = client.GetAsync("Usuario/GetById/" + IdUsuario);
                        responseTask.Wait();

                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)

                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();

                            ML.Usuario resultItemList = new ML.Usuario();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            usuario.Direccion = new ML.Direccion();
                            usuario.Direccion.Colonia = new ML.Colonia();
                            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();


                            usuario = (ML.Usuario)result.Object;//unboxing
                            usuario.Rol.Roles = resultRol.Objects;
                            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                            ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                            ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                            ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);

                            usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                            usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                            usuario.Direccion.Colonia.Colonias = resultColonia.Objects;
                            //update
                            return View(usuario);
                        }
                        else
                        {
                            ViewBag.Message = "Ocurrio al consultar la información del alumno";
                            return View("Modal");
                        }
                    }
                    catch (Exception ex)
                    {
                        result.Correct = false;
                        result.ErrorMessage = ex.Message;
                    }
                return View(usuario);

            }
        }



        [HttpPost] //Hacer el registro //AQUI SE HACE CONSUMO MEDIANTE CONTROLADOR DE ADD Y UPDATE
        public ActionResult Form(ML.Usuario usuario)
        {
            IFormFile file = Request.Form.Files["fuImage"];

            if (file != null)
            {
                byte[] imagen = ConvertToBytes(file);

                usuario.Imagen = Convert.ToBase64String(imagen);
            }

            if (usuario.IdUsuario != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["urlApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Update/"+usuario.IdUsuario, usuario);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha modificado el registro";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "No se ha modificado el registro";
                        return PartialView("Modal");
                    }
                }

                //return View("GetAll");

            }
            else
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration["urlApi"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Usuario>("Usuario/Add", usuario);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se ha agregado el registro";
                        return PartialView("Modal");
                    }
                    else
                    {
                        ViewBag.Message = "No se ha agregado el registro";
                        return PartialView("Modal");
                    }
                }
            }



            //return View("GetAll");


            //ML.Result result = new ML.Result();
            //if (ModelState.IsValid == true)
            //{

            //if (usuario.IdUsuario != null)
            //{
            //    //Update
            //    result = BL.Usuario.Update(usuario);
            //    ViewBag.Message = "Se ha actualizado el registro";
            //}
            //else
            //{
            //    //Add
            //    result = BL.Usuario.Add(usuario);
            //    ViewBag.Message = "Se ha agregado el registro";
            //}
            //if (result.Correct)
            //{
            //    return PartialView("Modal");
            //}
            //else
            //{
            //    return PartialView("Modal");
            //}
            //}
            //else {

            //    usuario.Rol = new ML.Rol();
            //    usuario.Direccion = new ML.Direccion();
            //    usuario.Direccion.Colonia = new ML.Colonia();
            //    usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            //    usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            //    usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            //    ML.Result resultRol = BL.Rol.GetAll();
            //    ML.Result resultPais = BL.Pais.GetAll();

            //    usuario.Rol.Roles = resultRol.Objects;
            //    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

            //    return View(usuario);
            //}
        }



        //AQUI SE CONSUMIA A TRAVES DE SWAGGER O POSTMAN
        //public ActionResult Delete(int IdUsuario)
        //{
        //    ML.Result result = BL.Usuario.Delete(IdUsuario);

        //    if (result.Correct)
        //    {
        //        ViewBag.Message = "Se ha eliminado el registro";
        //        return PartialView("Modal");
        //    }
        //    else
        //    {
        //        ViewBag.Message = "No se ha podido registrar el usuario" + result.ErrorMessage;
        //        return PartialView("Modal");
        //    }
        //}

        public ActionResult Delete(int IdUsuario) //Eliminar //Aqui se hace consumo mediante controlador
        {
            ML.Result resultListUsuarios = new ML.Result();
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_configuration["urlApi"]);

                var postTask = client.GetAsync("Usuario/Delete/" + IdUsuario);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    resultListUsuarios = BL.Usuario.GetAll(usuario);
                    ViewBag.Message = "Se ha eliminado el registro";
                    return PartialView("Modal");
                }
            }
            resultListUsuarios = BL.Usuario.GetAll(usuario);
            return View("GetAll", resultListUsuarios);
        }

        [HttpPost]
        public JsonResult EstadoGetByIdPais(int idPais)
        {
            ML.Result result = new ML.Result();
            result = BL.Estado.GetByIdPais(idPais);

            return Json(result.Objects);
        }

        [HttpPost]
        public JsonResult MunicipioGetByIdEstado(int idEstado)
        {
            ML.Result result = new ML.Result();
            result = BL.Municipio.GetByIdEstado(idEstado);

            return Json(result.Objects);
        }
        [HttpPost]
        public JsonResult ColoniaGetByIdMunicipio(int idMunicipio)
        {
            ML.Result result = new ML.Result();
            result = BL.Colonia.GetByIdMunicipio(idMunicipio);

            return Json(result.Objects);
        }
        public static byte[] ConvertToBytes(IFormFile imagen)
        {

            using var fileStream = imagen.OpenReadStream();

            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, (int)fileStream.Length);

            return bytes;
        }
        [HttpPost]
        public JsonResult CambiarStatus(int idUsuario, bool status)
        {
            ML.Result result = new ML.Result();
            result = BL.Usuario.UsuarioChangeStatus(idUsuario, status);

            return Json(result);
        }
        //[HttpGet]
        //public ActionResult CargaMasiva()
        //{
        //    ML.Result result = new ML.Result();

        //    return View(result);
        //}
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string passwordd)
        {
            ML.Result result = BL.Usuario.GetByUsername(username);
            if (result.Correct)
            {
                ML.Usuario usuario = (ML.Usuario)result.Object;
                if (passwordd == usuario.Passwordd)
                {
                    return RedirectToAction("GetAll", "Usuario");
                }
                else
                {
                    ViewBag.Message = "Las credenciales no coinciden";
                    return PartialView("ModalLogin");
                }
            }
            else
            {
                ViewBag.Message = "El usuario no existe, verifica tus datos nuevamente.";
                return PartialView("ModalLogin");
            }
        }



    }
}
