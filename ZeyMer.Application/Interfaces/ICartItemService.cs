
using ZeyMer.Domain.Entities;

namespace ZeyMer.Application.Interfaces
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetAllAsync();
        Task<CartItem> GetByIdAsync(Guid id);
        Task<CartItem> AddAsync(CartItem cartItem);
        Task UpdateAsync(CartItem cartItem);
        Task DeleteAsync(Guid id);
    }
}
