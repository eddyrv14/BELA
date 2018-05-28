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
    public class HomeController : Controller
    {
        INoticia noticias;

        public HomeController()
        {
            noticias = new MNoticiaBL();
        }

        public ActionResult Index()
        {
            var ultimasNoticias = noticias.ultimasNoticias();
            var ultimasNo = Mapper.Map<List<Models.Noticia>>(ultimasNoticias);
            return View(ultimasNo);
        }
    }
}