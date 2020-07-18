using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Models
{
    public class Minuta
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Código de fiança")]
        public string Codigo { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Data de Emissão")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Data de Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "ADM ( % )")]
        public int Adm { get; set; }

        [Display(Name = "Valor ADM.")]
        public decimal ValorAdmin { get; set; }

        public Int64 ClienteId { get; set; }


        /*EF Relation */
        public Clientes Cliente { get; set; }
    }
}
