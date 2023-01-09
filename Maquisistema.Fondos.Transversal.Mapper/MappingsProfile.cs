using AutoMapper;
using Maquisistema.Fondos.Application.DTO;
using Maquisistema.Fondos.Dominio.Entity;

namespace Maquisistema.Fondos.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap()
                .ForMember(destination => destination.ProductId, source => source.MapFrom(src => src.ProductId))
                .ForMember(destination => destination.Name, source => source.MapFrom(src => src.Name))
                .ForMember(destination => destination.Status, source => source.MapFrom(src => src.Status))
                .ForMember(destination => destination.Stock, source => source.MapFrom(src => src.Stock))
                .ForMember(destination => destination.Description, source => source.MapFrom(src => src.Description))
                .ForMember(destination => destination.Price, source => source.MapFrom(src => src.Price));
        }
    }
}
