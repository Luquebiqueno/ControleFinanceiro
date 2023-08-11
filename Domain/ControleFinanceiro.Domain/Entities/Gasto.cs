using ControleFinanceiro.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public class Gasto : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Item { get; protected set; }
        public decimal Valor { get; protected set; }
        public DateTime DataCompra { get; protected set; }
        public int GastoTipoId { get; protected set; }

        public GastoTipo GastoTipo { get; set; }


        #endregion

        #region [ Construtor ]

        public Gasto()
        {

        }
        public Gasto(int id, string item, decimal valor, DateTime dataCompra, int gastoTipoId)
        {
            AtualizarId(id);
            AtualizarItem(item);
            AtualizarValor(valor);
            AtualizarDataCompra(dataCompra);
            AtualizarGastoTipoId(gastoTipoId);
        }

        #endregion

        #region [ Métodos ]

        public override void AtualizarId(int id) => this.Id = id;
        public void AtualizarGastoTipoId(int gastoTipoId)
        {
            if (gastoTipoId <= 0)
                AddException(nameof(Gasto), nameof(this.AtualizarGastoTipoId), "campoObrigatorio", nameof(GastoTipoId));

            this.GastoTipoId = gastoTipoId;
        }
        public void AtualizarDataCompra(DateTime dataCompra) => this.DataCompra = dataCompra;
        public void AtualizarValor(decimal valor)
        {
            if (valor <= 0)
                AddException(nameof(Gasto), nameof(this.AtualizarValor), "campoObrigatorio", nameof(Valor));

            this.Valor = valor;
        }
        public void AtualizarItem(string item)
        {
            if (string.IsNullOrEmpty(item))
                AddException(nameof(Gasto), nameof(this.AtualizarItem), "campoObrigatorio", nameof(Item));

            this.Item = item;
        }

        #endregion
    }
}
