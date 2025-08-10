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
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItem>> GetAllAsync()
        {
            return await _cartItemRepository.GetAllAsync();
        }

        public async Task<CartItem> GetByIdAsync(Guid id)
        {
            return await _cartItemRepository.GetByIdAsync(id);
        }

        public async Task<CartItem> AddAsync(CartItem cartItem)
        {
            return await _cartItemRepository.AddAsync(cartItem);
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            await _cartItemRepository.UpdateAsync(cartItem);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _cartItemRepository.DeleteAsync(id);
        }
    }
}
