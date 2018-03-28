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

namespace Bela.UI.Controllers
{
    public class AdminController : Controller
    {
        INoticia noticiasAdmin;
        IContacto contactoAct;

        public AdminController()
        {
            noticiasAdmin = new MNoticiaBL();
            contactoAct = new MContactoBL();
        }

        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            return View();
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

            if (ModelState.IsValid)
            {


                try
                {
                    Noticia noticiaInser = new Noticia();
                    noticiaInser.idtipo = Convert.ToInt32(form["dropIdTipo"]);
                    noticiaInser.idUsuario = Convert.ToInt32(Session["UserID"]);
                    noticiaInser.titulo = noticia.titulo;
                    noticiaInser.descripcion = form["txtDescripcion"];
                    noticiaInser.contenido = form["txtContenido"];

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
                    return View();
                }
                catch (NullReferenceException)
                {

                    ViewData["mensajeAdmin"] = "Noticia Creada";
                    return View();
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
            if (Session["UserID"] != null)
            {
                var listaMensajes = contactoAct.listaMensajes();
                var lista = Mapper.Map<List<Models.MensajeContacto>>(listaMensajes);
                return View(lista);
            }
            return RedirectToAction("Login", "Usuario");
        }
    }
}
