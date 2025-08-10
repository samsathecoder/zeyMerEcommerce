
using ZeyMer.Domain.Entities;

namespace ZeyMer.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> DeleteUserAsync(Guid id);

        Task<User?> GetByEmailAsync(string email);
    }
}
