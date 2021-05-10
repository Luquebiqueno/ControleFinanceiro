using Generics.Domain.Entities;
using Generics.Infra.Utils.Cryptography;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Entities
{
    public class Usuario : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Nome { get; set; }
        public string Email { get; set; }
        public long? Telefone { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        #endregion

        #region [ Contrutores ]

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string email, long? telefone, string login)
        {
            AtualizarId(id);
            AtualizarNome(nome);
            AtualizarEmail(email);
            AtualizarTelefone(telefone);
            AtualizarLogin(login);
        }

        #endregion

        #region [ Métodos ]

        public void AtualizarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                AddException(nameof(Usuario), nameof(this.AtualizarNome), "campoObrigatorio", nameof(Nome));

            this.Nome = nome;
        }

        public void AtualizarEmail(string email) => this.Email = email;

        public void AtualizarTelefone(long? telefone) => this.Telefone = telefone;

        public void AtualizarLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                AddException(nameof(Usuario), nameof(this.AtualizarLogin), "campoObrigatorio", nameof(Login));

            this.Login = login;
        }

        public void AtualizarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                AddException(nameof(Usuario), nameof(this.AtualizarSenha), "campoObrigatorio", nameof(Senha));

            string senhaEncript = SHACryptography.Encrypt(SHACryptography.Algorithm.SHA512, senha);

            this.Senha = senhaEncript;
        }

        #endregion
    }
}
