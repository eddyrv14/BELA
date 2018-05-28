using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class EstudianteSeccionDeta
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string cedula { get; set; }
        public string Seccion { get; set; }    //*<=//
    }
}