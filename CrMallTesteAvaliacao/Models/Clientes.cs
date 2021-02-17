using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrMallTesteAvaliacao.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Data_de_nascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        public string Sexo { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "UF")]
        public string Estado { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
    }
}
