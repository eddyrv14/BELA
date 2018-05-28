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
   public class MEstudianteDal :IEstudiante
    {

       private OrmLiteConnectionFactory _conex;
       private IDbConnection _db;


       public MEstudianteDal()
       {
           _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
          
       }


        public List<MateriaDeta> listaMaterias(int idSeccion)
        {
            _db = _conex.Open();
            var re = _db.SqlList<MateriaDeta>("EXEC listaMateriasEstudiante @idSeccion", new { idSeccion = idSeccion }).ToList();
            _db.Close();
            return re;
        }


        public EstudianteSeccion BuscarSeccion(int idUsuario)
        {
            _db = _conex.Open();
            var re = _db.Select<EstudianteSeccion>(x => x.idUsuario == idUsuario).FirstOrDefault();
            _db.Close();
            return re;
        }
    }
}
