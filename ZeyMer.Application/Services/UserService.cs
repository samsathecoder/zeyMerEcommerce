
using AutoMapper;
using System.ComponentModel;
using ZeyMer.Application.Interfaces;
using ZeyMer.Domain.Dtos.User;
using ZeyMer.Domain.Entities;
using ZeyMer.Domain.Repositories;
using ZeyMer.Application.Helper;
    namespace ZeyMer.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;

            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public User? Authenticate(string email, string password)
        {
            var user = _userRepository.GetByEmailAsync(email).Result;

            if (user == null)
                return null;

            bool isPasswordValid = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

            if (!isPasswordValid)
                return null;

            return user;
        }
        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await _userRepository.DeleteUserAsync(id);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task<User> RegisterAsync(UserRegisterDto dto)
        {
            // Business Rule: Email zaten kayıtlı mı?
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Bu email zaten kayıtlı.");
            if (dto.Password != dto.PasswordConfirm)
                throw new Exception("Şifreler eşleşmiyor.");
            HashingHelper.CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<User>(dto);
            user.Id = Guid.NewGuid();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Role = "Customer"; 

            user.CreatedAt = DateTime.UtcNow;

            return await _userRepository.AddAsync(user);
        }

        public async Task<User> LoginAsync(UserLoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null)
                throw new Exception("Kullanıcı bulunamadı.");

            bool isPasswordValid = HashingHelper.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isPasswordValid)
                throw new Exception("Şifre hatalı.");

            return user; // JWT token üretimini controller'da yapabilirsin
        }
    }
}