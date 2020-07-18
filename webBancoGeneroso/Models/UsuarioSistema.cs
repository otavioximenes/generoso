using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webBancoGeneroso.Models
{
    public class UsuarioSistema
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 2)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Foto")]
        public string PathPhoto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Phone]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} deve ter no mínimo {2} e no máximo {1} characters.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }


        public string GuidId { get; set; }

        /*EF Relation */
        public IEnumerable<UsuarioGruposAcesso> UsuarioGruposAcessos { get; set; }
    }
}
