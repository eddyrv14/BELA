﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Metodos;

namespace Bela.BL.Interfaces
{
    public interface IUsuario
    {
        Usuario Login(string usurio, string contrasena);
    }
}
