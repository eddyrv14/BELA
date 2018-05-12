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
    public class MUsuarioBL:IUsuario
    {
        MUsuarioDal usuarios = new MUsuarioDal();

        public Usuario Login(string usuario, string contrasena)
        {
            return usuarios.Login(usuario, contrasena);
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
    }
}
