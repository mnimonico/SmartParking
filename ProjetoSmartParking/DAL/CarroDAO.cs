using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.DAL
{
    public class CarroDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarCarro(Carro c)
        {
            if (BuscarCarroPorNome(c) != null)
            {
                Console.WriteLine("\nCarro já existe!");
            }
            else
            {
                ctx.Carros.Add(c);
                ctx.SaveChanges();
            }
        }
        public static List<Carro> RetornarCarros()
        {
            return ctx.Carros.ToList();
        }
        public static Carro BuscarCarrosPorPK(Carro c)
        {
            return ctx.Carros.Find(c.CarroId);
        }
        public static Carro BuscarCarroPorNome(Carro c)
        {
            return ctx.Carros.SingleOrDefault(x => x.Nome.Equals(c.Nome));
        }
        public static void RemoverCarro(Carro c)
        {
            ctx.Carros.Remove(c);
            ctx.SaveChanges();
        }
        public static void AlterarCarro(Carro c)
        {
            ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public static Carro BuscarCarroPorId(int? id)
        {
            return ctx.Carros.Find(id);
        }
    }
}