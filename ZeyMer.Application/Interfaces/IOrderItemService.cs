
using ZeyMer.Domain.Entities;

namespace ZeyMer.Application.Interfaces
{

    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<OrderItem> GetByIdAsync(Guid id);
        Task<OrderItem> AddAsync(OrderItem orderItem);
        Task UpdateAsync(OrderItem orderItem);
        Task DeleteAsync(Guid id);
    }
}

