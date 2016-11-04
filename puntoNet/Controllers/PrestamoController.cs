using ClienteWS.BBLL;
using ClienteWS.BBLL.interfaces;
using ClienteWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteWS.Controllers
{
    public class PrestamoController : Controller
    { 
        private PrestamosService prestamosService;
        private EjemplarServiceImp ejemplarService;

        public PrestamoController()
        {
            prestamosService = new PrestamosServiceImp();
            ejemplarService = new EjemplarServiceImp();
        }

        // GET: Prestamo
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            ActionResult paginaRedirect = null;
            IList<Prestamos> prestamos = prestamosService.getAll();
            if(prestamos.Count() > 0)
            {
                ViewBag.Title = "Listado de prestamos";
                paginaRedirect =  View("Index",prestamos);
            }else
            {
                ViewBag.ErrorMessage = "No hay prestamos en la BB.DD";
                paginaRedirect = View("Index", prestamos);
            }
            return paginaRedirect;
        }
        [Authorize(Roles = "User")]
        //GET: Prestamo/createUpdate
        [HttpGet]
        public ActionResult createUpdate(int codLibro, int codUsuario, int codigo = -1)
        {
            
            Prestamos prestamo = null;
            IList<Ejemplar> ejemplares = ejemplarService.getAll();
            ViewBag.Ejemplares = ejemplares;
            if (codigo > 0)
            {
                prestamo = prestamosService.getById(codigo);
                ViewBag.Title = "Modificación del prestamo";
                
            }else
            {
                ViewBag.Title = "Crear prestamo";
            }

            return View("Prestamo", prestamo);
        }
        [Authorize(Roles = "User")]
        //POST: Prestamo/save
        [HttpPost]
        public ActionResult save(Prestamos prestamo)
        {
            
            if (prestamo.CodPrestamo > 0)
            {
                prestamosService.update(prestamo);
                ViewBag.Message = "Se ha modificado el prestamo con exito";
            }else
            {
                prestamosService.create(prestamo);
                ViewBag.Message= "Se ha creado el prestamo con exito";
            }

            return View("Index");
        }
    }
}