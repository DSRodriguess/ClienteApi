using AutoMapper;
using ClienteApi.Application.DTOs;
using ClienteApi.Domain;

namespace ClienteApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteDto>();
            CreateMap<CreateClienteDto, Cliente>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));
            CreateMap<UpdateClienteDto, Cliente>()
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco));

            CreateMap<CreateEnderecoDto, Endereco>().ReverseMap();
            CreateMap<UpdateEnderecoDto, Endereco>().ReverseMap();
        }
    }
}