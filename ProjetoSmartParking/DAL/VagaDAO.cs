using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.DAL
{
    public class VagaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarVaga(Vaga v)
        {
            if (BuscarVagaPorNumero(v) != null)
            {
                Console.WriteLine("\nVaga está ocupada!");
            }
            else
            {
                ctx.Vagas.Add(v);
                ctx.SaveChanges();
            }
        }
        public static List<Vaga> RetornarVaga()
        {
            return ctx.Vagas.ToList();
        }
        public static Vaga BuscarVagaPorPK(Vaga v)
        {
            return ctx.Vagas.Find(v.VagaId);
        }
        public static Vaga BuscarVagaPorNumero(Vaga v)
        {
            return ctx.Vagas.Include("Setor").FirstOrDefault(x => x.Numero.Equals(v.Numero));
        }
        public static Vaga BuscarVagaPorNumeroUnico(Vaga v)
        {
            return ctx.Vagas.Include("Setor").SingleOrDefault(x => x.Numero.Equals(v.Numero));
        }

        public static void RemoverVaga(Vaga v)
        {
            ctx.Vagas.Remove(v);
            ctx.SaveChanges();
        }
        public static void AlterarVaga(Vaga v)
        {
            ctx.Entry(v).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}

