using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class Noticia
    {

        public int idNoticia { get; set; }
        public int idUsuario { get; set; }
        public int idtipo { get; set; }
        [Required]
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public DateTime fechaYHora { get; set; }
    }
}