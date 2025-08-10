
using AutoMapper;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Dtos.Product;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.Services
{
    public class ProductService : GenericService<Product, ProductCreateDto, ProductUpdateDto, ProductDto>, IProductService
    {
        public ProductService(IProductRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
        }

        public Task<Product> AddAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetBySlugAsync(string slug)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductService.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
