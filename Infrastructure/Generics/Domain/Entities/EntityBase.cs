using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.Domain.Entities
{
    public abstract class EntityBase<TIdentity> : ValidatableObject
    {
        #region [ Propriedades ]

        public TIdentity Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int UsuarioCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public int? UsuarioAlteracao { get; set; }
        public bool Ativo { get; set; }

        #endregion

        #region [ Métodos ]

        public virtual void AtualizarId(TIdentity id)
        {
            if (id == null)
                AddException(nameof(EntityBase<TIdentity>), nameof(this.Id), "campoObrigatorio", "id");

            if (string.IsNullOrEmpty(id.ToString()))
                AddException(nameof(EntityBase<TIdentity>), nameof(this.Id), "campoObrigatorio", "id");

            this.Id = id;
        }
        public virtual void AtualizarDataCadastro(DateTime? data = null) => this.DataCadastro = data.HasValue ? data.GetValueOrDefault() : DateTime.Now;
        public virtual void AtualizarDataAlteracao(DateTime? data = null) => this.DataAlteracao = data.HasValue ? data.GetValueOrDefault() : DateTime.Now;
        public virtual void AtualizarUsuarioCadastro(int usuarioId)
        {
            if (usuarioId <= 0)
                AddException(nameof(EntityBase<TIdentity>), nameof(this.UsuarioCadastro), "campoObrigatorioId", "usuario");

            this.UsuarioCadastro = usuarioId;
        }
        public virtual void AtualizarUsuarioAlteracao(int? usuarioId)
        {
            if (usuarioId <= 0)
                AddException(nameof(EntityBase<TIdentity>), nameof(this.UsuarioAlteracao), "campoObrigatorioId", "usuario");

            this.UsuarioAlteracao = usuarioId;
        }
        public virtual void Ativar() => this.Ativo = true;
        public virtual void Inativar() => this.Ativo = false;

        #endregion
    }
}
