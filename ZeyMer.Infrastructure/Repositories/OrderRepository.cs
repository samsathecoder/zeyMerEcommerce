using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

       
    }
}

