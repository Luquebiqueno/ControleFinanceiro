using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Interfaces.Repository
{
    public interface IAuthenticationRepository
    {
        Usuario GetUsuarioByLogin(string login);
    }
}
