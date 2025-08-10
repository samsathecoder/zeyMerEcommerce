using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Entities;

namespace ZeyMer.Domain.Repositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        // Özel sorgular eklenebilir
    }
}
