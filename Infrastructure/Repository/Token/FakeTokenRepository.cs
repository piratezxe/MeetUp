using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Core;
using PlayTogether.Core.Domains;

namespace PlayTogether.Infrastructure.Repository.Token
{
    public class fakeTokenRepository : ITokenRepository
    {
        public static ISet<RefreshToken> _Tokens =  new HashSet<RefreshToken>
        {
        };

        public async Task AddToken(RefreshToken token)
        {
            await Task.FromResult(_Tokens.Add(token));
        }

        public async Task<RefreshToken> GetAsync(string token)
            => await Task.FromResult(_Tokens.Single(x => x.Token == token));


        public Task RemoveToken(Guid TokenId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(RefreshToken token)
        {
            throw new NotImplementedException();
        }
    }
}
