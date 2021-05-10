using ControleFinanceiro.Repository.Maps;
using Generics.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Repository.Context
{
    public class ControleFinanceiroContext : ContextBase<ControleFinanceiroContext>
    {
        public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options) : base(options) { }

        public new int Commit() => this.SaveChanges();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
