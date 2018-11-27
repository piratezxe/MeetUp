using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper.Execution;

namespace PlayTogether.Infrastructure.Commands.Account
{
    public class LoginAsync : ICommands
    {
        public Guid TokenId { get; set; }
        public string Email { get; set; }
        public  string Password { get; set; }
    }
}
