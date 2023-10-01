using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Domain.Service;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Services
{
    public class SistemaMenuService<TContext> : ServiceBase<TContext, SistemaMenu, int>, ISistemaMenuService<TContext>
                               where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly ISistemaMenuRepository<TContext> _repository;

        #endregion

        #region [ Construtor ]

        public SistemaMenuService(ISistemaMenuRepository<TContext> repository) : base(repository)
        {
            _repository = repository;
        }

        #endregion

        #region [ Métodos ]

        public async Task<List<SistemaMenuDto>> GetMenu()
            => await _repository.GetMenu();

        #endregion
    }
}
