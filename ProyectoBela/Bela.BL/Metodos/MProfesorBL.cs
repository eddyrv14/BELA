using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.BL.Interfaces;
using Bela.Datos;


using Bela.DAL.Metodos;
using System.Text.RegularExpressions;

namespace Bela.BL.Metodos
{
    public class MProfesorBL : IProfesor
    {
        MProfesorDal profesoresMetodos = new MProfesorDal();

        public string crearMaterial(DetalleMaterial material)
        {
            DateTime fecha = Convert.ToDateTime(DateTime.Now.ToString("G"));
            string limDoc = Regex.Replace(material.material, @"^[~]", "");
            material.fechaHora = fecha;
            material.material = limDoc;
            return profesoresMetodos.crearMaterial(material);
        }

        public void AgregarMaterialesAdicionales(string material, string nombreMaterial)
        {
            string limDoc = Regex.Replace(material, @"^[~]", "");
            material = limDoc;
            profesoresMetodos.AgregarMaterialesAdicionales(material, nombreMaterial);
        }

        public List<MateriaDeta> ListaMaterialesProfesores(int idUsuario)
        {
            return profesoresMetodos.ListaMaterialesProfesores(idUsuario);
        }


        public MateriaDeta BuscarMateria(int idMateria)
        {
            return profesoresMetodos.BuscarMateria(idMateria);
        }

        public List<MasMaterial> ListaMaterialesAdicionales(int idMaterial)
        {
            return profesoresMetodos.ListaMaterialesAdicionales(idMaterial);
        }
    }
}
