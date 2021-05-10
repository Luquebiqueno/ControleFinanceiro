using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repository;
using Generics.Domain.Interfaces;
using Generics.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Repository.Repositories
{
    public class UsuarioRepository<TContext> : RepositoryBase<TContext, Usuario, int>, IUsuarioRepository<TContext>
                              where TContext : IUnitOfWork<TContext>
    {
        public UsuarioRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }
    }
}
