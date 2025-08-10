
using Microsoft.EntityFrameworkCore;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;
using ZeyMer.Infrastructure.Data;

namespace ZeyMer.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
