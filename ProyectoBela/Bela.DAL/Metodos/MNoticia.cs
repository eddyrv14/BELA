using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
namespace Bela.DAL.Metodos
{
   public class MNoticia
    {

       private OrmLiteConnectionFactory _db;
       private IDbConnection __conex;

       public MNoticia()
       {
        //   __conex = new OrmLiteConnectionFactory();
       }
    }
}
