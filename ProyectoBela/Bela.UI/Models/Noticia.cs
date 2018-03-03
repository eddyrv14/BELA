﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bela.UI.Models
{
    public class Noticia
    {
        public int idNoticia { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string contenido { get; set; }
        public string imagen { get; set; }
        public DateTime fechaYHora { get; set; }
    }
}