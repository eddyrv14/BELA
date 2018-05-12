﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bela.Datos;
using Bela.DAL.Metodos;

namespace Bela.DAL.Interfaces
{
   public interface IAdmin
    {
        /*Necesario para crear cuentas*/
        List<Rol> ListaRoles();
        List<Seccion> ListaSecciones();

        string InsertPersona(Usuario persona);
        void InsertarEstudianteSeccion(int idSeccion);

        List<Usuario> ListaUsuarios();

        /*CRUD*/
        Usuario BuscarCuenta(int idPersona);
        string ModificarCuenta(Usuario usuario);
        void ModificarEstudianteSeccion(int idUsuario, int idSeccion);
        string EliminarCuenta(int idUsuario);

        /* Agregar Materia al profesor*/
        string AgregarMateriaProf(int idMateria, int idUsuario, int idSeccion);
    }
}
