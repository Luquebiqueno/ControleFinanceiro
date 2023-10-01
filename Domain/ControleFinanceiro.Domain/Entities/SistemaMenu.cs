using ControleFinanceiro.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public class SistemaMenu : EntityBase<int>
    {
        #region [ Propriedades ]

        public int? ParentId { get; protected set; }
        public string Descricao { get; protected set; }
        public string Icone { get; protected set; }
        public string RouterLink { get; protected set; }
        public int Ordem { get; protected set; }
        public virtual IEnumerable<SistemaMenu> Children { get; set; }
        public virtual SistemaMenu SistemaMenu1 { get; set; }

        #endregion

        #region [ Construtor ]

        public SistemaMenu()
        {
            Children = new List<SistemaMenu>(); 
        }

        #endregion

        #region [ Métodos ]
        #endregion
    }
}
