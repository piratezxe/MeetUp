using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using PlayTogether.Api.Base;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Repository.MeetUp;

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

        [HttpGet]
        public IEnumerable<Meet> GetSavedMeetUp()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _meetupRepository.GetUserMeetUp(userId).Result;
        }
    }
}