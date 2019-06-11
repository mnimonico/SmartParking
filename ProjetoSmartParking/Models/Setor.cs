using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Setores")]
    public class Setor
    {
        public Setor()
        {
            Vagas = new List<Vaga>();
            CriadoEm = DateTime.Now;
        }
        [Key]
        public int SetorId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Piso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string  Ala  { get; set; }
        public List<Vaga> Vagas { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
