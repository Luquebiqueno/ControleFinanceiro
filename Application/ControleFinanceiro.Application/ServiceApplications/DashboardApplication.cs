using ControleFinanceiro.Common.Application;
using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Helpers;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Application.ServiceApplications
{
    public class DashboardApplication<TContext> : ApplicationBase<TContext, Gasto, int>, IDashboardApplication<TContext>
                                 where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IDashboardService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public DashboardApplication(IUnitOfWork<TContext> context, IDashboardService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Metodos ]

        public async Task<IEnumerable<DashboardDto>> GetDashboard(DateTime dataInicial, DateTime dataFinal)
            => await _service.GetDashboard(dataInicial, dataFinal);

        #endregion
    }
}
