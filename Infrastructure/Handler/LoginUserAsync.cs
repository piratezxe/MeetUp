using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services;
using PlayTogether.Infrastructure.Services.UserServices;

namespace PlayTogether.Infrastructure.Handler
{
    public class LoginUserAsync : ICommandHandler<LoginAsync>
    {
        private readonly IUserService _userService;

        public LoginUserAsync(IUserService userService)
        {
            _userService = userService;
        }
        public async Task HandlerAsync(LoginAsync command)
        {
            await _userService.LoginAsync(command.Password, command.Email);
        }
    }
}
