using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Infrastructure.Repository;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        public async Task<(List<GastoDto>, int)> GetGastoAsync(int usuarioId, string item, decimal valor, int gastoTipoId, DateTime? dataCompra, int pagina, bool exportar = false)
        {
                var query = (from ga in _context.Set<Gasto>()
                             join gt in _context.Set<GastoTipo>() on ga.GastoTipoId equals gt.Id
                             where (ga.Ativo && ga.UsuarioCadastro.Equals(usuarioId) && (ga.DataCompra == dataCompra || dataCompra == null)
                                && (ga.Item.Contains(item) || item == null) && (ga.Valor == valor || valor == 0) && (ga.GastoTipoId == gastoTipoId || gastoTipoId == 0))
                             select new GastoDto
                             {
                                 Id = ga.Id,
                                 Item = ga.Item,
                                 Valor = ga.Valor,
                                 DataCompra = ga.DataCompra,
                                 GastoTipoId = ga.GastoTipoId,   
                                 GastoTipo = gt.Descricao
                             });

            if (!exportar)
            {
                return (await query.OrderByDescending(x => x.DataCompra).Skip(pagina).Take(5).ToListAsync(), await query.CountAsync());
            }
            else
            {
                return (await query.OrderByDescending(x => x.DataCompra).ToListAsync(), await query.CountAsync());
            }
        }
    }
}
