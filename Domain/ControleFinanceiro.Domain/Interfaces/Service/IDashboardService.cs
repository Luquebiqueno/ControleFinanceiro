﻿using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Service
{
    public interface IDashboardService<TContext> : IServiceBase<TContext, Gasto, int>
                                  where TContext : IUnitOfWork<TContext>
    {
        Task<IEnumerable<DashboardDto>> GetDashboard(DateTime dataInicial, DateTime dataFinal);
    }
}
