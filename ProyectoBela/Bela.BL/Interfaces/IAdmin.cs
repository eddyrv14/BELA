using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Metodos;

namespace Bela.BL.Interfaces
{
    public interface IAdmin
    {
        /*Necesario para crear cuentas*/
        List<Rol> listaRoles();
        List<Seccion> ListaSecciones();
        List<Materia> ListaMaterias();

        string InsertPersona(Usuario persona);
        void InsertarEstudianteSeccion(int idSeccion);

        List<Usuario> ListaUsuarios();

        /*CRUD*/
        Usuario BuscarCuenta(int idPersona);
        string ModificarCuenta(Usuario usuario);
        void ModificarEstudianteSeccion(int idUsuario, int idSeccion);
        string EliminarCuenra(int idUsuario);

        /* Agregar Materia al profesor*/
        string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion);
        List<MateriaProf> ListaMateriasProf(int idUsuario);
        string EliminarMateriaProf(int idMateriaPr);


        /*Secciones*/
        List<EstudianteSeccionDeta> ListaEstudiantes();



    }
}
