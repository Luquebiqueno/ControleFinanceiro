using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Domain.Token;
using ControleFinanceiro.Common.Infrastructure.Utils.Cryptography;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Services
{
    public class AutenticacaoService<TContext> : IAutenticacaoService<TContext>
                                where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private const string Date_Format = "yyyy-MM-dd HH:mm:ss";
        private const string messageOAuth = "Usuário Logado com sucesso.";
        private const string message = "Usuário ou Senha Errado.";
        private readonly TokenConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IUsuarioService<TContext> _usuarioService;

        #endregion

        #region [ Construtor ]

        public AutenticacaoService(TokenConfiguration configuration,
                                     ITokenService tokenService,
                                     IUsuarioService<TContext> usuarioService)
        {
            _configuration = configuration;
            _tokenService = tokenService;
            _usuarioService = usuarioService;
        }

        #endregion

        #region [ Métodos ]

        public async Task<TokenDto> GetAutenticacao(string email, string senha)
        {
            if (!string.IsNullOrEmpty(senha))
                senha = SHACryptography.Encrypt(SHACryptography.Algorithm.SHA512, senha);

            var usuario = await _usuarioService.GetUsuarioByLoginSenhaAsync(email, senha);

            if (usuario == null) 
                return new TokenDto(false, string.Empty, string.Empty, string.Empty, string.Empty, message); ;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Email)
            };

            var accessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();


            usuario.AtualizarRefreshToken(refreshToken);
            usuario.AtualizarRefreshTokenExpiryTime(DateTime.Now.AddDays(_configuration.DaysToExpiry));

            await _usuarioService.UpdateUsuarioAsync(usuario.Id, usuario);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            return new TokenDto(true, createDate.ToString(Date_Format), expirationDate.ToString(Date_Format), accessToken, refreshToken, messageOAuth);
        }

        #endregion
    }
}
