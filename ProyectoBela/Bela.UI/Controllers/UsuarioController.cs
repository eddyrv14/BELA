using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bela.Datos;
using Bela.BL.Interfaces;
using Bela.BL.Metodos;

namespace Bela.UI.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuario usuariosActividad;

        public UsuarioController()
        {
            usuariosActividad = new MUsuarioBL();
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
                        Session["rol"] = usuarDatos.rolNombre;
                        Session["UserUsuario"] = usuarDatos.usuario;
                        Session["UserContrasena"] = usuarDatos.contrasena;
                    }
                    else
                    {
                        ViewBag.MensajeLogin = "No se encontro el usuario";
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
    }
}