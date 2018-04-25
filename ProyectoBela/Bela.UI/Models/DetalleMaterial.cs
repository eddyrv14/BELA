using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace Bela.UI.Models
{
    public class DetalleMaterial
    {
        public int idMaterial { get; set; }
        public int idUsuario { get; set; }
        public int idDetalleMateria { get; set; }
        //public string nombreMateria { get; set; }
        //public string seccion { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string mensaje { get; set; }
        public string material { get; set; }
        public DateTime fechaHora { get; set; }
    }
}