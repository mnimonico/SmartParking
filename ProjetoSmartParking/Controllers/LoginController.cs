using ProjetoSmartParking.DAL;
using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSmartParking.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrar(string[] TipoDeAcesso, [Bind(Include = "Login, Senha")] Pessoa pessoa)
        {
           

            if (ModelState.IsValid && pessoa != null)
            {
                foreach (var item in TipoDeAcesso)
                {
                    if(TipoDeAcesso.Equals("Sou administrador"))
                    {
                        return RedirectToAction("HomePage/Index");
                    }
                    return RedirectToAction("HomePage/Index");
                }              
            }else
            {
                ViewBag.LoginInvalido = "Login Inválido!";
            }

            return View(pessoa);
        }
    }
}