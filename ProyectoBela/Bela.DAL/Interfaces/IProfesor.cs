using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;

namespace Bela.DAL.Interfaces
{
    public interface IProfesor
    {
        string crearMaterial(DetalleMaterial material);
        List<MateriaDeta> ListaMaterialesProfesores(int idUsuario);
        MateriaDeta BuscarMateria(int idMateria);
    }
}
