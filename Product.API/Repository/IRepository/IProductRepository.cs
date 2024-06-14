using ProductAPI.Models;
using System.Linq.Expressions;

namespace ProductAPI.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product entity);
    }
}
