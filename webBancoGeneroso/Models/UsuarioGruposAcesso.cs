using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace webBancoGeneroso.Models
{
    public class UsuarioGruposAcesso
    {
        [Key]
        public Int64 Id { get; set; }

        public Int64 IdUsuarioSistema { get; set; }

        public Int64 IdGrupoAcessos { get; set; }

        public IEnumerable<GruposAcesso> GruposAcessos { get; set; }

        /* EF Relation */
        public UsuarioSistema UsuarioSistema { get; set; }
    }
}
