using System.ComponentModel.DataAnnotations;

namespace webBancoGeneroso.Models
{
    public class ClienteModel
    {
        [Required]
        public Clientes cliente { get; set; }

        [Required]
        public Contato contato { get; set; }

        [Required]
        public Endereco endereco { get; set; }
    }
}
