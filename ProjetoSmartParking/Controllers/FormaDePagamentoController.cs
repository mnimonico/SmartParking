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
    public class FormaDePagamentoController : Controller
    {
        private Context db = new Context();

      
        public ActionResult Index()
        {
            return View(db.FormasDePagamento.ToList());
        }

        
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = db.FormasDePagamento.Find(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

        
        public ActionResult Cadastrar()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar([Bind(Include = "FormaDePagamentoId,Nome,Valor,CriadoEm")] FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.FormasDePagamento.Add(formaDePagamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formaDePagamento);
        }

        
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = db.FormasDePagamento.Find(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "FormaDePagamentoId,Nome,Valor,CriadoEm")] FormaDePagamento formaDePagamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formaDePagamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formaDePagamento);
        }

       
        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormaDePagamento formaDePagamento = db.FormasDePagamento.Find(id);
            if (formaDePagamento == null)
            {
                return HttpNotFound();
            }
            return View(formaDePagamento);
        }

       
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemocao(int id)
        {
            FormaDePagamento formaDePagamento = db.FormasDePagamento.Find(id);
            db.FormasDePagamento.Remove(formaDePagamento);
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
