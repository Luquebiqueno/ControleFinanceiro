using AutoMapper;
using ControleFinanceiro.Domain.Dto;
using ControleFinanceiro.Domain.Entities;

namespace ControleFinanceiro.Api.AutoMapper
{
    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
