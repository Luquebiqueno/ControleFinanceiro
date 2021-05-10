using Generics.Domain.Entities;
using Generics.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics.Infra.Repository
{
    public class RepositoryBase<TContext, TEntity, TIdentity>   : IRepositoryBase<TContext, TEntity, TIdentity>
                                                where TEntity   : EntityBase<TIdentity>
                                                where TContext  : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        public IUnitOfWork<TContext> UnitOfWork { get; }
        protected DbSet<TEntity> _dbSet => ((DbContext)UnitOfWork).Set<TEntity>();

        #endregion

        #region [ Construtores ]

        public RepositoryBase(IUnitOfWork<TContext> unitOfWork) => this.UnitOfWork = unitOfWork;

        #endregion

        #region [ Métodos ]

        public virtual TEntity Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public virtual void Delete(int id)
        {
            try
            {
                TEntity entity = Exists(id);
                if (entity != null)
                    _dbSet.Remove(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity Exists(int id)
        {
            try
            {
                return _dbSet.SingleOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                return _dbSet.SingleOrDefault(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            try
            {
                if (entity != null)
                {
                    var result = _dbSet.Attach(entity);
                    result.State = EntityState.Modified;
                    result.Property(x => x.UsuarioCadastro).IsModified = false;
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
                throw ex;
            }
        }

        #endregion
    }
}

