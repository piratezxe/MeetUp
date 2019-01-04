using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Meet;
using PlayTogether.Infrastructure.Services.Meetup;

namespace PlayTogether.Infrastructure.Handler.Meet
{
    public class DeleteMeetUpHandler : ICommandHandler<DeleteMeetUp>
    {
        private readonly IMeetUpService _meetUpService;

        public DeleteMeetUpHandler(IMeetUpService meetUpService)
        {
            _meetUpService = meetUpService;
        }
        public async Task HandlerAsync(DeleteMeetUp command)
        {
            await _meetUpService.DeleteAsync(command.Id);
        }
    }
}
