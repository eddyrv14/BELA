﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.BL.Interfaces;
using Bela.Datos;
using Bela.DAL.Metodos;


namespace Bela.BL.Metodos
{
   public class MNoticiaBL:INoticia
    {
        MNoticiasDal noticias = new MNoticiasDal();

        public List<Noticia> listaNoticias()
        {
            throw new NotImplementedException();
        }

        public List<Noticia> ultimasNoticias()
        {
            return noticias.ultimasNoticias();
        }

        public void insertarNoticia(Noticia noticia)
        {
            throw new NotImplementedException();
        }
    }
}