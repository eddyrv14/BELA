using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Bela.UI.Models
{
    public class Usuario:Persona
    {
        public int idUsuario { get; set; }
        public int rol { get; set; }
        public string rolNombre { get; set; }
        [Required(ErrorMessage="Ingrese nombre de usuario")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]
        public string contrasena { get; set; }

    }
}