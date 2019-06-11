using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.DAL
{
    public class FormaDePagamentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarFormaDePagamento(FormaDePagamento fp)
        {
            if (BuscarFormaPorNome(fp) != null)
            {
                Console.WriteLine("\nEssa forma de pagamentos já está disponivel!");
                return false;
            }
            else
            {
                ctx.FormasDePagamento.Add(fp);
                ctx.SaveChanges();
            }
            return true;
        }
        public static FormaDePagamento BuscarFormaPorNome(FormaDePagamento fp)
        {
            return ctx.FormasDePagamento.FirstOrDefault(x => x.Nome.Equals(fp.Nome));
        }
        public static FormaDePagamento BuscarFormaPorId(FormaDePagamento fp)
        {
            return ctx.FormasDePagamento.Find(fp.FormaDePagamentoId);
        }
        
        public static void RemoverFormaDePagamento(FormaDePagamento fp)
        {
            ctx.FormasDePagamento.Remove(fp);
            ctx.SaveChanges();
        }
        public static List<FormaDePagamento> RetonarFormasDePagamento()
        {
            return ctx.FormasDePagamento.ToList();
        }
    }
}
