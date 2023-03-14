using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]
        [Route("api/Usuario/GetAll")]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.GetAll(usuario);
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
        [Route("api/Usuario/GetById/{id}")]
        public ActionResult GetById(int id)
        {
            ML.Result result = BL.Usuario.GetById(id);
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
        [Route("api/Usuario/Get/{id}")]
        public ActionResult Get(int id)
        {
            ML.Result result = BL.Usuario.GetById(id);
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
        [Route("api/Usuario/Add")]
        public ActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Add(usuario);
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
        [Route("api/Usuario/Update/{IdUsuario}")]
        public ActionResult Update([FromBody] ML.Usuario usuario)
        {
            
            ML.Result result = BL.Usuario.Update(usuario);
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
        [Route("api/Usuario/Delete/{IdUsuario}")]
        public ActionResult Delete(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.Delete(IdUsuario);
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
