using AutoMapper;
using JWTAuthentication.Entities.Concrete;
using JWTAuthentication.Entities.DTOs.Product;

namespace JWTAuthentication.WebApi.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
