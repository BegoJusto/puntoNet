using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers
{
    public class FotoController : Controller
    {
        private FotoService FotoServiceImp;
        // GET: Foto
        [HttpGet]
        public ActionResult Index() {
            ActionResult PaginaRedirect = null;
            IList<Foto> fotos = FotoServiceImp.getAll();
            if (fotos.Count() > 0) {
                PaginaRedirect = View("Index", fotos);
            } else {
                ViewBag.ErrorMessage("No hay autores en la BB.DD.");
                PaginaRedirect = View("Index", fotos);
            }
            return PaginaRedirect;
        }

        //GET: Autor/createUpdate
        [HttpGet]
        public ActionResult createUpdate(int codigo = -1) {
            Foto foto = null;
            if (codigo > 0) {
                foto = FotoServiceImp.getByID(codigo);
                ViewBag.Title = "Modificación del autor";
            } else {
                foto = new Foto();
                ViewBag.Title = "Crear autor";
            }

            return View("Foto", foto);
        }
        //POST: Autor/save
        [HttpPost]
        public ActionResult save(Foto foto) {
            ActionResult paginaRedirect = null;
            if (ModelState.IsValid) {
                if (foto.idFoto > 0) {
                    FotoServiceImp.update(foto);
                    ViewBag.Message = "El autor se ha modificado con exito";
                } else {
                    FotoServiceImp.create(foto);
                    ViewBag.Message = "El autor se ha creado con exito";
                }

            } else {
                paginaRedirect = View("Foto", foto);
            }
            IList<Foto> fotos = FotoServiceImp.getAll();
            paginaRedirect = View("Index", fotos);
            return paginaRedirect;
        }

        //GET: Autor/delete
        [HttpGet]
        public ActionResult delete(int codigo = -1) {
            FotoServiceImp.delete(codigo);
            return RedirectToAction("Index");
        }
    }
}