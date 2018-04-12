using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bela.Datos
{
   public class DetalleMateria
    {
        public int idMaterial { get; set; }
        public int idUsuario { get; set; }
        public int idDetalleMateria { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string material { get; set; }
        public DateTime fechaHora { get; set; }
    }
}
