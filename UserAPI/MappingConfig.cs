using AutoMapper;
using UserAPI.Models;
using UserAPI.Models.Dto;
using Microsoft.Extensions.Logging;

namespace UserAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<RegistrationRequestDTO, LocalUser>();

            CreateMap<Product, ProductDTO>().ReverseMap(); ;

            CreateMap<Product, ProductCreateDTO>().ReverseMap();
            CreateMap<Product, ProductUpdateDTO>().ReverseMap();


            CreateMap<Recipe, RecipeDTO>().ReverseMap(); ;

            CreateMap<Recipe, RecipeCreateDTO>().ReverseMap();
            CreateMap<Recipe, RecipeUpdateDTO>().ReverseMap();
        }

    }
}
