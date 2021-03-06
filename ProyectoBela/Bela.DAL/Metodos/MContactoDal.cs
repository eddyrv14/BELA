﻿using System;
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
    public class MContactoDal : IContacto
    {

        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;

        public MContactoDal()
        {
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            
        }


        public void EnvioMensaje(MensajeContacto mensaje)
        {
            _db = _conex.Open();
            _db.SqlScalar<MensajeContacto>("EXEC insertarMensaje @correo,@asunto,@mensaje", new
            {
                correo = mensaje.correo,
                asunto = mensaje.asunto,
                mensaje = mensaje.mensaje,

            });
            _db.Close();
        }


        public List<MensajeContacto> listaMensajes()
        {
            _db = _conex.Open();
            var re = _db.Select<MensajeContacto>();
            _db.Close();
            return  re;
        }
    }
}
