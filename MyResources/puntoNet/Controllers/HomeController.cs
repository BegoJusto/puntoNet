using gestionbibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using MyResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private AutorService es = new AutorServiceImp();
        private LibroService lS = new LibroServiceImp();
        //Esto es como el requestyMapping de spring
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = Resources.Titulo;
            ViewBag.Message = "Bienvenido a la gestión de bibliotecas";
            IList<Libro> libros = lS.getAll();
            string texto = Resources.Titulo;
            return View(libros);
        }

        //GET : About
        public ActionResult About()
        {
            
            return View();
        }
    }
}