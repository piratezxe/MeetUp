using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Meet
{
    public class DeleteMeetUp : ICommands
    {
        public Guid Id { get; set; }
    }
}
