using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bela.BL.Interfaces;
using Bela.BL.Metodos;
using Bela.Datos;
using AutoMapper;
using System.IO;

namespace Bela.UI.Controllers
{
    public class ProfesorController : Controller
    {
        IProfesor profesorActiv;

        public ProfesorController()
        {
            profesorActiv = new MProfesorBL();
        }

        public ActionResult Inicio()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            var listaMaterias = profesorActiv.ListaMaterialesProfesores(Convert.ToInt32(Session["UserID"]));
            var lista = Mapper.Map<List<Models.MateriaDeta>>(listaMaterias);
            return View(lista);
        }


        [HttpPost]
        public ActionResult CrearMateriales(Models.DetalleMaterial material,HttpPostedFileBase uploadFile, FormCollection form, IEnumerable<HttpPostedFileBase> uploadfilesMateria)
        {
            string mensaje = "";
            string guardaEn = "~/Materiales/";


            try
            {
                int idMateriaTxt = Convert.ToInt32(form["idMateria"]);
                int idUsuario=Convert.ToInt32(Session["UserID"]);
                string tituloTxt = form["txtTitulo"];
                string descripcionTxt = form["txtDescripcion"];


                /*Material Obligatoria*/
                if (uploadFile != null)
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var path = Path.Combine(Server.MapPath(guardaEn), fileName);
                    uploadFile.SaveAs(path);
                    string materialGuardar = guardaEn + fileName;
                    /*Datos*/
                    material.idUsuario = idUsuario;
                    material.idDetalleMateria = idMateriaTxt;
                    material.titulo = tituloTxt;
                    material.mensaje = descripcionTxt;
                    material.material = materialGuardar;
                    material.nombreMaterial = fileName;
                    

                    var materialMap = material;
                    var materialInsert = Mapper.Map<Datos.DetalleMaterial>(materialMap);

                    mensaje = profesorActiv.crearMaterial(materialInsert);
                }
                else
                {
                    TempData["mensajeProf"] = "Inserte el documento obligatorio";
                    return RedirectToAction("Inicio", "Profesor");
                }


        

                if (mensaje.Equals("Material agregado"))
                {
                    /*MaterialesAdicionales*/
                    if (uploadfilesMateria != null)
                    {
                        foreach (var files in uploadfilesMateria.ToList())
                        {
                            var fileNames = Path.GetFileName(files.FileName);
                            var paths = Path.Combine(Server.MapPath(guardaEn), fileNames);
                            files.SaveAs(paths);
                            string documentosAdicionales = guardaEn + fileNames;
                            profesorActiv.AgregarMaterialesAdicionales(documentosAdicionales, fileNames);

                        }

                    }
                }

                TempData["mensajeProf"] = mensaje;

                return RedirectToAction("Inicio", "Profesor");

            }
            catch (NullReferenceException)
            {

                TempData["mensajeProf"] = "Material Creado";
                return RedirectToAction("Inicio", "Profesor");
            }
            catch (Exception)
            {
                TempData["mensajeProf"] = "Ocurrio un error,ingrese los datos necesarios";
                return RedirectToAction("Inicio", "Profesor");
            }
        }


        public ActionResult AdministrarMateria()
        {
            return View();
        }
    }
}