using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeyMer.Domain.Repositories;

namespace ZeyMer.Application.BusinessRules
{

    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailMustBeUnique(string email)
        {
            var exists = await _userRepository.GetByEmailAsync(email);
            if (exists != null)
                throw new Exception("Email zaten kullanılıyor.");
        }
    }
}
