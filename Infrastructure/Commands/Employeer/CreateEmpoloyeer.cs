using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Employeer
{
    public class CreateEmpoloyeer : ICommands
    {
        public Guid UserId { get; set; }
    }
}
