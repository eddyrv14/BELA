using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Data;
using System.Data.SqlClient;
using Bela.DAL.Interfaces;

namespace Bela.DAL.Metodos
{
    public class MProfesorDal : IProfesor
    {
        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;
        private SqlConnection cn;

        public MProfesorDal()
        {
            cn = new SqlConnection(BD.Default.conexion);
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }


        public string crearMaterial(Datos.DetalleMateria material)
        {
            throw new NotImplementedException();
        }
    }
}
