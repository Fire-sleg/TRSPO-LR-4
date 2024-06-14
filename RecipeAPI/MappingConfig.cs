using AutoMapper;
using RecipeAPI.Models;
using RecipeAPI.Models.Dto;
using Microsoft.Extensions.Logging;

namespace RecipeAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<Recipe, RecipeDTO>().ReverseMap(); ;

            CreateMap<Recipe, RecipeCreateDTO>().ReverseMap();
            CreateMap<Recipe, RecipeUpdateDTO>().ReverseMap();
        }

    }
}
