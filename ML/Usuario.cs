using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int? IdUsuario { get; set; }

        //[Required]
        //[RegularExpression("[a-zA-Z]", ErrorMessage = "Solo letras")]
        public string Nombre { get; set; }

        //[Required]
        //[RegularExpression("[a-zA-Z]", ErrorMessage = "Solo letras")]
        public string ApellidoPaterno { get; set; }
      
        public string ApellidoMaterno { get; set; }
        //[Required]
        //[EmailAddress]
        public string Email { get; set; }
        //[Required]

        public string UserName { get; set; }
        //[Required]
        //[RegularExpression("(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[#?!@$%^&*-]).{10,}$", ErrorMessage="Debe contener minimo, una letra mayuscula, 1 minuscula, 1 caracter y longitud de 10")]
        public string Passwordd { get; set; }

        public string FechaNacimiento { get; set; }

        public ML.Rol Rol { get; set; }
        //[Required]
        public string Sexo { get; set; }
        //[Required]
        //[StringLength(10)]
        public string Telefono { get; set; }
        //[StringLength(10)]
        public string Celular { get; set; }
        //[StringLength(18)]
        public string CURP { get; set; }
        public string Imagen { get; set; }
        public ML.Direccion Direccion { get; set; }
        public string NombreCompleto { get; set; }
        public List<object> Usuarios { get; set; }
        public bool? Status { get; set; }
    }
}
