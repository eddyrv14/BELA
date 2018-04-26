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
        IUsuario usuarioActi;

        public AdminController()
        {
            noticiasAdmin = new MNoticiaBL();
            contactoAct = new MContactoBL();
            usuarioActi = new MUsuarioBL();
        }

        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            var listaNoticias = noticiasAdmin.ListaNoticiasAdmin(Convert.ToInt32(Session["UserID"]));
            var mostrarNoticias = Mapper.Map<List<Models.Noticia>>(listaNoticias);

            if (listaNoticias.Count == 0)
            {
                TempData["noticiasNull"] = "null";
            }

            return View(mostrarNoticias);
        }

        public ActionResult CrearNoticia()
        {
            //if (Session["UserID"] != null)
            //{
            var listaTipos = noticiasAdmin.listaTiposNoticias();
            ViewBag.Tipos = new SelectList(listaTipos, "idTipoNoticia", "nombre");
            return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login", "Usuario");
            //}
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
            var listaMensajes = contactoAct.listaMensajes();
            var lista = Mapper.Map<List<Models.MensajeContacto>>(listaMensajes);
            return View(lista);
        }

        public ActionResult ModificarNoticia(int idNoticia)
        {

            var noticia = noticiasAdmin.buscarNoticia(idNoticia);
            var listaTipos = noticiasAdmin.listaTiposNoticias();
            ViewBag.Tipos = new SelectList(listaTipos, "idTipoNoticia", "nombre", noticia.idtipo);
            ViewBag.imagen = noticia.imagen;
            var mostrar = Mapper.Map<Models.Noticia>(noticia);
            return View(mostrar);
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
            string res = "";
            res = noticiasAdmin.EliminarNoticia(idNoticia);
            TempData["estadoNoticia"] = res;
            return RedirectToAction("Inicio");
        }

        public string enviarCorreosExternos(string titulo, string descripcion)
        {
            string res = "";
            try
            {
                var listaCorreos = usuarioActi.ListaCorreoNotiExternas();

                if (listaCorreos.Count != 0)
                {
                    /*Mensaje*/
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("liceodepuriscalcr@gmail.com", "Liceo de Puriscal", Encoding.UTF8);
                    mail.Subject = "Nueva noticia: " + titulo;
                    mail.Body = descripcion + "<br />  Visita la seccion Noticias de nuestra  pagina";
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
                var listaCorreos = usuarioActi.ListaCorreoNotiInternas();

                if (listaCorreos.Count != 0)
                {
                    /*Mensaje*/
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("liceodepuriscalcr@gmail.com", "Liceo de Puriscal", Encoding.UTF8);
                    mail.Subject = "Nueva noticia de Personal: " + titulo;
                    mail.Body = descripcion + "<br />  Visita la seccion Noticias internas de nuestra pagina";
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

