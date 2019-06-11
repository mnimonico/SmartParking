using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoSmartParking.Models
{
    [Table("Contatos")]
    public class Contato
    {
        public Contato()
        {
            CriadoEm = DateTime.Now;
        }

        [Key]
        public int ContatoId { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        //public List<Pessoa> Pessoas { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
