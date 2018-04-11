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
        string InsertPersona(Usuario persona);
        List<Usuario> ListaUsuarios();
        Usuario BuscarCuenta(int idPersona);
        string ModificarCuenta(Usuario usuario);
        string EliminarCuenra(int idUsuario);

        string ActivarNoticaciones(string correo);
        List<NotiExternas> ListaCorreoNotiExternas();
    }
}

