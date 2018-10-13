using PlayTogether.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Core.Repository
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task<User> GetAsync(Guid userId);

        Task<User> GetAsyncByEmail(string email);

        Task RemoveAsync(Guid userId);

        Task UpdateAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();
    }
}
