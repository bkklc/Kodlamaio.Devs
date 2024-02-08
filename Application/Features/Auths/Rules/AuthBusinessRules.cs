using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null) throw new BusinessException("Mail Already exists");
        }

        public void IsEmailOrPasswordRegistered(User? user, UserForLoginDto userForLoginDto)
        {
            if (user == null) throw new BusinessException("Email not found");

            bool isVerified = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isVerified) throw new BusinessException("Wrong password");
        }

    }
}
