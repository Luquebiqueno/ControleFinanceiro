using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Interfaces.Application
{
    public interface IAutenticacaoApplication<TContext> where TContext : IUnitOfWork<TContext>
    {
        Task<TokenDto> GetAutenticacao(string login, string senha);
    }
}
