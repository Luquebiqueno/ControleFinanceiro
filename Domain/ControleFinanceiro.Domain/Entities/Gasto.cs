using ControleFinanceiro.Domain.Enums;
using Generics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Entities
{
    public class Gasto : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Item { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public GastoTipo GastoTipo { get; set; }

        #endregion

        #region [ Construtores ]

        public Gasto()
        {

        }

        public Gasto(int id, string item, decimal valor, DateTime dataCompra, GastoTipo gastoTipo)
        {
            AtualizarId(id);
            AtualizarItem(item);
            AtualizarValor(valor);
            AtualizarDataCompra(dataCompra);
            AtualizarGastoTipo(gastoTipo);
        }

        #endregion

        #region [ Métodos ]

        public void AtualizarItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                AddException(nameof(Gasto), nameof(this.AtualizarItem), "campoObrigatorio", nameof(Item));

            this.Item = item;
        }
        public void AtualizarValor(decimal valor) => this.Valor = valor;
        public void AtualizarDataCompra(DateTime dataCompra)
        {
            if (dataCompra == null)
                this.DataCompra = DateTime.Now;

            this.DataCompra = dataCompra;

        }
        public void AtualizarGastoTipo(GastoTipo gastoTipo) => this.GastoTipo = gastoTipo;


        #endregion
    }
}
