using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Infrastructure.Repository;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Repository.Repositories
{
    public class GastoRepository<TContext> : RepositoryBase<TContext, Gasto, int>, IGastoRepository<TContext>
                            where TContext : IUnitOfWork<TContext>
    {
        protected DbContext _context;
        public GastoRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) 
        {
            _context = ((DbContext)unitOfWork);
        }

        public async Task<(List<GastoDto>, int)> GetGastoAsync(int usuarioId, string item, decimal valor, int gastoTipoId, string dataCompra, int pagina)
        {
            var query = (from ga in _context.Set<Gasto>()
                         join gt in _context.Set<GastoTipo>() on ga.GastoTipoId equals gt.Id
                         where (ga.Ativo && ga.UsuarioCadastro.Equals(usuarioId))
                         select new GastoDto
                         {
                             Id = ga.Id,
                             Item = ga.Item,
                             Valor = ga.Valor,
                             DataCompra = ga.DataCompra,
                             GastoTipoId = ga.GastoTipoId,   
                             GastoTipo = gt.Descricao
                         });

            if (!string.IsNullOrEmpty(dataCompra))
                query = query.Where(x => x.DataCompra == DateTime.Parse(dataCompra));

            if (!string.IsNullOrEmpty(item))
                query = query.Where(x => x.Item.Contains(item));

            if (valor > 0)
                query = query.Where(x => x.Valor.Equals(valor));

            if (gastoTipoId > 0)
                query = query.Where(x => x.GastoTipoId.Equals(gastoTipoId));

            var qtdItens = await query.CountAsync();
            var result = await query.OrderByDescending(x => x.Id).Skip(pagina).Take(5).ToListAsync();

            return (result, qtdItens);
        }
    }
}
