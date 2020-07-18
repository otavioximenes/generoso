using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Models
{
    public class Clientes
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 2)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "RG")]
        [StringLength(12, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 8)]
        public string RG { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 11)]
        [Display(Name = "CPF/CNPJ")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Telefone"),
            DisplayFormat(DataFormatString = "{0:(##) ####-####}", ApplyFormatInEditMode = true),
            StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone não pode ser maior que 11 digitos")]
        public string Telefone { get; set; }
         
        [Display(Name = "Telefone Celular"),
            DisplayFormat(DataFormatString = "{0:(##) ####-####}", ApplyFormatInEditMode = true),
            StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone não pode ser maior que 11 digitos")]
        public string Celular { get; set; }

        [Display(Name = "Ativo")]
        public bool Situacao { get; set; }

        [Display(Name = "Observações")]
        public String Observacoes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Tipo Pessoa")]
        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }

        /*EF Relation*/
        public IEnumerable<Endereco> Enderecos { get; set; }

        public IEnumerable<Contato> Contatos { get; set; }
    }
}
