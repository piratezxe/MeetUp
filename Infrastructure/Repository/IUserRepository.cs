using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Repository
{
    public interface IUserRepository : IRepository
    {
        Task AddAsync(User user);

        Task<User> GetAsync(Guid userId);

        Task<User> GetAsyncByEmail(string email);

        Task RemoveAsync(Guid userId);

        Task UpdateAsync(User user);

        Task<IEnumerable<User>> GetAllAsync();
    }
}
