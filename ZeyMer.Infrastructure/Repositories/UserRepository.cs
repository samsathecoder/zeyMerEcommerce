using Microsoft.EntityFrameworkCore;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;
using ZeyMer.Infrastructure.Data;

namespace ZeyMer.Infrastructure.Repositories



{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        

        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
