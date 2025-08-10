using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Dtos.Product;
using ZeyMer.Domain.Entities;

namespace ZeyMer.Application.Interfaces
{
    public interface IProductService
    {

    Task<ProductDto> CreateAsync(ProductCreateDto dto);
        Task<ProductDto?> UpdateAsync(ProductUpdateDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ProductDto>> GetAllAsync();

    }
}
