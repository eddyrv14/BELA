using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;

namespace Bela.DAL.Interfaces
{
    public interface IUsuario
    {
        Usuario Login(string usuario, string contrasena);

        List<Rol> ListaRoles();
        List<Seccion> ListaSecciones();
        List<Materia> ListaMaterias();


        string InsertPersona(Usuario persona);
        void InsertarEstudianteSeccion(int idSeccion);
        List<Usuario> ListaUsuarios();
        Usuario BuscarCuenta(int idPersona);
        string ModificarCuenta(Usuario usuario);
        void ModificarEstudianteSeccion(int idUsuario, int idSeccion);
        string EliminarCuenta(int idUsuario);
        string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion);


        string ActivarNotificaciones(string correo);
        string ActivarNotificacionesInternas(string correo);

        List<NotiExternas> ListaCorreoNotiExternas();
        List<NotiInternas> ListaCorreoNotiInternas();

    }
}
