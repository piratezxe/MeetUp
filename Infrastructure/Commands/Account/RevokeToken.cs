using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class RevokeToken : ICommands
    {
        public string Token { get; set; }
    }
}
