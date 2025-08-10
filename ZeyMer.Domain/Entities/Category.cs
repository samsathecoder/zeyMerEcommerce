using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace ZeyMer.Domain.Entities
    {
        public class Category
        {
            public Guid CategoryId { get; set; } = Guid.NewGuid();

            [Required, MaxLength(100)]
            public string Name { get; set; } = string.Empty;

            [MaxLength(250)]
            public string? Description { get; set; }

            // Navigation
            public ICollection<Product> Products { get; set; } = new List<Product>();
        }
    }
