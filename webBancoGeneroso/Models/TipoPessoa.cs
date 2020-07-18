using System.ComponentModel.DataAnnotations;

namespace webBancoGeneroso.Models
{
    public enum TipoPessoa
    {
        [Display(Name = "1-Pessoa Física")]
        PessoaFisica = 1,

        [Display(Name = "2-Pessoa Jurídica")]
        PessoaJuridica
    }
}
