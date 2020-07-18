using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Models
{
    public class DadosBancarios
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "O campo Banco é obrigatório")]
        [Display(Name = "Banco")]
        public int TiposBancosId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:##.###.###/####-##}", ApplyFormatInEditMode = true)]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "CNPJ não pode ser maior que 14 digitos.")] 
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 4)]
        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 2)]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Número Conta")]
        [StringLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 4)]
        public string Numero { get; set; }


        /*EF Relation */
        public TiposBancos TiposBancos { get; set; }
    }
}
