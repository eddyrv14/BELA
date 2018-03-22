using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bela.UI.Controllers
{
    public class ProfesorController : Controller
    {
        // GET: Profesor
        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
    }
}