using RecipeAPI.Models;
using System.Linq.Expressions;

namespace RecipeAPI.Repository.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {   
        Task<Recipe> UpdateAsync(Recipe entity);
    }
}
