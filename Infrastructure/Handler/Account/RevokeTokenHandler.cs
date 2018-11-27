using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.Account;

namespace PlayTogether.Infrastructure.Handler
{
    public class RevokeTokenHandler : ICommandHandler<RevokeToken>
    {
        private readonly IAccountService _accountService;

        public RevokeTokenHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public async Task HandlerAsync(RevokeToken command)
        {
             await _accountService.RevokeTokenAsync(command.Token);
        }
    }
}
