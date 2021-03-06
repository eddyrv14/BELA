﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bela.Datos;
using Bela.BL.Interfaces;
using Bela.BL.Metodos;
using AutoMapper;

namespace Bela.UI.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuario usuariosActividad;
        IEstudiante estudianteActividad;
        public UsuarioController()
        {
            usuariosActividad = new MUsuarioBL();
            estudianteActividad = new MEstudianteBL();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Usuario usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var usuarDatos = usuariosActividad.Login(usuarios.usuario, usuarios.contrasena);


                    if (usuarDatos != null)
                    {
                        Session["UserID"] = usuarDatos.idPersona;
                        Session["UserNombre"] = usuarDatos.nombre;
                        Session["UserApellido1"] = usuarDatos.apellido1;
                        Session["UserApellido2"] = usuarDatos.apellido2;
                        Session["UserCorreo"] = usuarDatos.correo;
                        Session["UserCedula"] = usuarDatos.cedula;
                        Session["rol"] = usuarDatos.rolNombre;
                        Session["UserUsuario"] = usuarDatos.usuario;
                        Session["UserContrasena"] = usuarDatos.contrasena;

                    }
                    else
                    {
                        ViewData["mensajeLogin"] = "Usuario o contraseña incorrecta";
                        return View();
                    }

                    if (usuarDatos.rolNombre.Equals("Administrador"))
                    {
                        return RedirectToAction("Inicio", "Admin");
                    }
                    else if (usuarDatos.rolNombre.Equals("Profesor"))
                    {
                        return RedirectToAction("Inicio", "Profesor");
                    }
                    else if (usuarDatos.rolNombre.Equals("Estudiante"))
                    {
                        var Datos = estudianteActividad.BuscarSeccion(usuarDatos.idPersona);
                        Session["UserSeccion"] = Datos.idSeccion;

                        return RedirectToAction("Inicio", "Estudiante");
                    }

                }
                return View();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un errror" + ex.Message);
                return View();
            }
        }
        public ActionResult Salir()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Usuario");
        }


        [HttpPost]
        public ActionResult ActivarNotificaciones(FormCollection form)
        {
            string res = "";
            string correo = form["txtCorreo"];

            if (correo.Equals("")) {
                TempData["estadoNotificacion"] = "ErrorNoIngresoCorreo";
                TempData["mensaje"] = "No se escribio ningun correo!";
                return RedirectToAction("Noticias", "Noticia");
            }


            res = usuariosActividad.ActivarNoticaciones(correo);
            if (res.Equals("Se agrego correo"))
            {
                TempData["estadoNotificacion"] = res;
                TempData["mensaje"] = "Se agrego correo:  " + correo + "  a notificaciones";
            }
            else
            {
                TempData["estadoNotificacion"] = "Error";
            }
            return RedirectToAction("Noticias", "Noticia");
        }

        [HttpPost]
        public ActionResult ActivarNotificacionesInternas(FormCollection form)
        {
            string res = "";
            string correo = form["txtCorreo"];
            res = usuariosActividad.ActivarNoticacionesInternas(correo);
            if (res.Equals("Se agrego correo"))
            {
                TempData["estadoNotificacion"] = res;
                TempData["mensaje"] = "Se agrego correo:  " + correo + "  a notificaciones";
            }
            else
            {
                TempData["estadoNotificacion"] = "Error";
            }
            return RedirectToAction("NoticiasInternas", "Noticia");
        }

    }

}
