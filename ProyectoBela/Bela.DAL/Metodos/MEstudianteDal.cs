using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using ServiceStack.OrmLite;
using Bela.DAL.Interfaces;
using System.Data;

namespace Bela.DAL.Metodos
{
   public  class MEstudianteDal
    {
        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;


        public MEstudianteDal()
        {
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }


        public List<Materia> listaMaterias(int idUsuario)
        {
            var re = _db.SqlList<Materia>("EXEC listaMaterias @idUsuario", new { @idUsuario = idUsuario }).ToList();
            return re;
        }
    }
}
