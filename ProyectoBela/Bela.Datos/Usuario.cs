using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bela.Datos
{
    public class Usuario:Persona
    {
        public int idUsuario{get;set;}
        public int rol { get; set; }
        public string rolNombre { get; set; }
        public string usuario { get; set; }
        public string contrasena { get; set; }
    }
}
