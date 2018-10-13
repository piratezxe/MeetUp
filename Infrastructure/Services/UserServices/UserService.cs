using AutoMapper;
using PlayTogether.Core.Domains;
using PlayTogether.Core.Repository;
using PlayTogether.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _user;

        private readonly IMapper _mapper;


        public UserService(IUserRepository userRepo, IMapper mapper)
        {
            _mapper = mapper;
            _user = userRepo;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _user.GetAllAsync();
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _user.GetAsyncByEmail(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterUserAsync(string email, string password, string username)
        {
            var user = await _user.GetAsyncByEmail(email);
            Console.WriteLine(user);
            if (user != null)
            {
                throw new ArgumentException("User already exist");
            }
            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);
            await _user.AddAsync(user);
        }
    }
}
