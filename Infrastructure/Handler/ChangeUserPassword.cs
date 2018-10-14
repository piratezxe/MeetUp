using PlayTogether.Infrastructure.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class ChangeUserPassword : ICommandHandler<ChangePassword>
    {

        public Task HandlerAsync(ChangePassword command)
        {
            throw new NotImplementedException();
        }
    }
}
