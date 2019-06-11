using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Carros")]
    public class Carro
    {
        public Carro()
        {
            CriadoEm = DateTime.Now;
        }
        [Key]

        public int CarroId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MaxLength(20, ErrorMessage = "No máximo 20 caracteres!")]
        [MinLength(2, ErrorMessage = "No mínimo 2 caracteres!")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public DateTime Ano { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
