using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;
using ZeyMer.Infrastructure.Data;

namespace ZeyMer.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Product?> GetBySlugAsync(string slug)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Slug == slug);
        }
    }
}
