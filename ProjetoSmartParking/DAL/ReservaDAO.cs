using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.DAL
{
    public class ReservaDAO
    {
       
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarReserva(Reserva r)
        {
            if (BuscarReservaPorNumero(r) != null)
            {
                Console.WriteLine("\nJá existe uma reserva para essa vaga!");
                return false;
            }
            else
            {
                ctx.Reservas.Add(r);
                ctx.SaveChanges();
            }
            return true;
        }
        public static Reserva BuscarReservaPorNumero(Reserva r)
        {
            return ctx.Reservas.FirstOrDefault(x => x.Numero.Equals(r.Numero));
        }
        public static Reserva BuscarReservaPorCliente(Pessoa c)
        {
            return ctx.Reservas.Include("Cliente").FirstOrDefault(x => x.Cliente.Nome.Equals(c.Nome));
        }
        public static Reserva BuscarReservaPorId(Reserva r)
        {
            return ctx.Reservas.Find(r.ReservaId);
        }

        public static void RemoverReserva(Reserva r)
        {
            ctx.Reservas.Remove(r);
            ctx.SaveChanges();
        }
        public static List<Reserva> RetonarReservas()
        {
            return ctx.Reservas.ToList();
        }
    }
}