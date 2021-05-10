using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Service;
using Generics.Domain.Interfaces;
using Generics.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Services
{
    public class UsuarioService<TContext> : ServiceBase<TContext, Usuario, int>, IUsuarioService<TContext>
                           where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IRepositoryBase<TContext, Usuario, int> _repository;

        #endregion

        #region [ Construtor ]

        public UsuarioService(IRepositoryBase<TContext, Usuario, int> repository) : base(repository)
        {
            _repository = repository;
        }

        #endregion

        #region [ Métodos ]

        public override Usuario Create(Usuario entity)
        {
            entity.AtualizarNome(entity.Nome);
            entity.AtualizarEmail(entity.Email);
            entity.AtualizarTelefone(entity.Telefone);
            entity.AtualizarLogin(entity.Login);
            entity.AtualizarSenha(entity.Senha);
            entity.AtualizarDataCadastro();

            return base.Create(entity);
        }

        public Usuario GetUsuarioLogado()
        {
            return _repository.GetById(1);
        }

        public Usuario UpdateUsuario(int id, Usuario entity)
        {
            var usuario = _repository.Exists(id);

            usuario.AtualizarNome(entity.Nome);
            usuario.AtualizarEmail(entity.Email);
            usuario.AtualizarTelefone(entity.Telefone);
            usuario.AtualizarLogin(entity.Login);
            usuario.AtualizarDataAlteracao();
            usuario.AtualizarUsuarioAlteracao(1);

            return base.Update(usuario);
        }

        #endregion

    }
}
