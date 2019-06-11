using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Vagas")]
    public class Vaga
    {
        public Vaga()
        {
            Setor = new Setor();
            Estacionamento = new Estacionamento();
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int VagaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Numero { get; set; }
        public Setor Setor { get; set; }
        public bool Status { get; set; }
        public Estacionamento Estacionamento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
