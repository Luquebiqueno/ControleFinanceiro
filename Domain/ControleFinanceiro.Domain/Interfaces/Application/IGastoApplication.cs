using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Application
{
    public interface IGastoApplication<TContext> : IApplicationBase<TContext, Gasto, int>
                                  where TContext : IUnitOfWork<TContext>
    {
        Task<(List<GastoDto>, int)> GetGastoAsync(string item, decimal valor, int gastoTipoId, string dataCompra);
        Task<Gasto> UpdateGastoAsync(int id, Gasto entity);
        Task DeleteGastoAsync(int id);
    }
}
