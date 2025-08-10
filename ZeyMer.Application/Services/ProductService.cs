
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product?> GetBySlugAsync(string slug)
        {
            return await _productRepository.GetBySlugAsync(slug);
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync(); 
            return product;
        }
    }
}
