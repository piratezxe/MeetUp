using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.Account;

namespace PlayTogether.Infrastructure.Handler
{
    public class LogoutTokenHandler : ICommandHandler<Logout>
    {
        private readonly IAccountService _accountService;
        public LogoutTokenHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task HandlerAsync(Logout command)
        {
            await _accountService.RevokeTokenAsync(command.RefreshToken);
        }
    }
}
