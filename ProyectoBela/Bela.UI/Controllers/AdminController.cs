using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Bela.Datos;
using Bela.BL.Interfaces;
using Bela.BL.Metodos;
using AutoMapper;
using System.IO;

using System.Text;
using System.Net.Mail;
using System.Net;


namespace Bela.UI.Controllers
{
    public class AdminController : Controller
    {
        INoticia noticiasAdmin;
        IContacto contactoAct;
        IAdmin adminActi;
        IEstudiante estudianteActividad;
        IUsuario usuariosActividad;

        public AdminController()
        {
            noticiasAdmin = new MNoticiaBL();
            contactoAct = new MContactoBL();
            adminActi = new MAdminBL();
            estudianteActividad = new MEstudianteBL();
            usuariosActividad = new MUsuarioBL();
        }

        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {

                var listaNoticias = noticiasAdmin.ListaNoticiasAdmin(Convert.ToInt32(Session["UserID"]));
                var mostrarNoticias = Mapper.Map<List<Models.Noticia>>(listaNoticias);
                return View(mostrarNoticias);
            }
            return RedirectToAction("Login", "Usuario");
        }

        public ActionResult CrearNoticia()
        {


            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {


                var listaTipos = noticiasAdmin.listaTiposNoticias();
                ViewBag.Tipos = new SelectList(listaTipos, "idTipoNoticia", "nombre");
                return View();
            }

            return RedirectToAction("Login", "Usuario");

        }


        [HttpPost]
        public ActionResult CrearNoticia(Models.Noticia noticia, FormCollection form, HttpPostedFileBase uploadFile, IEnumerable<HttpPostedFileBase> uploadfiles)
        {
            string mensaje = "";
            string guardaEn = "~/Imagenes/ImagenesNoticias/";


            var listaTipos = noticiasAdmin.listaTiposNoticias();
            ViewBag.Tipos = new SelectList(listaTipos, "idTipoNoticia", "nombre");
            if (form["dropIdTipo"].Equals(""))
            {
                ViewData["mensajeAdmin"] = "Elija un tipo de noticia";
                return View();
            }


            if (ModelState.IsValid)
            {
                Noticia noticiaInser = new Noticia();
                noticiaInser.idtipo = Convert.ToInt32(form["dropIdTipo"]);
                noticiaInser.idUsuario = Convert.ToInt32(Session["UserID"]);
                noticiaInser.titulo = noticia.titulo;
                noticiaInser.descripcion = form["txtDescripcion"];
                noticiaInser.contenido = form["txtContenido"];

                try
                {


                    /*Imagen Obligatoria*/
                    if (uploadFile != null)
                    {
                        var fileName = Path.GetFileName(uploadFile.FileName);
                        var path = Path.Combine(Server.MapPath(guardaEn), fileName);
                        uploadFile.SaveAs(path);
                        string imagenNoticia = guardaEn + fileName;
                        noticiaInser.imagen = imagenNoticia;

                        noticiasAdmin.insertarNoticia(noticiaInser);
                        mensaje = "Noticia creada";

                    }
                    else
                    {
                        ViewData["mensajeAdmin"] = "Inserte la imagen obligatoria";
                        return View(noticia);
                    }


                    /**/


                    /*Imagenes adicionales*/
                    if (uploadfiles != null)
                    {
                        foreach (var files in uploadfiles.ToList())
                        {
                            var fileNames = Path.GetFileName(files.FileName);
                            var paths = Path.Combine(Server.MapPath(guardaEn), fileNames);
                            files.SaveAs(paths);
                            string imagenesAdicionales = guardaEn + fileNames;
                            noticiasAdmin.insertarImagenesAdicionales(imagenesAdicionales);

                        }

                    }

                    ViewData["mensajeAdmin"] = mensaje;
                    if (noticiaInser.idtipo == 1)
                    {
                        enviarCorreosExternos(noticiaInser.titulo, noticiaInser.descripcion);
                    }
                    else
                    {
                        enviarCorreosInternos(noticiaInser.titulo, noticiaInser.descripcion);
                    }
                    return View();

                }
                catch (NullReferenceException)
                {

                    ViewData["mensajeAdmin"] = "Noticia Creada";
                    if (noticiaInser.idtipo == 1)
                    {
                        enviarCorreosExternos(noticiaInser.titulo, noticiaInser.descripcion);
                        return View();
                    }
                    else
                    {
                        enviarCorreosInternos(noticiaInser.titulo, noticiaInser.descripcion);
                        return View();
                    }

                }
                catch (Exception)
                {
                    ViewData["mensajeAdmin"] = "Ocurrio un error,ingrese los datos necesarios";
                    return View();
                }
            }
            else
            {
                return View(noticia);
            }
        }

