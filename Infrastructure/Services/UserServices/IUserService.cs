using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.UserServices
{
    public interface IUserService
    {
        Task RegisterUserAsync(string email, string password, string username);

        Task<IEnumerable<User>> GetAllAsync();

        Task<UserDto> GetByEmailAsync(string email);
    }
}
