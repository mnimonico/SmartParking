using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoSmartParking.Models
{
    /// <summary>
    /// Representar o banco de dados dentro da aplicação e
    /// o EntityFramework
    /// Herdar todas as funcionalidades do DbContext
    /// Herança : na frente da classe
    /// </summary>
    class Context : DbContext
    {
        //Renomear o banco de dados
        public Context() : base("BaseSmartParking") { }

        //Declarar todas as classes que vão virar tabelas
        //no banco de dados
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Setor> Setores { get; set; }
        public DbSet<FormaDePagamento> FormasDePagamento { get; set; }

        //Console
        //----------------------------------
        //Install-Package EntityFramework
        //Uninstall-Package EntityFramework
        //Enable-Migrations
        //Add-Migration NomeDaMigracao
        //Update-Database -verbose
        //Executar a migração e a atualização da base ao mesmo tempo
        //clear;Add-Migration Nome; Update-Database -verbose
    }
}

