using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.BL.Interfaces;
using Bela.DAL.Metodos;
using Bela.Datos;

namespace Bela.BL.Metodos
{
    public class MContactoBL:IContacto
    {
        MContactoDal contacto = new MContactoDal();

        public void EnvioMensaje(MensajeContacto mensaje)
        {
            contacto.EnvioMensaje(mensaje);
        }


        public List<MensajeContacto> listaMensajes()
        {
            return contacto.listaMensajes();
        }
    }
}
