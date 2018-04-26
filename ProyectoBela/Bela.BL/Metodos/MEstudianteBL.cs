using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Metodos;
using Bela.BL.Interfaces;

namespace Bela.BL.Metodos
{
    public class MEstudianteBL:IEstudiante
    {
        MEstudianteDal estudiantesMeto = new MEstudianteDal();

        public List<MateriaDeta> listaMaterias(int idUsuario)
        {
            return estudiantesMeto.listaMaterias(idUsuario);
        }

        public EstudianteSeccion BuscarSeccion(int idUsuario)
        {
            return estudiantesMeto.BuscarSeccion(idUsuario);
        }

    }
}
