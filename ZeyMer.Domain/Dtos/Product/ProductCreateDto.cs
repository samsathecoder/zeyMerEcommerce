using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyMer.Domain.Dtos.Product
{
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public Guid CategoryId { get; set; }

    }
}
