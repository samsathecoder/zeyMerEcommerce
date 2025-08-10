using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyMer.Domain.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; } // 1-5 arası puan
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
