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
            TempData["estado"] = "Cuenta creada";
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

            /*AutoMapper*/
            var mostrarCuenta = Mapper.Map<Bela.UI.Models.Usuario>(cuenta);

            return View(mostrarCuenta);
        }

        [HttpPost]
        public ActionResult EditarCuenta(Models.Usuario usuario, FormCollection form)
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
                int idPersona = Convert.ToInt32(form["idPersona"]);
                string nombre = form["nombre"];
                string apellido1 = form["apellido1"];
                string apellido2 = form["apellido2"];
                string correo = form["correo"];

                /*Usuariop*/
                int idRol = Convert.ToInt32(form["dropIdTipoUsuario"]);
                string usuariotxt = form["usuario"];
                string contratxt = form["contrasena"];

                Usuario usu = new Usuario();
                usu.idPersona = idPersona;
                usu.nombre = nombre;
                usu.apellido1 = apellido1;
                usu.apellido2 = apellido2;
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
                ViewData["mensajeError"] = "Ingrese todos los datos necesarios";
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
    }
}