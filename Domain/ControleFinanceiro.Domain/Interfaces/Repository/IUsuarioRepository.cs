using ControleFinanceiro.Domain.Entities;
using Generics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository<TContext> : IRepositoryBase<TContext, Usuario, int>
                                   where TContext : IUnitOfWork<TContext>
    {
    }
}
