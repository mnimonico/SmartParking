using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoSmartParking.Models;
using ProjetoSmartParking.DAL;

namespace ProjetoSmartParking.Views
{
    public class CarrosController : Controller
    {
 
        public ActionResult Index()
        {
            return View(CarroDAO.RetornarCarros());
        }

       
        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = CarroDAO.BuscarCarroPorId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

       
        public ActionResult Cadastrar()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Carro carro)
        {
            if (ModelState.IsValid)
            {
                CarroDAO.CadastrarCarro(carro);
                return RedirectToAction("Index");
            }

            return View(carro);
        }

        
        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = CarroDAO.BuscarCarroPorId(id); 
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Carro carro)
        {
            Carro c = CarroDAO.BuscarCarroPorId(carro.CarroId);

            c.Nome = carro.Nome;
            c.Placa = carro.Placa;
            c.Fabricante = carro.Fabricante;
            c.Cor = carro.Cor;
            c.Modelo = carro.Modelo;
        

            CarroDAO.AlterarCarro(carro);
            return RedirectToAction("Index", "Carro");
        }


        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = CarroDAO.BuscarCarroPorId(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        
        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemocao(int id)
        {
            Carro carro = CarroDAO.BuscarCarroPorId(id);
            CarroDAO.AlterarCarro(carro);
            return RedirectToAction("Index");
        }
    }
}
