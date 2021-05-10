using ControleFinanceiro.Domain.Entities;
using Generics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Interfaces.Service
{
    public interface IUsuarioService<TContext> : IServiceBase<TContext, Usuario, int>
                                where TContext : IUnitOfWork<TContext>
    {
        public Usuario UpdateUsuario(int id, Usuario entity);

        public Usuario GetUsuarioLogado();
    }
}
