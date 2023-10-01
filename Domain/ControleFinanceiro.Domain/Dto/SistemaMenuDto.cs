using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Dto
{
    public class SistemaMenuDto
    {
        public string Descricao { get; set; }
        public string Icone { get; set; }
        public string RouterLink { get; set; }
        public List<SistemaSubMenuDto> Children { get; set; }
    }
}
