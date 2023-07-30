using ControleFinanceiro.Common.Application;
using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Usuario> UpdateUsuario(int id, Usuario entity)
        {
            await _service.UpdateUsuario(id, entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task AlterarSenha(string senha)
        {
            await _service.AlterarSenha(senha);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteUsuario()
        {
            await _service.DeleteUsuario();
            await _unitOfWork.CommitAsync();
        }

        #endregion
    }
}
