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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ApplicationDbContext context) : base(context) { }

        public async Task<OrderItem> DeleteAsync(Guid id)
        {
            var orderitem = await _context.OrderItems.FindAsync(id);
            if (orderitem != null)
            {
                _context.OrderItems.Remove(orderitem);
            }
            return orderitem;
        }
    }
}
