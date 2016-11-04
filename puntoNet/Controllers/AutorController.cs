using puntoNet.BBLL;
using puntoNet.BBLL.interfaces;
using puntoNet.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ClienteWS.Controllers {
    [Authorize(Roles = "Admin")]
    public class AutorController : Controller
    {
        private AutorService autorService; 

        public AutorController()
        {
            autorService = new AutorServiceImp();
        }

        // GET: Autor
        [HttpGet]
        public ActionResult Index()
        {
            ActionResult PaginaRedirect = null;
            IList<Autor> autores = autorService.getAll();
            if(autores.Count() > 0)
            {
                PaginaRedirect =  View("Index",autores);
            }else
            {
                ViewBag.ErrorMessage("No hay autores en la BB.DD.");
                PaginaRedirect = View("Index", autores);
            }
            return PaginaRedirect;
        }

        //GET: Autor/createUpdate
        [HttpGet]
        public ActionResult createUpdate(int codigo = -1)
        {
            Autor autor = null;
            if(codigo > 0)
            {
                autor = autorService.getByID(codigo);
                ViewBag.Title = "Modificación del autor";
            }else
            {
                autor = new Autor();
                ViewBag.Title= "Crear autor";
            }
            
            return View("Autor", autor);
        }
        //POST: Autor/save
        [HttpPost]
        public ActionResult save(Autor autor)
        {
            ActionResult paginaRedirect = null;
            if (ModelState.IsValid) {
                if (autor.CodAutor > 0) {
                    autorService.update(autor);
                    ViewBag.Message = "El autor se ha modificado con exito";
                } else {
                    autorService.create(autor);
                    ViewBag.Message = "El autor se ha creado con exito";
                }

            } else {
                paginaRedirect = View("Autor", autor);
            }
            IList<Autor> autores = autorService.getAll();
            paginaRedirect = View("Index", autores);
            return paginaRedirect;
        }

        //GET: Autor/delete
        [HttpGet]
        public ActionResult delete(int codigo = -1)
        {
            autorService.delete(codigo);
            return RedirectToAction("Index");
        }
    }
}