using ControleFinanceiro.Common.Domain.Interfaces;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Api.Models
{
    public class GastoViewModel : IViewModel<Gasto>
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public int GastoTipoId { get; set; }
        public Gasto Model()
        {
            return new Gasto(this.Id, this.Item, this.Valor, this.DataCompra, this.GastoTipoId);
        }
    }
}
