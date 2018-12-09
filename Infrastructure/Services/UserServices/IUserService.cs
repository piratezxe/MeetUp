using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.UserServices
{
    public interface IUserService : IService
    {
<<<<<<< HEAD
        Task RegisterUserAsync(string email, string password, string username);
=======
        Task RegisterUserAsync(Guid userId, string email, string password, string username);
>>>>>>> IocRepair-

        Task<IEnumerable<User>> GetAlAsync();

        Task<UserDto> GetByEmailAsync(string email);

<<<<<<< HEAD
        Task LoginAsync(string password, string email);

        Task ChangePasswordAsync(string currentPassword, string newPassword);
=======
        Task ChangePasswordAsync(string currentPassword, string newPassword, string email);
>>>>>>> IocRepair-
    }
}
