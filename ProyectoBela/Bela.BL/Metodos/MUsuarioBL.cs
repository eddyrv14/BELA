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

        public string InsertPersona(Usuario persona)
        {
            return usuarios.InsertPersona(persona);
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

        public string EliminarCuenra(int idUsuario)
        {
            return usuarios.EliminarCuenta(idUsuario);
        }
    }
}
