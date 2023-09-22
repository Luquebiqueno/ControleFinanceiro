using ControleFinanceiro.Common.Application;
using ControleFinanceiro.Common.Domain.Entities;
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
    public class GastoApplication<TContext> : ApplicationBase<TContext, Gasto, int>, IGastoApplication<TContext>
                             where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IGastoService<TContext> _service;

        #endregion

        #region [ Construtor ]

        public GastoApplication(IUnitOfWork<TContext> context, IGastoService<TContext> service) : base(context, service)
        {
            _service = service;
        }

        #endregion

        #region [ Métodos ]

        public async Task<(List<GastoDto>, int)> GetGastoAsync(string item, decimal valor, int gastoTipoId, DateTime? dataCompra, int pagina)
            => await _service.GetGastoAsync(item, valor, gastoTipoId, dataCompra, pagina);
        public async Task DeleteGastoAsync(int id)
        {
            await _service.DeleteGastoAsync(id);
            await _unitOfWork.CommitAsync();
        }
        public async Task<Gasto> UpdateGastoAsync(int id, Gasto entity)
        {
            await _service.UpdateGastoAsync(id, entity);
            await _unitOfWork.CommitAsync();

            return entity;
        }

        public async Task<byte[]> ExportarArquivo(string item, decimal valor, int gastoTipoId, DateTime? dataCompra)
            => await _service.ExportarArquivo(item, valor, gastoTipoId, dataCompra);

        #endregion
    }
}
