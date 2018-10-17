using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Execution;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class LoginAsync : ICommands
    {
        public  string Email { get; set; }
        public  string Password { get; set; }
    }
}
