using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Dto
{
    public class TokenDto
    {
        #region [ Propriedades ]

        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }

        #endregion

        #region [ Construtores ]

        public TokenDto(bool authenticated, string created, string expiration, string accessToken, string refreshToken, string message)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Message = message;
        }

        #endregion
    }
}
