using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Models
{
    public class Contato
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 ClienteId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 2)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Telefone Celular")]
        public string Celular { get; set; }

        /* EF Relation */
        public Clientes Cliente { get; set; }
    }
}
