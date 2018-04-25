using System;
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

        public ActionResult CrearCuenta()
        {

            var lista = usuariosActividad.ListaSecciones();
            ViewBag.Secciones = new SelectList(lista, "idSeccion", "nombre");

            var listaTipos = usuariosActividad.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult CrearCuenta(Models.Usuario usuario, FormCollection form)
        {

            string res = "";
            int idSeccion = 0;



            var listaTipos = usuariosActividad.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");

            var lista = usuariosActividad.ListaSecciones();
            ViewBag.Secciones = new SelectList(lista, "idSeccion", "nombre");


            int idRol = Convert.ToInt32(form["dropIdTipoUsuario"]);

            if (idRol == 3)
            {
                idSeccion = Convert.ToInt32(form["dropIdSeccion"]);
            }

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
                string cedula = form["cedula"];
                string correo = form["correo"];

                /*Usuariop*/

                string usuariotxt = form["usuario"];
                string contratxt = form["contrasena"];




                Usuario usu = new Usuario();

                usu.nombre = nombre;
                usu.apellido1 = apellido1;
                usu.apellido2 = apellido2;
                usu.cedula = cedula;
                usu.correo = correo;
                usu.rol = idRol;
                usu.usuario = usuariotxt;
                usu.contrasena = contratxt;

                res = usuariosActividad.InsertPersona(usu);
                TempData["estado"] = res;
                usu = null;
                form = null;

                if (idRol == 3 && TempData["estado"] != null && TempData["estado"].Equals("Usuario creado"))
                {
                    usuariosActividad.InsertarEstudianteSeccion(idSeccion);
                }
            }
            else
            {
                TempData["mensajeError"] = "Error";
                return View();
            }

            return RedirectToAction("CrearCuenta");
        }


        public ActionResult Cuentas()
        {
            var listaCuentas = usuariosActividad.ListaUsuarios();
            var lista = Mapper.Map<List<Models.Usuario>>(listaCuentas);
            return View(lista);
        }



        public ActionResult EditarCuenta(int idPersona)
        {


            var cuenta = usuariosActividad.BuscarCuenta(idPersona);
            var listaTipos = usuariosActividad.listaRoles();
            /*ViewBag primero obtengo los datos de cuenta, para poner valor inicial al dropdownlist*/
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre", cuenta.rol);
            if (cuenta.rol == 3)
            {
                var seccion = estudianteActividad.BuscarSeccion(idPersona);
                var lista = usuariosActividad.ListaSecciones();
                ViewBag.Secciones = new SelectList(lista, "idSeccion", "nombre", seccion.idSeccion);
                TempData["rol"] = "Estudiante";
            }
            else if (cuenta.rol == 2)
            {
                var listaMaterias = usuariosActividad.ListaMaterias();
                var listaSecciones = usuariosActividad.ListaSecciones();
                ViewBag.MateriasPro = new SelectList(listaMaterias, "idMateria", "nombre");
                ViewBag.SeccionesPro = new SelectList(listaSecciones, "idSeccion", "nombre");
                TempData["rol"] = "Profesor";
            }

            /*AutoMapper*/
            var mostrarCuenta = Mapper.Map<Bela.UI.Models.Usuario>(cuenta);

            return View(mostrarCuenta);
        }


        [HttpPost]
        public ActionResult agregarMateriaProf(FormCollection form)
        {
            int idMateria = Convert.ToInt32(form["DropIdMateria"]);
            int idProfesor = Convert.ToInt32(form["idPersona"]);
            int idSeccion = Convert.ToInt32(form["DropIdSeccion"]);

            usuariosActividad.AgregarMateriaProf(idMateria, idProfesor, idSeccion);

            return RedirectToAction("EditarCuenta", "Usuario", new { idPersona = idProfesor });
        }



        [HttpPost]
        public ActionResult EditarCuenta(Models.Usuario usuario, FormCollection form)
        {

            string res = "";

            var listaTipos = usuariosActividad.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");

            var lista = usuariosActividad.ListaSecciones();
            ViewBag.SeccionesPro = new SelectList(lista, "idSeccion", "nombre");

            var listaMaterias = usuariosActividad.ListaMaterias();
            ViewBag.MateriasPro = new SelectList(listaMaterias, "idMateria", "nombre");

            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            if (!form["nombre"].Equals(""))
            {
                int idPersona = Convert.ToInt32(form["idPersona"]);
                string nombre = form["nombre"];
                string apellido1 = form["apellido1"];
                string apellido2 = form["apellido2"];
                string cedula = form["cedula"];
                string correo = form["correo"];

                /*Usuariop*/
                int idRol = Convert.ToInt32(form["dropIdTipoUsuario"]);
                string usuariotxt = form["usuario"];
                string contratxt = form["contrasena"];


                /*Estu*/
                int idSeccion = Convert.ToInt32(form["dropIdSeccion"]);
                usuariosActividad.ModificarEstudianteSeccion(idPersona, idSeccion);


                Usuario usu = new Usuario();
                usu.idPersona = idPersona;
                usu.nombre = nombre;
                usu.apellido1 = apellido1;
                usu.apellido2 = apellido2;
                usu.cedula = cedula;
                usu.correo = correo;
                usu.idUsuario = idPersona;
                usu.rol = idRol;
                usu.usuario = usuariotxt;
                usu.contrasena = contratxt;

                res = usuariosActividad.ModificarCuenta(usu);
                ViewData["mensajeCuenta"] = res;
                usu = null;
                form = null;

            }
            else
            {
                TempData["estado"] = "error";
                return View();
            }
            TempData["estado"] = "Cuenta Modificada";
            return RedirectToAction("Cuentas");
        }


        public ActionResult EliminarCuenta(int idPersona)
        {
            string res = "";
            res = usuariosActividad.EliminarCuenra(idPersona);
            if (res.Equals("Cuenta eliminada"))
            {
                TempData["estado"] = "Cuenta Eliminada";
                return RedirectToAction("Cuentas", "Usuario");
            }
            TempData["estado"] = "Error al eliminar cuenta";
            return RedirectToAction("EditarCuenta", "Usuario", new { idPersona = idPersona });


        }

        [HttpPost]
        public ActionResult ActivarNotificaciones(FormCollection form)
        {
            string res = "";
            string correo = form["txtCorreo"];

            if (correo.Equals(""))
            {
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
