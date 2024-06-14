using AutoMapper;
using ProductAPI.Models;
using ProductAPI.Models.Dto;
using Microsoft.Extensions.Logging;

namespace ProductAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Product, ProductDTO>().ReverseMap(); ;

            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();
        }

    }
}
