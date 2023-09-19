using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Domain.Interfaces.Repository
{
    public interface IGastoRepository<TContext> : IRepositoryBase<TContext, Gasto, int>
                                 where TContext : IUnitOfWork<TContext>
    {
        Task<(List<GastoDto>, int)> GetGastoAsync(int usuarioId, string item, decimal valor, int gastoTipoId, string dataCompra, int pagina);
    }
}
