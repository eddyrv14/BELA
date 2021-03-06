﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;

namespace Bela.BL.Interfaces
{
   public interface IProfesor
    {
       string crearMaterial(DetalleMaterial materia);
       void AgregarMaterialesAdicionales(string material, string nombreMaterial);
       List<MateriaDeta> ListaMaterialesProfesores(int idUsuario);
       MateriaDeta BuscarMateria(int idMateria);
       List<MasMaterial> ListaMaterialesAdicionales(int idMaterial);
    }
}
