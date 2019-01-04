using PlayTogether.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Repository.MeetUp
{
    public interface IMeetupRepository : IRepository
    {
        Task AddAsync(Meet meetUp);
        Task<IEnumerable<Meet>> BrowseAsync();
        Task DeleteAsync(Guid Id);
        Task UpdateAsync(Meet meetup);
        Task<Meet> GetMeetById(Guid meetupId);
        Task<IEnumerable<Meet>> GetUserMeetUp(string email);
    }
}
