using ControleFinanceiro.Api.Models;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IAutenticacaoApplication<ControleFinanceiroContext> _autenticacaoApplication;

        #endregion

        #region [ Contrutores ]

        public AutenticacaoController(IAutenticacaoApplication<ControleFinanceiroContext> autenticacaoApplication)
        {
            _autenticacaoApplication = autenticacaoApplication;
        }

        #endregion

        #region [ Métodos ]

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetAutenticacao([FromBody] UsuarioLoginViewModel model)
        {
            if (model == null)
                return BadRequest("Invalid client request");

            var token = await _autenticacaoApplication.GetAutenticacao(model.Email, model.Senha);

            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        #endregion
    }
}
