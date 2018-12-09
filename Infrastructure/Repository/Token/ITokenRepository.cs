using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Core;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Repository.Token
{
    public interface ITokenRepository :  IMongoRepository
    {
        Task AddToken(RefreshToken token);
        Task RemoveToken(Guid TokenId);
        Task<RefreshToken> GetAsync(string token);
        Task UpdateAsync(RefreshToken token);
    }
}
