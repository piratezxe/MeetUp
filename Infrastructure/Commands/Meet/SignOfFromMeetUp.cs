﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Commands.Meet
{
    public class SignOfFromMeetUp : ICommands
    {
        public Guid MeetUpId { get; set; }
        public Guid UserId { get; set; }
    }
}
