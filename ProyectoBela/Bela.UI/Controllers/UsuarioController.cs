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

        public ActionResult CrearCuenta()
        {

            var listaTipos = usuariosActividad.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult CrearCuenta(Models.Usuario usuario, FormCollection form)
        {

            string res = "";

            var listaTipos = usuariosActividad.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");

            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            if (!form["nombre"].Equals(""))
            {
                string nombre = form["nombre"];
                string apellido1 = form["apellido1"];
                string apellido2 = form["apellido2"];
                string correo = form["correo"];

                /*Usuariop*/
                int idRol = Convert.ToInt32(form["dropIdTipoUsuario"]);
                string usuariotxt = form["usuario"];
                string contratxt = form["contrasena"];

                Usuario usu = new Usuario();

                usu.nombre = nombre;
                usu.apellido1 = apellido1;
                usu.apellido2 = apellido2;
                usu.correo = correo;
                usu.rol = idRol;
                usu.usuario = usuariotxt;
                usu.contrasena = contratxt;

                res = usuariosActividad.InsertPersona(usu);
                ViewData["mensajeCuenta"] = res;
                usu = null;
                form = null;

            }
            else
            {
                ViewData["mensajeError"] = "Ingrese todos los datos necesarios";
                return View();
            }
            return RedirectToAction("CrearCuenta");
        }

    }
}