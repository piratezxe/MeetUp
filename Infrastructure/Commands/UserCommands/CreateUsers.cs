using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands
{
    public class CreateUsers : ICommands
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}
