
using ZeyMer.Domain.Entities;

namespace ZeyMer.Domain.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        Task<Product?> GetBySlugAsync(string slug);
    }
}