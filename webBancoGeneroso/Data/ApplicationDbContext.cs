using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webBancoGeneroso.Models;

namespace webBancoGeneroso.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Clientes> Clientes { get; set; }

        public DbSet<Contato> Contato { get; set; }

        public DbSet<Endereco> Endereco { get; set; }

        public DbSet<UserCustomerModel> UserCustomerModels { get; set; }

        public DbSet<TiposBancos> TiposBancos { get; set; }

        public DbSet<DadosBancarios> DadosBancarios { get; set; }

        public DbSet<Minuta> Minuta { get; set; }

        public DbSet<UsuarioSistema> usuarioSistemas { get; set; }
        
        public DbSet<GruposAcesso> gruposAcessos { get; set; }

        public DbSet<UsuarioGruposAcesso> UsuarioGruposAcessos { get; set; }
    }
}
