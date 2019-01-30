using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PlayTogether.Api.Base;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Repository.MeetUp;
using Core.Domains;
using Microsoft.AspNetCore.Mvc;

namespace PlayTogether.Api.Controllers
{
    [ApiController]
    public class MemberController : ApiControllerBase
    {
        private readonly IMeetupRepository _meetupRepository;

        public MemberController(IMeetupRepository meetupRepository, ICommandDispatcher _dispatcher) : base(_dispatcher)
        {
            _meetupRepository = meetupRepository;
        }

        [HttpGet("{GuidUserID}")]
        public async  Task<IEnumerable<JoinToTheEvent>> GetSavedMeetUp(Guid GuidUserID)
            =>  await _meetupRepository.GetUserMeetUp(GuidUserID);
    }
}