using Generics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Interfaces
{
    public interface IApplicationBase<TContext, TEntity, TIdentity>
        where TEntity  : EntityBase<TIdentity>
        where TContext : IUnitOfWork<TContext>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Create(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
