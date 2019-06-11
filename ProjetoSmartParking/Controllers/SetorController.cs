using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoSmartParking.Models;

namespace ProjetoSmartParking.Controllers
{
    public class SetorController : Controller
    {
        private Context db = new Context();


        public ActionResult Index()
        {
            return View(db.Setores.ToList());
        }

      
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = db.Setores.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

  
        public ActionResult Cadastrar()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "SetorId,Nome,Piso,Ala,CriadoEm")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Setores.Add(setor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setor);
        }

     
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = db.Setores.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "SetorId,Nome,Piso,Ala,CriadoEm")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setor);
        }

     
        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Setor setor = db.Setores.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

       
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemocao(int id)
        {
            Setor setor = db.Setores.Find(id);
            db.Setores.Remove(setor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
