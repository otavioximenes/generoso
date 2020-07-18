using System;
using System.ComponentModel.DataAnnotations;

namespace webBancoGeneroso.Models
{
    public class Endereco
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 3)]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name ="Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        [Display(Name = "CEP"),
            DisplayFormat(DataFormatString = "{0:#####-###}", ApplyFormatInEditMode = true),
            StringLength(8, MinimumLength = 8, ErrorMessage = "CEP não pode ser maior que 8 digitos.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }

        /*EF Relation */
        public Clientes Cliente { get; set; }
    }
}