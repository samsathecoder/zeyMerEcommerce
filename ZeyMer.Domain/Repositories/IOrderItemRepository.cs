using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Entities;

namespace ZeyMer.Domain.Repositories
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<OrderItem?> DeleteAsync(Guid id);

    }
}
