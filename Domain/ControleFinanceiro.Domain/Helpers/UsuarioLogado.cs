using ControleFinanceiro.Common.Domain.Entities;
using ControleFinanceiro.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Helpers
{
    public class UsuarioLogado : IUsuarioLogado
    {
        #region [ Propriedades ]

        private readonly IHttpContextAccessor _accessor;
        private readonly IUsuarioLogadoRepository _usuarioLogadoRepository;

        #endregion

        #region [ Construtores ]

        public UsuarioLogado(IHttpContextAccessor accessor,
                             IUsuarioLogadoRepository usuarioLogadoRepository)
        {
            _accessor = accessor;
            _usuarioLogadoRepository = usuarioLogadoRepository;
        }

        #endregion

        #region [ Métodos ]

        public UsuarioIdentity Usuario => _usuarioLogadoRepository.GetUsuarioLogado(_accessor.HttpContext.User.Identity.Name);

        #endregion
    }
}
