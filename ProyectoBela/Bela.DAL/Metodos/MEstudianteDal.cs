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
   public  class MEstudianteDal : IEstudiante
    {
        private OrmLiteConnectionFactory _conex;
        private IDbConnection _db;


        public MEstudianteDal()
        {
            _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
            _db = _conex.Open();
        }

        public EstudianteSeccion BuscarSeccion(int idUsuario)
        {
            var re = _db.Select<EstudianteSeccion>(x => x.idUsuario == idUsuario).FirstOrDefault();
            return re;
        }

        public List<MateriaDeta> listaMaterias(int idSeccion)
        {
            var re = _db.SqlList<MateriaDeta>("EXEC listaMateriasEstudiante @idSeccion", new { idSeccion = idSeccion }).ToList();
            return re;
        }
    }
}
