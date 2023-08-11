using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository<TContext> : IRepositoryBase<TContext, Usuario, int>
                                   where TContext : IUnitOfWork<TContext>
    {
        Usuario UpdateUsuario(Usuario entity);
        Task<Usuario> GetUsuarioByLoginSenhaAsync(string login, string senha);
    }
}
