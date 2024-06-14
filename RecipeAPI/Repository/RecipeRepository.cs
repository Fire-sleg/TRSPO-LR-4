using AutoMapper;
using RecipeAPI.Data;
using RecipeAPI.Models;
using RecipeAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace RecipeAPI.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly ApplicationDbContext _db;
        public RecipeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Recipe> UpdateAsync(Recipe entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Recipes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

       
    }
}
