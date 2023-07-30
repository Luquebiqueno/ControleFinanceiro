using ControleFinanceiro.Common.Domain.Entities;
using ControleFinanceiro.Common.Infrastructure.Utils.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public class Usuario : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Telefone { get; protected set; }
        public string Senha { get; protected set; }
        public string RefreshToken { get; protected set; }
        public DateTime? RefreshTokenExpiryTime { get; protected set; }

        #endregion

        #region [ Construtor ]

        public Usuario()
        {

        }

        public Usuario(int id, string nome, string email, string telefone)
        {
            AtualizarId(id);
            AtualizarNome(nome);
            AtualizarEmail(email);
            AtualizarTelefone(telefone);
        }

        #endregion

        #region [ Métodos ]

        public override void AtualizarId(int id) => this.Id = id;
        public void AtualizarSenha(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                AddException(nameof(Usuario), nameof(this.AtualizarSenha), "campoObrigatorio", nameof(Senha));

            string senhaEncript = "";

            if (!string.IsNullOrEmpty(senha))
                senhaEncript = SHACryptography.Encrypt(SHACryptography.Algorithm.SHA512, senha);

            this.Senha = senhaEncript;
        }
        public void AtualizarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                AddException(nameof(Usuario), nameof(this.AtualizarNome), "campoObrigatorio", nameof(Nome));

            this.Nome = nome;
        }
        public void AtualizarEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                AddException(nameof(Usuario), nameof(this.AtualizarEmail), "campoObrigatorio", nameof(Email));

            this.Email = email;
        }
        public void AtualizarTelefone(string telefone) => this.Telefone = telefone;
        public void AtualizarRefreshToken(string refreshToken) => this.RefreshToken = refreshToken;
        public void AtualizarRefreshTokenExpiryTime(DateTime? refreshTokenExpiryTime) => this.RefreshTokenExpiryTime = refreshTokenExpiryTime;

        #endregion
    }
}
