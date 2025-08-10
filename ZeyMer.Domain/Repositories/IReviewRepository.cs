using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Entities;

namespace ZeyMer.Domain.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        // İleride Review'a özel query'ler eklenebilir
    }
}
