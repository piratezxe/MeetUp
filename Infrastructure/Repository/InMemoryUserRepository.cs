using PlayTogether.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Repository
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>()
        {
            new User("karol@gmail.com", "123123123", "123", "ktos"),
            new User("mateusz@gmail.com", "234234234", "234",  "ktos1"),
            new User("szymon@gmail.com", "345345345", "345",  "ktos2")
        };

        public async Task AddAsync(User user)
        {
             _users.Add(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
            =>  _users;

        public async Task<User> GetAsync(Guid userId)
            => await Task.FromResult(_users.Single(x => x.Id == userId));

        public async Task<User> GetAsyncByEmail(string email)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));
        }

        public async Task RemoveAsync(Guid userId)
        {
            var user = await GetAsync(userId);
            _users.Remove(user);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
        
    }
}
