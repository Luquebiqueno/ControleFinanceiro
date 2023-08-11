using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Dto
{
    public class GastoDto
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public int GastoTipoId { get; set; }
        public string GastoTipo { get; set; }
    }
}
