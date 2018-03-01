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
    public class ContactoController : Controller
    {
        IContacto contacto;

        public ContactoController()
        {
            contacto = new MContactoBL();
        }
        
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnvioMensaje()
        {
            Session.Contents.Remove("mensajeEnviado");                  /****/
            Session.Contents.Remove("errorMensaje"); 
            return View();
        }

    [HttpPost]
        public ActionResult EnvioMensaje(Models.MensajeContacto mensaje, FormCollection form)
        {
             mensaje.mensaje = form["message"];
            if (ModelState.IsValid && !mensaje.mensaje.Equals(""))
            {
                Session.Contents.Remove("errorMensaje");   /***/
                var mensajeInsertar = Mapper.Map<Datos.MensajeContacto>(mensaje);
                contacto.EnvioMensaje(mensajeInsertar);
                Session["mensajeEnviado"] =1;   /**/
                return View();
            }
            Session.Contents.Remove("mensajeEnviado");      /***/
            Session["errorMensaje"] = 0;   /***/
            return View(mensaje);
        }
	}
}