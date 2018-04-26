using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class MateriaDeta
    {
        public int idDetalleMateria { get; set; }
        public string materia { get; set; }
        public string nomProfesor { get; set; }
        public string seccion { get; set; }
        public int grado { get; set; }
    }
}