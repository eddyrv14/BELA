using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bela.BL.Interfaces;
using Bela.BL.Metodos;
using AutoMapper;
using Bela.Datos;

namespace Bela.UI.Controllers
{
    public class MaterialController : Controller
    {
        IMaterial materialMetodos;
        IProfesor profesorMetodos;

        public MaterialController()
        {
            materialMetodos = new MMaterialBL();
            profesorMetodos = new MProfesorBL();
        }

        public ActionResult ListaMateriales(int idDetalleMateria)
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            var listaMateriales = materialMetodos.ListaMateriales(idDetalleMateria);
            var lista = Mapper.Map<List<Models.DetalleMaterial>>(listaMateriales);

            if (listaMateriales.Count == 0)
            {
                TempData["null"] = "null";
            }

            var detallesMateria = profesorMetodos.BuscarMateria(idDetalleMateria);
            var detallesMostrar = Mapper.Map<Models.MateriaDeta>(detallesMateria);
            ViewBag.idMateria = detallesMostrar;

            return View(lista);
        }

        public ActionResult DetalleMaterial(int idMaterial)
        {
            List<MasMaterial> listaMateriales = new List<MasMaterial>();
            listaMateriales = profesorMetodos.ListaMaterialesAdicionales(idMaterial);
            ViewBag.Materiales = listaMateriales;


            var material = materialMetodos.BuscarMaterial(idMaterial);
            var materialMostrar = Mapper.Map<Models.DetalleMaterial>(material);
            return View(materialMostrar);
        }
    }
}