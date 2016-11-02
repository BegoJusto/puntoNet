using gestionbibliotecaMVC.Models;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionBibliotecaMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private UsuarioService uS;
        public LoginController() {
            uS = new UsuarioServiceImp();
        }
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Message = "Menu de login";
            return View("Index");
        }

        //POST: Login
    //    [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Login model) {
            Usuario user = null;
            int codigo = 0;
            ActionResult retorno= null;
            FormsAuthenticationTicket authTicket;
            if (ModelState.IsValid) {
                //
                if (model.Alias.Equals("admin") && model.Pass.Equals("admin")) {
                    user = new Usuario();
                    authTicket = new FormsAuthenticationTicket(
                            1,                              //version
                            model.Alias,                      // user name
                            DateTime.Now,                  // created
                            DateTime.Now.AddMinutes(20),   // expires
                            model.Recordar,                    // persistent?
                            "Admin"                        // can be used to store roles
                    );
                    user.Alias = model.Alias;
                    user.CodUsuario = 0;
                    user.Pass = model.Pass;
                    Session["idUsuario"] = user.CodUsuario;
                    retorno = RedirectToAction("Index", "Home");

                } else {

                    codigo = uS.Login(model).CodUsuario;
                    authTicket = new FormsAuthenticationTicket(
                            1,                              //version                   
                            model.Alias,                      // user name
                            DateTime.Now,                  // created
                            DateTime.Now.AddMinutes(20),   // expires
                            model.Recordar,                    // persistent?
                            "User"                        // can be used to store roles
                            );
                }
                    if (codigo > 0 || user!=null) {
                        user = uS.getById(codigo);
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(authCookie);

                        Session["usuario"] = user;
                        
                        //  FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        retorno = RedirectToAction("Index", "Home");
                    } else {
                        ModelState.AddModelError("", "El usuario y/o contraseñas son incorrectos.");
                        retorno = View("Index");
                    }
                
            } else {
                ModelState.AddModelError("", "El usuario y/o contraseñas son incorrectos.");
                retorno = View("Index");
            }
           
                
            return retorno;
        }
            

        //POST: Logout
        [HttpPost]
            public ActionResult Logout() {
                System.Diagnostics.Debug.Write("He llegado a logout");
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
        }
        }