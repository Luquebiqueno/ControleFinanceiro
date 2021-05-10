using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ControleFinanceiro.Domain.Enums
{
    public enum GastoTipo : int
    {
        [Display(Name = "GastoFixo")]
        GastoFixo = 1,
        [Display(Name = "GastoVariavel")]
        GastoVariavel = 2

    }
}
