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
        [Required]
        public string asunto { get; set; }
        [Required]
        public string correo { get; set; }
        
        public string mensaje { get; set; }
    }
}