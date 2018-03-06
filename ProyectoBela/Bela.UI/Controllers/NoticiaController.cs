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
    public class NoticiaController : Controller
    {
        INoticia noticias;

        public NoticiaController()
        {
            noticias = new MNoticiaBL();
        }
        public ActionResult Noticias()
        {
            var listaNoticias = noticias.listaNoticias();
            var lista = Mapper.Map<List<Models.Noticia>>(listaNoticias);
            return View(lista);
        }
	}
}