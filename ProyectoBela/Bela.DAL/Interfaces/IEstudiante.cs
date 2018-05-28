using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;


namespace Bela.DAL.Interfaces
{
    public interface IEstudiante
    {
        List<MateriaDeta> listaMaterias(int idSeccion);
        EstudianteSeccion BuscarSeccion(int idUsuario);
    }
}
