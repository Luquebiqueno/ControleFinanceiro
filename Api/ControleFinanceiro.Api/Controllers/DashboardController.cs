using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IDashboardApplication<ControleFinanceiroContext> _application;

        #endregion

        #region [ Contrutores ]

        public DashboardController(IDashboardApplication<ControleFinanceiroContext> application)
        {
            _application = application;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetDashboard(string dataInicial, string dataFinal)
        {
            return Ok(await _application.GetDashboard(DateTime.Parse(dataInicial), DateTime.Parse(dataFinal)));
        }

        #endregion
    }
}
