using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Pessoas")]
    public class Pessoa
    {
        public Pessoa(string Cpf)
        {
            Cpf = Cpf;
        }

        public Pessoa()
        {
            DataNascimento.Date.ToString("dd/mm/yyyy");
            CriadoEm = DateTime.Now;
            Contato = new Contato();
        }

        [Key]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Cpf { get; set; }

        public string Sexo { get; set; }

        public string TipoDeAcesso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 10 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Senha { get; set; }
        public Contato Contato { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}