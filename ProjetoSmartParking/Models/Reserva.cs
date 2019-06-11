using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Reservas")]
    public class Reserva
    {
        public Reserva()
        {
            Cliente = new Pessoa();
            Carro = new Carro();
            Vaga = new Vaga();
            FormaDePagamento = new FormaDePagamento();
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int ReservaId { get; set; }

        public int Numero { get; set; }
        public Pessoa Cliente { get; set; }
        public Carro Carro { get; set; }
        public Vaga Vaga { get; set; }
        public FormaDePagamento FormaDePagamento { get; set; }
        public bool StatusPagamento { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
