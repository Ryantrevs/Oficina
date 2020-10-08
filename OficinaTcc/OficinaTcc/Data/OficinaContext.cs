using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OficinaTcc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficinaTcc.Data
{
    public class OficinaContext : IdentityDbContext<Usuario>
    {
        public OficinaContext(DbContextOptions<OficinaContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Produto>().HasKey(t => t.Id);

            builder.Entity<Servico>().HasKey(t => t.Id);
            builder.Entity<Servico>().HasMany(t => t.Colaborador);
            
            builder.Entity<Venda>().HasKey(t => t.id);
            builder.Entity<Venda>().HasOne(t => t.Funcionario);

            builder.Entity<Funcionario>().HasKey(t => t.Nome);
            builder.Entity<Funcionario>().HasMany(t => t.servicos);
        }

    }
}
