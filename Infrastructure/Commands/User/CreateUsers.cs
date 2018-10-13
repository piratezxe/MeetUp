using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.User
{
    public class CreateUsers : ICommands
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}
