using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Data;
using Bela.DAL.Interfaces;

namespace Bela.DAL.Metodos
{
 public   class MNoticias:INoticia
    {

     private OrmLiteConnectionFactory _conex;
     private IDbConnection _db;


     public MNoticias()
     {
         _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
         _db = _conex.Open();
     }


     public List<Datos.Noticia> listaNoticias()
     {
         throw new NotImplementedException();
     }

     public List<Datos.Noticia> ultimasNoticias()
     {
         throw new NotImplementedException();
     }

     public void insertarNoticia(Datos.Noticia noticia)
     {
         throw new NotImplementedException();
     }
    }
}
