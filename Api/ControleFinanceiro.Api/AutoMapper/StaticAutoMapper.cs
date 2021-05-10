using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.AutoMapper
{
    public static class StaticAutoMapper
    {
        #region [ Propriedades ]

        private static IMapper _mapper;

        #endregion

        #region [ Métodos ]

        public static IMapper GetInstance()
        {
            return _mapper;
        }

        public static void Set(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion
    }
}
