using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Domain.Interfaces.Service;
using Generics.Application;
using Generics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Application.ServiceApplications
{
    public class UsuarioApplication<TContext> : ApplicationBase<TContext, Usuario, int>, IUsuarioApplication<TContext>
                               where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IUsuarioService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public UsuarioApplication(IUnitOfWork<TContext> context, IUsuarioService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public Usuario UpdateUsuario(int id, Usuario entity)
        {
            _service.UpdateUsuario(id, entity);
            _unitOfWork.Commit();

            return entity;
        }

        public Usuario GetUsuarioLogado() => _service.GetUsuarioLogado();

        #endregion
    }
}
