using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Metodos;

namespace Bela.BL.Interfaces
{
    public interface IUsuario
    {
        Usuario Login(string usurio, string contrasena);
        List<Rol> listaRoles();
        List<Seccion> ListaSecciones();
        List<Materia> ListaMaterias();
        string InsertPersona(Usuario persona);
        void InsertarEstudianteSeccion(int idSeccion);

        List<Usuario> ListaUsuarios();
        Usuario BuscarCuenta(int idPersona);
        string ModificarCuenta(Usuario usuario);
        void ModificarEstudianteSeccion(int idUsuario, int idSeccion);
        string EliminarCuenra(int idUsuario);
        string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion);

        string ActivarNoticaciones(string correo);
        string ActivarNoticacionesInternas(string correo);
        List<NotiExternas> ListaCorreoNotiExternas();
        List<NotiInternas> ListaCorreoNotiInternas();

    }
}

