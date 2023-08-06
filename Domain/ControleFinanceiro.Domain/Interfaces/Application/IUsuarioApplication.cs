using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Application
{
    public interface IUsuarioApplication<TContext> : IApplicationBase<TContext, Usuario, int>
                                    where TContext : IUnitOfWork<TContext>
    {
        Task<Usuario> UpdateUsuario(int id, Usuario entity);
        Task DeleteUsuario();
        Task AlterarSenha(string senha);
        Task<Usuario> GetUsuarioLogado();
    }
}
