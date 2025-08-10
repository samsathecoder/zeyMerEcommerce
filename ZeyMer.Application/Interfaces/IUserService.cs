using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Dtos.User;
using ZeyMer.Domain.Entities;

namespace ZeyMer.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<User> RegisterAsync(UserRegisterDto dto);
        Task<User> LoginAsync(UserLoginDto dto);
        User? Authenticate(string email, string password);

    }
}
