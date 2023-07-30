using ControleFinanceiro.Common.Infrastructure.Context;
using ControleFinanceiro.Repository.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.Context
{
    public class ControleFinanceiroContext : ContextBase<ControleFinanceiroContext>
    {
        public ControleFinanceiroContext(DbContextOptions<ControleFinanceiroContext> options) : base(options) { }

        public new int Commit() => this.SaveChanges();
        public new async Task<int> CommitAsync() => await this.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
