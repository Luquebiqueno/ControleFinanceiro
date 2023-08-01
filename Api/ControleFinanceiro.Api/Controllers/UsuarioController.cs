using AutoMapper;
using ControleFinanceiro.Api.Models;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Interfaces.Application;
using ControleFinanceiro.Repository.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        #region [ Propriedades ]

        private readonly IUsuarioApplication<ControleFinanceiroContext> _application;
        private readonly IMapper _mapper;

        #endregion

        #region [ Contrutores ]

        public UsuarioController(IUsuarioApplication<ControleFinanceiroContext> application, IMapper mapper)
        {
            _application = application;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos ]

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetUsuario() 
            => Ok(_mapper.Map<IEnumerable<UsuarioDto>>(await _application.GetAllAsync()));
        

        [HttpGet]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = await _application.GetByIdAsync(id);
            if (usuario == null)
                return NotFound();

            return Ok(_mapper.Map<UsuarioDto>(usuario));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (model == null)
                return BadRequest();

            var usuario = model.Model();

            await _application.CreateAsync(usuario);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> UpdateUsuario([FromRoute] int id, [FromBody] UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = model.Model();

            await _application.UpdateUsuario(id, usuario);
            return Ok();

        }

        [HttpPut]
        [Route("DeleteUsuario")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteUsuario()
        {
            await _application.DeleteUsuario();
            return Ok();
        }

        [HttpPut]
        [Route("AlterarSenha")]
        [Authorize("Bearer")]
        public async Task<IActionResult> AlterarSenha(AlterarSenhaViewModel model)
        {
            await _application.AlterarSenha(model.Senha);
            return Ok();
        }

        #endregion
    }
}
