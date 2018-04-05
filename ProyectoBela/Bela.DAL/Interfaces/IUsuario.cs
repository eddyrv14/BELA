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
        string InsertPersona(Usuario persona);
        List<Usuario> ListaUsuarios();
        Usuario BuscarCuenta(int idPersona);
        string ModificarCuenta(Usuario usuario);
        string EliminarCuenta(int idUsuario);
    }
}
