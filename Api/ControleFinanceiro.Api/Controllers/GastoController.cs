using AutoMapper;
using ControleFinanceiro.Api.Models;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastoController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IGastoApplication<ControleFinanceiroContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public GastoController(IGastoApplication<ControleFinanceiroContext> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetGastoAsync(string item, decimal valor, int gastoTipoId, string dataCompra, int pagina)
        {
            DateTime? data = null;
            if (!string.IsNullOrEmpty(dataCompra))
                data = DateTime.Parse(dataCompra);

            var (result, qtdItens) = await _application.GetGastoAsync(item, valor, gastoTipoId, data, pagina);
            return Ok(new { data = result, qtdItens });
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetGastoByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var gasto = await _application.GetByIdAsync(id);
            var gastoMapper = _mapper.Map<GastoViewModel>(gasto);
            if (gastoMapper == null)
                return NotFound();

            return Ok(gastoMapper);
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> CreateGastoAsync([FromBody] GastoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            await _application.CreateAsync(model.Model());

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UpdateGastoAsync([FromRoute] int id, [FromBody] GastoViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _application.UpdateGastoAsync(id, model.Model());
            return Ok();

        }

        [HttpPut("DeleteGasto/{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteGastoAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _application.DeleteGastoAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("ExportarArquivo")]
        [Authorize("Bearer")]
        public async Task<IActionResult> ExportarArquivo(string item, decimal valor, int gastoTipoId, string dataCompra)
        {
            DateTime? data = null;
            if (!string.IsNullOrEmpty(dataCompra))
                data = DateTime.Parse(dataCompra);

            var result = await _application.ExportarArquivo(item, valor, gastoTipoId, data);

            return File(result, "application/text");
        }

        #endregion
    }
}
