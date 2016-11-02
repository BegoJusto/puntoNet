using gestionbibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers
{
    public class EjemplarController : Controller
    {
        private EjemplarService es;

        public EjemplarController()
        {
            es = new EjemplarServiceImp();
        }
        // GET: Ejemplar
        [HttpGet]
        public ActionResult Index( int codLibro = -1)
        {
            ActionResult paginaRedirect = null;
            IList<Ejemplar> ejemplares = null;

            if (codLibro > 0) {
                ejemplares = es.getByIdDeLibro(codLibro);
                if (ejemplares.Count() <= 0) {
                    ViewBag.ErrorMessage = "No se han encontrado ejemplares del libro seleccionado";
                } 
            } else {
                ejemplares = es.getAll();
                if (ejemplares.Count() <= 0) {
                    ViewBag.ErrorMessage = "No se han encontrado ejemplares";
                } 
            }
            paginaRedirect = View("Index", ejemplares);

            return paginaRedirect;
        }

        //POST: Ejemplar/save
        [HttpPost]
        public ActionResult save(Ejemplar ejemplar)
        {
            ActionResult resultado = null;
            if(ModelState.IsValid)
            {
                if(ejemplar.CodEjemplar > -1)
                {
                    es.update(ejemplar);
                    ViewBag.Message = "El ejemplar se ha actualizado";
                }
                else
                {
                    es.create(ejemplar);
                    ViewBag.Message = "El ejemplar se ha creado con éxito";
                }
                resultado = RedirectToAction("Index");
            }
            else
            {
                resultado = View(ejemplar);
            }
            return resultado;
        }

        //GET : Ejemplar/createUpdate
        public ActionResult createUpdate(int cod = -1)
        {
            ActionResult resultado = null;
            Ejemplar ejemplar = null;

            if(cod > 0)
            {
                ejemplar = es.getEjemplarById(cod);
                ViewBag.Title = "Editar Ejemplar";
                resultado = View("Ejemplar", ejemplar);
            }
            else
            {
                ViewBag.Title = "Ejemplar Nuevo";
                ejemplar = new Ejemplar();
                resultado = View("Ejemplar", ejemplar);
            }
            return resultado;
        }

        //GET: Ejemplar/Delete/5
        public ActionResult delete(int cod)
        {
            if(es.getEjemplarById(cod) != null)
            {
                es.delete(cod);
                ViewBag.Message = "El ejemplar se ha borrado correctamente";
            }
            /*
             * Si pones View("") --> Lo mandas a la vista
             * Si pones RedirectToAction --> lo mandas al metodo del controlador
             */
            return RedirectToAction("Index");
        }
    }
}