using AutoMapper;
using ControleFinanceiro.Api.ViewModels;
using ControleFinanceiro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFinanceiro.Api.AutoMapper
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Usuario, UsuarioViewModel>()
            .ReverseMap();

            //CreateMap<Gasto, GastoViewModel>()
            //.ReverseMap();
        }
    }
}
