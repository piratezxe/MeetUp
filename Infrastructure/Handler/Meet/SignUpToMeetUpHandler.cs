using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Meet;
using PlayTogether.Infrastructure.Services.Meetup;

namespace PlayTogether.Infrastructure.Handler.Meet
{
    public class SignUpToMeetUpHandler : ICommandHandler<SignUpToMeetUp>
    {
        private readonly IMeetUpService _meetUpService;
        public SignUpToMeetUpHandler(IMeetUpService meetUpService)
        {
            _meetUpService = meetUpService;
        }
        public async Task HandlerAsync(SignUpToMeetUp command)
        {
            await _meetUpService.SignUpToTheEvent(command.UserId, command.MeetUpId);
        }
    }
}
