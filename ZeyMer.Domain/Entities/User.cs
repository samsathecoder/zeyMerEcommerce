using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeyMer.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }  // Şifre hash’i buraya
        public byte[] PasswordSalt { get; set; }  // Salt buraya
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } // "Admin" veya "User"

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
