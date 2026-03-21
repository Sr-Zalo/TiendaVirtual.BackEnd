using AutoMapper;
using TiendaVirtual.Application.DTOs.Product;
using TiendaVirtual.Application.DTOs.User;
using TiendaVirtual.Domain.Entities;

namespace TiendaVirtual.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>();

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName,
                       opt => opt.MapFrom(src => src.Role.Name));
    }
}