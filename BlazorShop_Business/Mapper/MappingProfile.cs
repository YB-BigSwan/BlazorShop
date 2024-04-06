using AutoMapper;
using BlazorShop_DataAccess;
using BlazorShop_Models;

namespace BlazorShop_Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<ProductPrice, ProductPriceDTO>().ReverseMap();
    }
}