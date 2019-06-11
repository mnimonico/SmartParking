using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Estacionamentos")]
    public class Estacionamento
    {
        public Estacionamento()
        {
            Proprietario = new Pessoa();
            Contato = new Contato();
            Setor = new List<Setor>();
            CriadoEm = DateTime.Now;
        }
        [Key]

        public int EstacionamentoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Cnpj { get; set; }
        public List<Setor> Setor { get; set; }
        public Pessoa Proprietario { get; set; }
        public double PrecoHora { get; set; }
        public Contato Contato { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
