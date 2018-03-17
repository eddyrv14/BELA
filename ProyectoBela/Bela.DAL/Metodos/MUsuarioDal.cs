using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Interfaces;
using ServiceStack.OrmLite;
using System.Data;

namespace Bela.DAL.Metodos
{
    public class MUsuarioDal : IUsuario
    {
        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;

        public MUsuarioDal()
        {
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();

        }

        public Usuario Login(string usuario, string contrasena)
        {
            var re = _db.SqlList<Usuario>("EXEC login @usuario,@contrasena", new { usuario = usuario, contrasena = contrasena }).FirstOrDefault();
            return re;
        }
    }
}

