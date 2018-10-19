using AutoMapper;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Repository;

namespace PlayTogether.Infrastructure.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;

        private readonly IMapper _mapper;

        private readonly IEncrypter _encrypter;

        public UserService(IUserRepository userRepo, IMapper mapper, IEncrypter encrypter)
        {
            _mapper = mapper;
            _encrypter = encrypter;
            _user = userRepo;
        }

        public async Task<IEnumerable<User>> GetAlAsync()
        {
            return await _user.GetAllAsync();
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _user.GetAsyncByEmail(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string password, string email)
        {
            var user = await _user.GetAsyncByEmail(email);
            if (user == null)
            {
                throw new  ArgumentNullException($"User with {email} not exist");
            }

            var hash = _encrypter.GetHash(user.Salt, password);

            if (user.Password == hash)
                return;

            throw new ArgumentException($"Password: {password} is invalid");
        }

        public async Task ChangePasswordAsync(string currentPassword, string newPassword)
        {
            await Task.CompletedTask;
        }

        public async Task RegisterUserAsync(string email, string password, string username)
        {
            var user = await _user.GetAsyncByEmail(email);
            Console.WriteLine(user);
            if (user != null)
            {
                throw new ArgumentException("User already exist");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(salt, password);
            user = new User(email, hash, salt, username);
            await _user.AddAsync(user);
        }
    }
}
