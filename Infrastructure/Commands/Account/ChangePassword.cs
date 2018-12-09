using System;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class ChangePassword : ICommands
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string Email { get; set; } 
    }
}