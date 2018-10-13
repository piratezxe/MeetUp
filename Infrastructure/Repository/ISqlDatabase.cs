using PlayTogether.Core.Domains;
using PlayTogether.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Repository
{
    public class SqlDatabase : IUserRepository
    {
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsyncByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
