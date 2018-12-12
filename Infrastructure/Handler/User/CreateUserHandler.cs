using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Services.UserServices;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Handler
{
    public class CreateUserHandler : ICommandHandler<CreateUsers>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandlerAsync(CreateUsers command)
        {
            await _userService.RegisterUserAsync(command.UserId, command.Email, command.Password, command.UserName);
        }
    }
}
