
using AutoMapper;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Dtos.Product;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.Services
{
    public class ProductService : GenericService<Product, ProductCreateDto, ProductUpdateDto, ProductDto>, IProductService
    {
        private readonly IProductRepository _productRepository;
        
        public ProductService(IProductRepository repo, IMapper mapper)
            : base(repo, mapper)
        {
        }


        public async Task<ProductDto> CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
           
      
            product.Slug = GenerateSlug(dto.Title);
            product.UrlName = dto.Title.Replace(" ", "-").ToLower(); 
            product.InStock = true;
            product.Quantity = 0;  
            product.Status = "Active";
            product.LikeCount = 0;
            product.CreatedAt = DateTime.UtcNow;

            var created = await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDto>(created);
        }
        
        private string GenerateSlug(string title)
        {
            return title.ToLower().Replace(" ", "-");
        }

    }
}
