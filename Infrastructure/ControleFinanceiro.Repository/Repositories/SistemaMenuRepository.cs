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
    public class SistemaMenuRepository<TContext> : RepositoryBase<TContext, SistemaMenu, int>, ISistemaMenuRepository<TContext>
                                  where TContext : IUnitOfWork<TContext>
    {
        public SistemaMenuRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }

        public async Task<List<SistemaMenuDto>> GetMenu()
        {
            try
            {
                var lista = await _dbSet.Include(x => x.Children.Where(w => w.Ativo).OrderBy(w => w.Ordem))
                                         .Where(y => y.Ativo && y.ParentId == null)
                                         .OrderBy(z => z.Ordem)
                                         .ToListAsync();

                var menus = lista.Select(x => new SistemaMenuDto
                {
                    Descricao = x.Descricao,
                    Icone = x.Icone,
                    RouterLink = x.RouterLink,
                    Children = x.Children.Any() ? x.Children.Select(y => new SistemaSubMenuDto 
                    { 
                        Descricao = y.Descricao,
                        Icone = y.Icone,
                        RouterLink = y.RouterLink
                    }).ToList() : null
                }).ToList();

                return menus;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
