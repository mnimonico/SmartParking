using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSmartParking.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrar(string[] TipoDeAcesso, [Bind(Include = "PessoaId,Login,Senha, TipoDeAcesso")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
              // if(x => x.Login.Equals(pessoa.Login))
                return RedirectToAction("Index");
            }

            return View(pessoa);
        }
    }
}