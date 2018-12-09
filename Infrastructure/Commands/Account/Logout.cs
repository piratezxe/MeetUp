using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class Logout : ICommands
    {
        public string RefreshToken { get; set; }
    }
}
