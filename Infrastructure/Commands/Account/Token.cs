using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class Token : ICommands
    {
        public string token { get; set; }
    }
}
