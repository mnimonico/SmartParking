using ProjetoSmartParking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSmartParking.DAL
{
    public class PessoaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static void CadastrarPessoa(Pessoa p)
        {
            if (BuscarPessoaPorCPF(p) != null)
            {
                Console.WriteLine("\nCliente já existe!");
            }
            else
            {
                ctx.Pessoas.Add(p);
                ctx.SaveChanges();
            }
        }
        public static List<Pessoa> RetornarPessoas()
        {
            return ctx.Pessoas.Include("Contato").ToList();
        }
        public static Pessoa BuscarPessoaPorPK(Pessoa p)
        {
            return ctx.Pessoas.Find(p.PessoaId);
        }
        public static Pessoa BuscarPessoaPorCPF(Pessoa p)
        {
            return ctx.Pessoas.Include("Contato").FirstOrDefault(x => x.Cpf.Equals(p.Cpf));
        }
        public static Pessoa BuscarPessoaPorCPFUnico(Pessoa p)
        {
            return ctx.Pessoas.Include("Contato").SingleOrDefault(x => x.Cpf.Equals(p.Cpf));
        }
        public static List<Pessoa> BuscarPessoasPorParteNome(Pessoa p)
        {
            return ctx.Pessoas.Where(x => x.Nome.Contains(p.Nome)).ToList();
        }
        public static void RemoverPessoa(Pessoa p)
        {
            ctx.Pessoas.Remove(p);
            ctx.SaveChanges();
        }
        public static void AlterarPessoa(Pessoa p)
        {
            ctx.Entry(p).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
        public static Pessoa BuscarPessoaMaiorIdade()
        {
            return ctx.Pessoas.FirstOrDefault(x => (DateTime.Now.Year - x.DataNascimento.Year) >= 18);
        }
        public static Pessoa BuscarCredenciais(Pessoa p)
        {
            return ctx.Pessoas.FirstOrDefault(x => x.Login.Equals(p.Login));
        }
        public static Pessoa BuscarPessoaPorId(int? id)
        {
            return ctx.Pessoas.Find(id);
        }
    }
}