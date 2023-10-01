using ControleFinanceiro.Common.Application;
using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Dto;
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
    public class SistemaMenuApplication<TContext> : ApplicationBase<TContext, SistemaMenu, int>, ISistemaMenuApplication<TContext>
                             where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly ISistemaMenuService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public SistemaMenuApplication(IUnitOfWork<TContext> context, 
                                      ISistemaMenuService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task<List<SistemaMenuDto>> GetMenu()
            => await _service.GetMenu();

        #endregion
    }
}
