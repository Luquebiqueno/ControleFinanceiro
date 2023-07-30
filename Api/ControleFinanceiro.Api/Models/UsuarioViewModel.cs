using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Api.Models
{
    public class UsuarioViewModel : IViewModel<Usuario>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        public Usuario Model()
        {
            var usuario = new Usuario(this.Id, this.Nome, this.Email, this.Telefone);

            if (this.Id.Equals(0))
            {
                usuario.AtualizarSenha(this.Senha);
                usuario.AtualizarDataCadastro(DateTime.Now);
                usuario.Ativar();
            }

            return usuario;
        }
    }
}
