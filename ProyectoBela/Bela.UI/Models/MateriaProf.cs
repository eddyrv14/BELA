using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class MateriaProf
    {
        public int idPrMa { get; set; }
        public int idUsuario { get; set; }
        public string nomMateria { get; set; }
        public string nomSeccion { get; set; }
    }
}