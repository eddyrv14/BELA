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
    public class MUsuarioBL : IUsuario
    {
        MUsuarioDal usuarios = new MUsuarioDal();

        public Usuario Login(string usuario, string contrasena)
        {
            return usuarios.Login(usuario, contrasena);
        }


        public List<Rol> listaRoles()
        {
            return usuarios.ListaRoles();
        }

        public List<Seccion> ListaSecciones()
        {
            return usuarios.ListaSecciones();
        }

        public List<Materia> ListaMaterias()
        {
            return usuarios.ListaMaterias();
        }

        public string InsertPersona(Usuario persona)
        {
            return usuarios.InsertPersona(persona);
        }

        public void InsertarEstudianteSeccion(int idSeccion)
        {
            usuarios.InsertarEstudianteSeccion(idSeccion);
        }


        public List<Usuario> ListaUsuarios()
        {
            return usuarios.ListaUsuarios();
        }


        public Usuario BuscarCuenta(int idPersona)
        {
            return usuarios.BuscarCuenta(idPersona);
        }


        public string ModificarCuenta(Usuario usuario)
        {
            return usuarios.ModificarCuenta(usuario);
        }

        public void ModificarEstudianteSeccion(int idUsuario, int idSeccion)
        {
            usuarios.ModificarEstudianteSeccion(idUsuario, idSeccion);
        }

        public string EliminarCuenra(int idUsuario)
        {
            return usuarios.EliminarCuenta(idUsuario);
        }

        public string ActivarNoticaciones(string correo)
        {
            return usuarios.ActivarNotificaciones(correo);
        }


        public string ActivarNoticacionesInternas(string correo)
        {
            return usuarios.ActivarNotificacionesInternas(correo);
        }


        public List<NotiExternas> ListaCorreoNotiExternas()
        {
            return usuarios.ListaCorreoNotiExternas();
        }


        List<NotiInternas> IUsuario.ListaCorreoNotiInternas()
        {
            return usuarios.ListaCorreoNotiInternas();
        }





        public string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion)
        {
            return usuarios.AgregarMateriaProf(idMateria, idUsuario, idSeccion);
        }
    }
}
