using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bela.BL.Interfaces;
using Bela.BL.Metodos;
using Bela.Datos;
using AutoMapper; 

namespace Bela.UI.Controllers
{
    public class EstudianteController : Controller
    {
        IEstudiante estudiantesMetodos;

        public EstudianteController()
        {
            estudiantesMetodos = new MEstudianteBL();
        }


        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var listaMaterias = estudiantesMetodos.listaMaterias(Convert.ToInt32(Session["UserSeccion"]));
            var lista = Mapper.Map<List<Models.MateriaDeta>>(listaMaterias);
            return View(lista);
        }
    }
}