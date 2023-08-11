using ControleFinanceiro.Common.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Domain.Entities
{
    public class GastoTipo : EntityBase<int>
    {
        #region [ Propriedades ]

        public string Descricao { get; protected set; }

        #endregion

        #region [ Construtor ]

        public GastoTipo()
        {

        }

        public GastoTipo(int id, string descricao)
        {
            AtualizarId(id);
            AtualizarDescricao(descricao);
        }

        #endregion

        #region [ Métodos ]
        public void AtualizarDescricao(string descricao) => this.Descricao = descricao;

        #endregion
    }
}
