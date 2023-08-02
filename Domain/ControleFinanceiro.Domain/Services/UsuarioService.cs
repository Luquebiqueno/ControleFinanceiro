﻿using ControleFinanceiro.Common.Domain.Exceptions;
using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Domain.Service;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Helpers;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Services
{
    public class UsuarioService<TContext> : ServiceBase<TContext, Usuario, int>, IUsuarioService<TContext>
                           where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IUsuarioRepository<TContext> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public UsuarioService(IUsuarioRepository<TContext> repository,
                              IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public override async Task<Usuario> CreateAsync(Usuario entity)
        {
            await ValidarEmail(entity.Email, entity.Id);

            return await base.CreateAsync(entity);
        }
        public async Task<Usuario> GetUsuarioByLoginSenha(string login, string senha) 
            => await _repository.GetUsuarioByLoginSenha(login, senha);
        public async Task DeleteUsuario()
        {
            var usuario = await _repository.GetByIdAsync(_usuarioLogado.Usuario.Id);

            usuario.Inativar();
            usuario.AtualizarDataAlteracao();

            _repository.UpdateUsuario(usuario);
        }
        public async Task AlterarSenha(string senha)
        {
            var usuario = await _repository.GetByIdAsync(_usuarioLogado.Usuario.Id);

            usuario.AtualizarSenha(senha);
            usuario.AtualizarDataAlteracao();

            _repository.UpdateUsuario(usuario);
        }
        public async Task<Usuario> UpdateUsuario(int id, Usuario entity)
        {
            await ValidarEmail(entity.Email, id);

            var usuario = await _repository.GetByIdAsync(id);

            usuario.AtualizarNome(entity.Nome);
            usuario.AtualizarEmail(entity.Email);
            usuario.AtualizarTelefone(entity.Telefone);
            usuario.AtualizarDataAlteracao();
            usuario.AtualizarRefreshToken(entity.RefreshToken != null ? entity.RefreshToken : usuario.RefreshToken);
            usuario.AtualizarRefreshTokenExpiryTime(entity.RefreshTokenExpiryTime != null ? entity.RefreshTokenExpiryTime : usuario.RefreshTokenExpiryTime);

            return _repository.UpdateUsuario(usuario);
        }
        private async Task ValidarEmail(string email, int id)
        {
            var usuario = await GetAllAsync();

            if (usuario.Any(x => x.Email.Equals(email) && !x.Id.Equals(id)))
                throw new DomainException(nameof(UsuarioService<TContext>), nameof(ValidarEmail), "Já existe uma conta cadastrada com este e-mail.");
        }

        #endregion

    }
}
