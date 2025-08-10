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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetOrderByIdAsync(Guid id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Order>> GetOrdersByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
