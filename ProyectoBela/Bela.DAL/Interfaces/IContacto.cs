using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;

namespace Bela.DAL.Interfaces
{
    public interface IContacto
    {
        void EnvioMensaje(MensajeContacto mensaje);
        List<MensajeContacto> listaMensajes();

    }
}
