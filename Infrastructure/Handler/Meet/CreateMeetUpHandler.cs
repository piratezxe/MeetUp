using System.Threading.Tasks;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Employeer;
using PlayTogether.Infrastructure.Services.Meetup;

namespace Infrastructure.Handler.Meet
{
    public class CreateMeetUpHandler : ICommandHandler<CreateMeetUp>
    {
        private readonly IMeetUpService _meetUpService;
        public CreateMeetUpHandler(IMeetUpService meetUpService)
        {
            _meetUpService = meetUpService;
        }
        public async Task HandlerAsync(CreateMeetUp command)
        {
            await _meetUpService.CreateAsync(command.Title,command.UserId, command.Time, command.Location);
        }
    }
}