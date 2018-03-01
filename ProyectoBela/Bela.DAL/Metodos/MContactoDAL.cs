using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.DAL.Interfaces;
using System.Data;
using ServiceStack.OrmLite;
using Bela.Datos;



namespace Bela.DAL.Metodos
{
    public class MContactoDAL : IContacto
    {

        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;

        public MContactoDAL()
        {
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }


        public void EnvioMensaje(MensajeContacto mensaje)
        {
            _db.SqlScalar<MensajeContacto>("EXEC insertarMensaje @correo,@asunto,@mensaje", new
            {
                correo = mensaje.correo,
                asunto = mensaje.asunto,
                mensaje = mensaje.mensaje,

            });
        }


        public List<MensajeContacto> listaMensajes()
        {
            throw new NotImplementedException();
        }
    }
}
