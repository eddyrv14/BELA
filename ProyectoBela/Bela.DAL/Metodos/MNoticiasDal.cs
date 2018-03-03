﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using System.Data;
using Bela.DAL.Interfaces;
using Bela.Datos;

namespace Bela.DAL.Metodos
{
 public   class MNoticiasDal:INoticia
    {

     private OrmLiteConnectionFactory _conex;
     private IDbConnection _db;


     public MNoticiasDal()
     {
         _conex = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
         _db = _conex.Open();
     }


     public List<Noticia> listaNoticias()
     {
         throw new NotImplementedException();
     }

     public List<Noticia> ultimasNoticias()
     {
          var re = _db.SqlList<Noticia>("EXEC ultimasNoticias").ToList();
          return re;
     }


     public void eliminarNoticia(int idNoticia)
     {
         throw new NotImplementedException();
     }

    }
}