﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;

namespace Bela.BL.Interfaces
{
   public  interface INoticia
    {
        List<Noticia> listaNoticias();
        List<Noticia> ultimasNoticias();
        void insertarNoticia(Noticia noticia);
    }
}
