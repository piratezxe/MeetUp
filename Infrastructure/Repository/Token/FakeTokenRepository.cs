using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PlayTogether.Core;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Repository.Token
{
    public class fakeTokenRepository : ITokenRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public fakeTokenRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }
        public async Task AddToken(RefreshToken token)
        {
             await refreshTokens.InsertOneAsync(token);
        }

        public async Task<RefreshToken> GetAsync(string token)
            => await refreshTokens.AsQueryable().FirstOrDefaultAsync(x => x.Token == token);

        public async Task RemoveToken(Guid TokenId)
        {
            await refreshTokens.DeleteOneAsync(x => x.Id == TokenId);
        }

        public async Task UpdateAsync(RefreshToken token)
        {
            await refreshTokens.ReplaceOneAsync(x => x.Id == token.Id, token);
        }

        private IMongoCollection<RefreshToken> refreshTokens => _mongoDatabase.GetCollection<RefreshToken>("RefreshTokens");
    }
}
