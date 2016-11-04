using MyResources;
using puntoNet.BBLL;
using puntoNet.BBLL.interfaces;
using puntoNet.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClienteWS.Controllers {
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