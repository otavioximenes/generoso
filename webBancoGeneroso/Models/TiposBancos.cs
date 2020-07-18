﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webBancoGeneroso.Models
{
    public class TiposBancos
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}
