using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _orderItemRepository.GetAllAsync();
        }

        public async Task<OrderItem> GetByIdAsync(Guid id)
        {
            return await _orderItemRepository.GetByIdAsync(id);
        }

        public async Task<OrderItem> AddAsync(OrderItem orderItem)
        {
            return await _orderItemRepository.AddAsync(orderItem);
        }

        public async Task UpdateAsync(OrderItem orderItem)
        {
            await _orderItemRepository.UpdateAsync(orderItem);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _orderItemRepository.DeleteAsync(id);
        }
    }
}