        public ActionResult Mensajes()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {
                var listaMensajes = contactoAct.listaMensajes();
                var lista = Mapper.Map<List<Models.MensajeContacto>>(listaMensajes);
                return View(lista);
            }

            return RedirectToAction("Login", "Usuario");
        }

        public ActionResult ModificarNoticia(int idNoticia)
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {

                var noticia = noticiasAdmin.buscarNoticia(idNoticia);
                var listaTipos = noticiasAdmin.listaTiposNoticias();
                ViewBag.Tipos = new SelectList(listaTipos, "idTipoNoticia", "nombre", noticia.idtipo);
                ViewBag.imagen = noticia.imagen;
                var mostrar = Mapper.Map<Models.Noticia>(noticia);
                return View(mostrar);
            }

            return RedirectToAction("Login", "Usuario");
        }

        [HttpPost]
        public ActionResult ModificarNoticia(Noticia noticia, FormCollection form, HttpPostedFileBase uploadFile)
        {
            string mensaje = "";
            string guardaEn = "~/Imagenes/ImagenesNoticias/";


            var listaTipos = noticiasAdmin.listaTiposNoticias();
            ViewBag.Tipos = new SelectList(listaTipos, "idTipoNoticia", "nombre");

            if (ModelState.IsValid)
            {


                try
                {
                    //Noticia noticiaInser = new Noticia();
                    noticia.idtipo = Convert.ToInt32(form["dropIdTipo"]);

                    //noticiaInser.idUsuario = Convert.ToInt32(Session["UserID"]);
                    //noticiaInser.titulo = noticia.titulo;
                    //noticiaInser.descripcion = form["txtDescripcion"];
                    //noticiaInser.contenido = form["txtContenido"];

                    /*Imagen Obligatoria*/
                    if (uploadFile != null)
                    {
                        var fileName = Path.GetFileName(uploadFile.FileName);
                        var path = Path.Combine(Server.MapPath(guardaEn), fileName);
                        uploadFile.SaveAs(path);
                        string imagenNoticia = guardaEn + fileName;
                        noticia.imagen = imagenNoticia;

                        //noticiasAdmin.insertarNoticia(noticiaInser);
                        mensaje = noticiasAdmin.ModificarNoticia(noticia);

                    }
                    else
                    {
                        noticia.imagen = form["txtImagen"];
                        mensaje = noticiasAdmin.ModificarNoticia(noticia);

                    }

                    TempData["estadoNoticia"] = mensaje;
                    return RedirectToAction("Inicio");
                }
                catch (Exception e)
                {
                    ViewData["mensajeAdmin"] = e;
                    return View();
                }
            }
            else
            {
                return View(noticia);
            }
        }

        public ActionResult EliminarNoticia(int idNoticia)
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {
                string res = "";
                res = noticiasAdmin.EliminarNoticia(idNoticia);
                TempData["estadoNoticia"] = res;
                return RedirectToAction("Inicio");
            }

            return RedirectToAction("Login", "Usuario");
        }


        /*Admin cuentas*/
        public ActionResult CrearCuenta()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {

                var lista = adminActi.ListaSecciones();
                ViewBag.Secciones = new SelectList(lista, "idSeccion", "nombre");

                var listaTipos = adminActi.listaRoles();
                ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");
                return View();
            }

            return RedirectToAction("Login", "Usuario");

        }

        [HttpPost]
        public ActionResult CrearCuenta(Models.Usuario usuario, FormCollection form)
        {

            string res = "";
            int idSeccion = 0;



            var listaTipos = adminActi.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");

            var lista = adminActi.ListaSecciones();
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

                res = adminActi.InsertPersona(usu);
                TempData["estado"] = res;
                usu = null;
                form = null;

                if (idRol == 3 && TempData["estado"] != null && TempData["estado"].Equals("Usuario creado"))
                {
                    adminActi.InsertarEstudianteSeccion(idSeccion);
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

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            if (Session["rol"] != null && Session["rol"].Equals("Administrador"))
            {
                var listaCuentas = adminActi.ListaUsuarios();
                var lista = Mapper.Map<List<Models.Usuario>>(listaCuentas);
                return View(lista);
            }
            return RedirectToAction("Login", "Usuario");
        }



        public ActionResult EditarCuenta(int idPersona)
        {


            var cuenta = adminActi.BuscarCuenta(idPersona);
            var listaTipos = adminActi.listaRoles();
            /*ViewBag primero obtengo los datos de cuenta, para poner valor inicial al dropdownlist*/
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre", cuenta.rol);
            if (cuenta.rol == 3)
            {
                var seccion = estudianteActividad.BuscarSeccion(idPersona);
                var lista = adminActi.ListaSecciones();
                ViewBag.Secciones = new SelectList(lista, "idSeccion", "nombre", seccion.idSeccion);
                TempData["rol"] = "Estudiante";
            }
            else if (cuenta.rol == 2)
            {
                var listaMaterias = adminActi.ListaMaterias();
                var listaSecciones = adminActi.ListaSecciones();
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

            adminActi.AgregarMateriaProf(idMateria, idProfesor, idSeccion);

            return RedirectToAction("EditarCuenta", "Admin", new { idPersona = idProfesor });
        }



        [HttpPost]
        public ActionResult EditarCuenta(Models.Usuario usuario, FormCollection form)
        {

            string res = "";

            var listaTipos = adminActi.listaRoles();
            ViewBag.TiposUsuarios = new SelectList(listaTipos, "idRol", "nombre");

            var lista = adminActi.ListaSecciones();
            ViewBag.SeccionesPro = new SelectList(lista, "idSeccion", "nombre");

            var listaMaterias = adminActi.ListaMaterias();
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
                adminActi.ModificarEstudianteSeccion(idPersona, idSeccion);


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

                res = adminActi.ModificarCuenta(usu);
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
            res = adminActi.EliminarCuenra(idPersona);
            if (res.Equals("Cuenta eliminada"))
            {
                TempData["estado"] = "Cuenta Eliminada";
                return RedirectToAction("Cuentas", "Admin");
            }

            TempData["estado"] = "Error al eliminar cuenta";
            return RedirectToAction("EditarCuenta", "Admin", new { idPersona = idPersona });


        }





        /*Notificaciones*/

        public string enviarCorreosExternos(string titulo, string descripcion)
        {
            string res = "";
            try
            {
                var listaCorreos = usuariosActividad.ListaCorreoNotiExternas();

                if (listaCorreos.Count != 0)
                {
                    /*Mensaje*/
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("liceodepuriscalcr@gmail.com", "Liceo de Puriscal", Encoding.UTF8);
                    mail.Subject = "Nueva noticia: " + titulo;
                    mail.Body = @"<html>
                                      <head>
                                             <style>
                                             .titulos  {
                                                 font-size: 15px;
                                                 line-height: 40px;
                                                font-weight: 400;
                                                margin-bottom: 20px;
                                                letter-spacing: 2px;
                                                display: inline-block;
                                                position: relative;
                                                margin:auto;
                                                  }
                                             .parrafos{  
                                           font-size: 11px;
                                           font-weight: 300;
                                           letter-spacing: 1px;
                                           line-height: 27px;
                                           color: #000;
                                           }
                                            </style>
                                     </head>
                                     <body>
                                     "+@"<h1 class=""titulos"">"+titulo+"</h1>"+"<br>"+descripcion +"<br>"+ @"<p class=""parrafos"">Visita la seccion Noticias de nuestra  pagina</p>"+
                                    @"</body>
                                  </html>";
            
      


                    mail.IsBodyHtml = true;

                    foreach (var copi in listaCorreos)
                    {
                        mail.To.Add(copi.correo);
                    }

                    /*Datos serv*/
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("liceodepuriscalcr@gmail.com", "PurisCR12");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                else
                {
                    res = "No hay correos";
                    return res;
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;
        }

        public string enviarCorreosInternos(string titulo, string descripcion)
        {
            string res = "";
            try
            {
                var listaCorreos = usuariosActividad.ListaCorreoNotiInternas();

                if (listaCorreos.Count != 0)
                {
                    /*Mensaje*/
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("liceodepuriscalcr@gmail.com", "Liceo de Puriscal", Encoding.UTF8);
                    mail.Subject = "Nueva noticia de Personal: " + titulo;
                    mail.Body = descripcion + "<br /> <b>Visita las Noticias internas de nuestra página</b>";
                    mail.IsBodyHtml = true;

                    foreach (var copi in listaCorreos)
                    {
                        mail.To.Add(copi.correo);
                    }

                    /*Datos serv*/
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("liceodepuriscalcr@gmail.com", "PurisCR12");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                }
                else
                {
                    res = "No hay correos";
                    return res;
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
            return res;

        }
    }
}




