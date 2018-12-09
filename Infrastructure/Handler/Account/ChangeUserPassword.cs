using System;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services;
using PlayTogether.Infrastructure.Services.UserServices;

namespace PlayTogether.Infrastructure.Handler
{
    public class ChangeUserPassword : ICommandHandler<ChangePassword>
    {
        private readonly IUserService _userService;


        public ChangeUserPassword(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandlerAsync(ChangePassword command)
        {
            await _userService.ChangePasswordAsync(command.CurrentPassword,command.NewPassword,command.Email);

        }
    }
}
