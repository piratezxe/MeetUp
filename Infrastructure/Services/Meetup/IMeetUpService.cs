using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.Meetup
{
    public interface IMeetUpService : IService
    {
        Task CreateAsync(string title, Guid userId, DateTime deadlineTime, string location);
        Task DeleteAsync(Guid meetId);
        Task SignOfFromEvent(Guid userId, Guid MetUpId);
        Task SignUpToTheEvent(Guid userId, Guid MetUpId);
    }
}
