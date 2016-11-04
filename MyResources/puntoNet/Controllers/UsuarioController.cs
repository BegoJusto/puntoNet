using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers {
    public class UsuarioController : Controller {
        private UsuarioService uS;
        public UsuarioController()
        {
            uS = new UsuarioServiceImp();
        }
        // GET: Usuario
        public ActionResult Index()
        {
            ActionResult resultado = null;
            IList<Usuario> usuarios = uS.getAll();
            if (usuarios.Count() > 0)
            {
                resultado = View("Index", usuarios);
            } else
            {
                ViewBag.ErrorMessage = "No hay usuarios en la BB.DD.";
                resultado = View("Index", usuarios);
            }
            return resultado;
        }

        /*
         *Se pone en el parametro = -1, para indicar que este parametro puede no pasarse y se da esto, el parametro es igual a menos uno
         */
        // GET: Usuario/CreateUpdate
        public ActionResult createUpdate(int codUsuario = -1)
        {

            Usuario usuario = null;
            
            if (codUsuario < 0)
            {
                ViewBag.Title = "Usuario nuevo";
                usuario = new Usuario();
            } else
            {
                ViewBag.Title = "Editar usuario";
                usuario = uS.getById(codUsuario);
            }

            return View("Usuario", usuario);
        }
        [HttpPost]
        //POST: Usuario/Save
        public ActionResult save(Usuario usuario)
        {
            ActionResult resultado = null;
            if (ModelState.IsValid)
            {
                if (usuario.CodUsuario > 0)
                {
                    try
                    {
                        uS.update(usuario);
                        ViewBag.Message = "El usuario se ha actualizado con exito";
                    } catch (Exception ex)
                    {
                        ViewBag.ErrorMessage = "Algo ha salido mal: " + ex.Message;
                    }
                } else
                {
                    uS.create(usuario);
                    ViewBag.Message = "El usuario se ha creado con exito";
                }

                resultado = RedirectToAction("Index");
            } else
            {
                resultado = View("Usuario",usuario);
            }
            return resultado;
        }
        // GET: Editorial/Delete
        public ActionResult delete(int codUsuario)
        {
            uS.delete(codUsuario);
            return RedirectToAction("index");
        }
    }
}

