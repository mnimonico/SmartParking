using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("FormasDePagamento")]
    public class FormaDePagamento
    {
        public FormaDePagamento()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int FormaDePagamentoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Nome { get; set; }
        public double Valor { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
