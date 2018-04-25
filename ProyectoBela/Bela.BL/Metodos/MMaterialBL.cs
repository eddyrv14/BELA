using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.BL.Interfaces;
using Bela.DAL.Metodos;

namespace Bela.BL.Metodos
{
   public class MMaterialBL
    {
        MMaterialDal materialMetodos = new MMaterialDal();
        public List<DetalleMaterial> ListaMateriales(int idDetalleMateria)
        {
            return materialMetodos.ListaMateriales(idDetalleMateria);
        }


        public DetalleMaterial BuscarMaterial(int idMaterial)
        {
            return materialMetodos.BuscarMaterial(idMaterial);
        }

    }
}
