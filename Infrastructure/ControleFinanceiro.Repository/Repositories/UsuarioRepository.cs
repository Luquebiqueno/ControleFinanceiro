using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Infrastructure.Repository;
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
    public class UsuarioRepository<TContext> : RepositoryBase<TContext, Usuario, int>, IUsuarioRepository<TContext>
                              where TContext : IUnitOfWork<TContext>
    {
        public UsuarioRepository(IUnitOfWork<TContext> unitOfWork) : base(unitOfWork) { }

        public override async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _dbSet.Where(x => x.Ativo).ToListAsync();
        }
        public Usuario UpdateUsuario(Usuario entity)
        {
            try
            {
                if (entity != null)
                {
                    var result = _dbSet.Attach(entity);
                    result.State = EntityState.Modified;
                    result.Property(x => x.DataCadastro).IsModified = false;

                    return entity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
