using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Domain.Helpers
{
    public class TokenConfiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
