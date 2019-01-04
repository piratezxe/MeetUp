using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Repository.MeetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PlayTogether.Infrastructure.Services.Meetup
{
    [Authorize]
    public class MeetUpService : IMeetUpService
    {
        private readonly IMeetupRepository _meetupRepository;

        private readonly IUserRepository _userRepository;

        public MeetUpService(IMeetupRepository meetupRepository, IUserRepository userRepository)
        {
            _userRepository =userRepository; 
            _meetupRepository = meetupRepository;
        }
        public async Task CreateAsync(string title, Guid userId, DateTime deadlineTime, string location)
        {
            var user = await _userRepository.GetAsync(userId); 

            if(user == null)
            {
                throw new ArgumentException("User actualy exist");
            }

            await _meetupRepository.AddAsync(new Meet(title, deadlineTime, userId, new Adress(location)));
        }

        public async Task DeleteAsync(Guid meetId)
        {
            var meet = await _meetupRepository.GetMeetById(meetId);

            if(meet == null)
                throw new ArgumentNullException("Meet not exist");

            await _meetupRepository.DeleteAsync(meetId);
        }

        public async Task SignUpToTheEvent(Guid userId, Guid MetUpId)
        {
            var user = await _userRepository.GetAsync(userId);

            if (user == null)
            {
                throw new ArgumentNullException("User not exist");
            }

            var meetUp = await _meetupRepository.GetMeetById(MetUpId);

            if (MetUpId == null)
            {
                throw new ArgumentNullException("MeetUp not exist");
            }

            if (meetUp.MeetMember.Contains(user))
            {
                throw new ArgumentException("User actual exist in the event");
            }

            meetUp.MeetMember.Add(user);
            await _meetupRepository.UpdateAsync(meetUp);
        }
        public async Task SignOfFromEvent(Guid userId, Guid MetUpId)
        {
            var user = await _userRepository.GetAsync(userId);

            if (user == null)
            {
                throw new ArgumentNullException("User not exist");
            }

            var meetUp = await _meetupRepository.GetMeetById(MetUpId);

            if (MetUpId == null)
            {
                throw new ArgumentNullException("MeetUp not exist");
            }

            if (meetUp.MeetMember.All(x => x.Id != userId))
            {
                throw new ArgumentException("User not actual exist in the event");
            }

            var meetAssigment = meetUp.MeetMember.FirstOrDefault(x => x.Id == userId);
            meetUp.MeetMember.Remove(meetAssigment);
            await _meetupRepository.UpdateAsync(meetUp);
        }
    }
}
