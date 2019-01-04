using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Meet;
using PlayTogether.Infrastructure.Services.Meetup;

namespace PlayTogether.Infrastructure.Handler.Meet
{
    public class SingOfFromMeetUpHandler : ICommandHandler<SignOfFromMeetUp>
    {
        private readonly IMeetUpService _meetUpService;

        public SingOfFromMeetUpHandler(IMeetUpService meetUpService)
        {
            _meetUpService = meetUpService;
        }

        public async Task HandlerAsync(SignOfFromMeetUp command)
        {
            await _meetUpService.SignOfFromEvent(command.UserId, command.MeetUpId);
        }
    }
}
