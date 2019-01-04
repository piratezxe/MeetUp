using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Employeer
{
    public class CreateMeetUp : ICommands
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime Time { get; set; }
    }
}
