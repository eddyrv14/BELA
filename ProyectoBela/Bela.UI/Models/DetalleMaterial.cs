using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class DetalleMaterial
    {
        public int idMaterial { get; set; }
        public int idUsuario { get; set; }
        public int idDetalleMateria { get; set; }
        [Required]
        public string titulo { get; set; }
        [Required]
        public string mensaje { get; set; }
        public string material { get; set; }
        public string nombreMaterial { get; set; }
        public DateTime fechaHora { get; set; }
    }
}