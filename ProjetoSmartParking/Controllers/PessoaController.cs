using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoSmartParking.Models;
using ProjetoSmartParking.Utils;
using ProjetoSmartParking.DAL;

namespace ProjetoSmartParking.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Index()
        {
            return View(PessoaDAO.RetornarPessoas());
        }

        public ActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Pessoa pessoa = db.Pessoas.Find(id);
            Pessoa pessoa = PessoaDAO.BuscarPessoaPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }


        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(string TipoDeAcesso, Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                if (ValidaCPF.ValidaCpf(pessoa.Cpf) && ValidaCPF.VerificaCpf(pessoa.Cpf))
                {
                    PessoaDAO.CadastrarPessoa(pessoa);
                    if (TipoDeAcesso.Equals("Cliente"))
                    {
                        return RedirectToAction("Cadastrar", "Carro");
                    }
                    return RedirectToAction("Cadastrar", "Estacionamento");               
                }
                else
                {
                    ModelState.AddModelError("", "Número de CPF invalido, Tente novamente!");
                    return View(pessoa);
                }
            }
            return View(pessoa);

        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = PessoaDAO.BuscarPessoaPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "PessoaId,Nome,Cpf,Sexo,TipoDeAcesso,DataNascimento,CriadoEm")] Pessoa pessoa)
        {
            Pessoa p = PessoaDAO.BuscarPessoaPorId(pessoa.PessoaId);

            p.Nome = pessoa.Nome;
            p.DataNascimento = pessoa.DataNascimento;

            PessoaDAO.AlterarPessoa(pessoa);
            return RedirectToAction("Index", "Produto");
        }


        public ActionResult Remover(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = PessoaDAO.BuscarPessoaPorId(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }


        [HttpPost, ActionName("Remover")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmarRemocao(int id)
        {
            Pessoa pessoa = PessoaDAO.BuscarPessoaPorId(id);
            PessoaDAO.RemoverPessoa(pessoa);
            return RedirectToAction("Index");
        }


    }
}
