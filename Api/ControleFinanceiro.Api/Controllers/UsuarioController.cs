using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
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
        //[Authorize("Bearer")]
        public IEnumerable<UsuarioViewModel> GetUsuario()
        {
            var usuario = _application.GetAll();
            var usuarioMapper = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuario);

            return usuarioMapper;
        }

        [HttpGet]
        [Route("{id}")]
        //[Authorize("Bearer")]
        public IActionResult GetUsuarioById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = _application.GetById(id);
            var usuarioMapper = _mapper.Map<UsuarioViewModel>(usuario);
            if (usuarioMapper == null)
                return NotFound();
            return new ObjectResult(usuarioMapper);
        }

        [HttpGet]
        [Route("UsuarioLogado")]
        //[Authorize("Bearer")]
        public IActionResult GetUsuarioLogado()
        {
            var usuario = _application.GetUsuarioLogado();
            var usuarioMapper = _mapper.Map<UsuarioViewModel>(usuario);

            if (usuarioMapper == null)
                return NotFound();

            return new ObjectResult(usuarioMapper);
        }

        [HttpPost]
        //[Authorize("Bearer")]
        public IActionResult CreateUsuario([FromBody] UsuarioViewModel usuarioModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (usuarioModel == null)
                return BadRequest();

            var usuario = usuarioModel.Model();

            _application.Create(usuario);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        //[Authorize("Bearer")]
        public IActionResult UpdateUsuario([FromRoute] int id, [FromBody] UsuarioViewModel usuarioModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var usuario = usuarioModel.Model();

            _application.UpdateUsuario(id, usuario);
            return Ok();

        }

        [HttpDelete("{id}")]
        //[Authorize("Bearer")]
        public IActionResult DeleteUsuario(int id)
        {
            _application.Delete(id);
            return Ok();
        }

        #endregion
    }
}
