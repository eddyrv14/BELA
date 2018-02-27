using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Bela.UI.Models
{
    public class MensajeContacto
    {
        public int idMensajeContacto { get; set; }
        [Required(ErrorMessage="Ingrese un asunto")]
        public string asunto { get; set; }
        [Required(ErrorMessage="Ingrese tu correo")]
        public string correo { get; set; }
        
        public string mensaje { get; set; }
    }
}