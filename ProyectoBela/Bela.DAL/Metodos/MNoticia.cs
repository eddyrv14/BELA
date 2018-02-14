using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using MySql.Data.MySqlClient;
using System.Data;
namespace Bela.DAL.Metodos
{
   public  class MNoticia
    {

       private OrmLiteConnectionFactory _conex;
       private IDbConnection _db;

       public MNoticia()
       {
           _conex = new OrmLiteConnectionFactory(BD.Default.conexion, MySqlDialect.Provider);
           _db = _conex.Open();
       }
    }
}
