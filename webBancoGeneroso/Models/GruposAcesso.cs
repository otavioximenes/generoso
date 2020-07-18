using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webBancoGeneroso.Models
{
    public class GruposAcesso 
    {
        [Key]
        public Int64 Id { get; set; }

        public string PageAcesso { get; set; }

        public string Role { get; set; }

        /*Ef Relation*/
        public UsuarioGruposAcesso UsuarioGruposAcesso { get; set; }
    }
}
