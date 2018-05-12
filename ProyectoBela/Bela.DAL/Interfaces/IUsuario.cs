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

      
        string ActivarNotificaciones(string correo);
        string ActivarNotificacionesInternas(string correo);

        List<NotiExternas> ListaCorreoNotiExternas();
        List<NotiInternas> ListaCorreoNotiInternas();
    }
}
