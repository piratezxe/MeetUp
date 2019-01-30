using System;

namespace PlayTogether.Infrastructure.Commands.Meet
{
    public class CreateMeetUp : ICommands
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime Time { get; set; }
    }
}
