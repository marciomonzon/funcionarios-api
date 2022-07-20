using AutoMapper;
using Funcionarios.Domain.DTO;
using Funcionarios.Domain.Entities;

namespace Funcionarios.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cargo, CargoDTO>().ReverseMap();
            CreateMap<Funcao, FuncaoDTO>().ReverseMap();
            CreateMap<FuncionarioCLT, FuncionarioCltDTO>().ReverseMap();
            CreateMap<FuncionarioPJ, FuncionarioPjDTO>().ReverseMap();
        }
    }
}
