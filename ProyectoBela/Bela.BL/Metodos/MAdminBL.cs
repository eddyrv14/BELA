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
     public class MAdminBL:IAdmin
    {
         MAdminDal adminMetodos=new MAdminDal();

        public List<Rol> listaRoles()
        {
            return adminMetodos.ListaRoles();
        }

        public List<Seccion> ListaSecciones()
        {
            return adminMetodos.ListaSecciones();
        }

        public List<Materia> ListaMaterias()
        {
            return adminMetodos.ListaMaterias();
        }

        public string InsertPersona(Usuario persona)
        {
            return adminMetodos.InsertPersona(persona);
        }

        public void InsertarEstudianteSeccion(int idSeccion)
        {
            adminMetodos.InsertarEstudianteSeccion(idSeccion);
        }


        public List<Usuario> ListaUsuarios()
        {
            return adminMetodos.ListaUsuarios();
        }


        public Usuario BuscarCuenta(int idPersona)
        {
            return adminMetodos.BuscarCuenta(idPersona);
        }


        public string ModificarCuenta(Usuario usuario)
        {
            return adminMetodos.ModificarCuenta(usuario);
        }

        public void ModificarEstudianteSeccion(int idUsuario, int idSeccion)
        {
            adminMetodos.ModificarEstudianteSeccion(idUsuario, idSeccion);
        }

        public string EliminarCuenra(int idUsuario)
        {
            return adminMetodos.EliminarCuenta(idUsuario);
        }


        public string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion)
        {
            return adminMetodos.AgregarMateriaProf(idMateria, idUsuario, idSeccion);
        }

    }
}
