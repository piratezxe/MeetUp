using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PlayTogether.Core;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.Account;
using PlayTogether.Infrastructure.Services.Jwt;

namespace PlayTogether.Infrastructure.Handler
{
    public class RefreshTokenHandler : ICommandHandler<Token>
    {
        private readonly IJwthandler _jwtHandler;

        private readonly IAccountService _accountService;

        private readonly IMemoryCache _memoryCache;


        public RefreshTokenHandler(IJwthandler jwtHandler, IAccountService accountService, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _jwtHandler = jwtHandler;
            _accountService = accountService;
        }

        public async Task HandlerAsync(Token command)
        {
            var jwt = await  _accountService.RefreshAccessTokenAsync(command.token);
            _memoryCache.Set<JsonWebToken>(jwt, jwt);
            await Task.CompletedTask;
        }
    }
}
