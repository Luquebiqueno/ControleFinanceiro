﻿using ControleFinanceiro.Common.Domain.Entities;
using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Common.Domain.Service;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;
using ControleFinanceiro.Domain.Helpers;
using ControleFinanceiro.Domain.Interfaces.Repository;
using ControleFinanceiro.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Services
{
    public class GastoService<TContext> : ServiceBase<TContext, Gasto, int>, IGastoService<TContext>
                         where TContext : IUnitOfWork<TContext>
    {
        #region [ Propriedades ]

        private new readonly IGastoRepository<TContext> _repository;
        private readonly IUsuarioLogado _usuarioLogado;

        #endregion

        #region [ Construtor ]

        public GastoService(IGastoRepository<TContext> repository,
                              IUsuarioLogado usuarioLogado) : base(repository)
        {
            _repository = repository;
            _usuarioLogado = usuarioLogado;
        }

        #endregion

        #region [ Métodos ]

        public override IEnumerable<Gasto> GetAll()
            => base.GetAll().Where(x => x.Ativo && x.UsuarioCadastro.Equals(_usuarioLogado.Usuario.Id));
        public async Task<(List<GastoDto>, int)> GetGastoAsync(string item, decimal valor, int gastoTipoId, DateTime? dataCompra, int pagina)
            => await _repository.GetGastoAsync(_usuarioLogado.Usuario.Id, item, valor, gastoTipoId, dataCompra, pagina, false);

        public override async Task<Gasto> CreateAsync(Gasto entity)
        {
            entity.AtualizarDataCadastro(DateTime.Now);
            entity.AtualizarUsuarioCadastro(_usuarioLogado.Usuario.Id);
            entity.Ativar();

            return await base.CreateAsync(entity);
        }
        public async Task<Gasto> UpdateGastoAsync(int id, Gasto entity)
        {
            var gasto = await _repository.GetByIdAsync(id);

            gasto.AtualizarDataAlteracao(DateTime.Now);
            gasto.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario.Id);
            gasto.AtualizarItem(entity.Item);
            gasto.AtualizarValor(entity.Valor);
            gasto.AtualizarGastoTipoId(entity.GastoTipoId);
            gasto.AtualizarDataCompra(entity.DataCompra);

            return _repository.Update(gasto);
        }
        public async Task DeleteGastoAsync(int id)
        {
            var gasto = await _repository.GetByIdAsync(id);

            gasto.Inativar();
            gasto.AtualizarDataAlteracao(DateTime.Now);
            gasto.AtualizarUsuarioAlteracao(_usuarioLogado.Usuario.Id);

            base.Update(gasto);
        }

        public async Task<byte[]> ExportarArquivo(string item, decimal valor, int gastoTipoId, DateTime? dataCompra)
        {
            var (gastos, qtd) = await _repository.GetGastoAsync(_usuarioLogado.Usuario.Id, item, valor, gastoTipoId, dataCompra, 0, true);

            StringBuilder file = new StringBuilder();

            file.AppendLine("Item;Valor;Data da Compra;Tipo de Gasto");

            if (gastos.Any()) 
            {
                foreach(var gasto in gastos ) 
                {
                    file.AppendLine($"{gasto.Item};{gasto.Valor};{gasto.DataCompra};{gasto.GastoTipo}");
                }
            }

            return Encoding.UTF32.GetBytes(file.ToString());
        }

        #endregion
    }
}
