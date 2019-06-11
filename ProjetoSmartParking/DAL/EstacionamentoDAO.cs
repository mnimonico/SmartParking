using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.DAL
{
    public class EstacionamentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarEstacionamento(Estacionamento e)
        {
            if (BuscarEstacionamentoPorCnpj(e) != null)
            {
                Console.WriteLine("\nEstacionamento ja existe!");
            }
            else
            {
                ctx.Estacionamentos.Add(e);
                ctx.SaveChanges();
            }
        }
        public static List<Estacionamento> RetornarEstacionamento()
        {
            return ctx.Estacionamentos.Include("Contato").ToList();
        }
        public static Estacionamento BuscarEstacionamentoPorPK(Estacionamento e)
        {
            return ctx.Estacionamentos.Find(e.EstacionamentoId);
        }
        public static Estacionamento BuscarEstacionamentoPorCnpj(Estacionamento e)
        {
            return ctx.Estacionamentos.Include("Contato").FirstOrDefault(x => x.Cnpj.Equals(e.Cnpj));
        }
        public static Estacionamento BuscarEstacionamentoPorCnpjUnico(Estacionamento e)
        {
            return ctx.Estacionamentos.Include("Contato").SingleOrDefault(x => x.Cnpj.Equals(e.Cnpj));
        }
        public static List<Estacionamento> BuscarEstacionamentoPorParteNome(Estacionamento e)
        {
            return ctx.Estacionamentos.Where(x => x.Nome.Contains(e.Nome)).ToList();
        }
        public static void RemoverEstacionamento(Estacionamento e)
        {
            ctx.Estacionamentos.Remove(e);
            ctx.SaveChanges();
        }
        public static void AlterarEstacionamento(Estacionamento e)
        {
            ctx.Entry(e).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}
