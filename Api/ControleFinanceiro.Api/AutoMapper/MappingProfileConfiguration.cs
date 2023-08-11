using AutoMapper;
using ControleFinanceiro.Api.Models;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Api.AutoMapper
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<Gasto, GastoViewModel>()
            .ReverseMap();
        }
    }
}
