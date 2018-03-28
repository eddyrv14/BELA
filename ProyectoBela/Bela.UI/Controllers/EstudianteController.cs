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

        // GET: Estudiante
        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var listaMaterias = estudiantesMetodos.listaMaterias(Convert.ToInt32(Session["UserID"]));
            var lista = Mapper.Map<List<Models.Materia>>(listaMaterias);
            return View(lista);
        }
    }
}