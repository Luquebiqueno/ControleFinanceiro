using Generics.Domain.Entities;
using Generics.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Service
{
    public class ServiceBase<TContext, TEntity, TIdentity>  : IServiceBase<TContext, TEntity, TIdentity>
                                             where TEntity  : EntityBase<TIdentity>
                                             where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        protected readonly IRepositoryBase<TContext, TEntity, TIdentity> _repository;

        #endregion

        #region [ Construtores ]

        public ServiceBase(IRepositoryBase<TContext, TEntity, TIdentity> repository)
        {
            this._repository = repository;
        }

        #endregion

        #region [ Métodos ]

        public virtual TEntity Create(TEntity entity)
        {
            entity.AtualizarDataCadastro();
            _repository.Create(entity);

            return entity;
        }

        public virtual void Delete(int id) => _repository.Delete(id);

        public virtual IEnumerable<TEntity> GetAll() => _repository.GetAll();

        public virtual TEntity GetById(int id) => _repository.GetById(id);

        public virtual TEntity Update(TEntity entity)
        {
            entity.AtualizarDataAlteracao();

            _repository.Update(entity);

            return entity;
        }

        #endregion
    }
}
