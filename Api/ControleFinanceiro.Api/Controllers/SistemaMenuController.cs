using AutoMapper;
using ControleFinanceiro.Api.Models;
using ControleFinanceiro.Application.ServiceApplications;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemaMenuController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly ISistemaMenuApplication<ControleFinanceiroContext> _application;

        #endregion

        #region [ Contrutores ]

        public SistemaMenuController(ISistemaMenuApplication<ControleFinanceiroContext> application)
        {
            _application = application;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetMenu()
        {
            var result = await _application.GetMenu();
            return Ok(result);
        }

        #endregion
    }
}
