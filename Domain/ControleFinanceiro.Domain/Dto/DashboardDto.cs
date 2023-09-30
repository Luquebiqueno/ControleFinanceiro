using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Dto
{
    public class DashboardDto
    {
        public string Mes { get; set; }
        public decimal GastoFixo { get; set; }
        public decimal GastoVariavel { get; set; }
    }
}
