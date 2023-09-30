using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Domain.Service;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Helpers;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Services
{
    public class DashboardService<TContext> : ServiceBase<TContext, Gasto, int>, IDashboardService<TContext>
                             where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IDashboardRepository<TContext> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public DashboardService(IDashboardRepository<TContext> repository,
                                IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Metodos ]

        public async Task<IEnumerable<DashboardDto>> GetDashboard(DateTime dataInicial, DateTime dataFinal)
            => await _repository.GetDashboard(_usuarioLogado.Usuario.Id, dataInicial, dataFinal);

        #endregion
    }
}
