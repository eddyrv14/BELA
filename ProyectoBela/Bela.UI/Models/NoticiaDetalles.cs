using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class NoticiaDetalles
    {
        public int idNoticia { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public DateTime fechaYHora { get; set; }
    }
}