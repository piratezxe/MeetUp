using System;
using Microsoft.AspNetCore.Mvc;
using PlayTogether.Api.Base;
using PlayTogether.Infrastructure.Commands;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using PlayTogether.Infrastructure.Commands.Meet;

namespace PlayTogether.Controllers
{
    [Authorize]
    public class MeetUpController : ApiControllerBase
    {
        public MeetUpController(ICommandDispatcher dispatcher): base(dispatcher)
        {
        }

        [HttpPost]
        [Route("CreateMeetUp")]
        public async Task<IActionResult>  CreateMeetUp([FromBody] CreateMeetUp meetUp )
        {
            await _commandDispatcher.DispatchAsync(meetUp);
            return Ok($"Created meetUp {meetUp.Title}");
        }
        [HttpPost]
        [Route("DeleteMeetUp")]
        public async Task<IActionResult> DeleteMeetUp([FromBody] DeleteMeetUp meetUp)
        {
            await _commandDispatcher.DispatchAsync(meetUp);
            return Ok($"Delete meetUp {meetUp.Id}");
        }
        [HttpPost]
        [Route("SignUpToMeetUp")]
        public async Task<IActionResult> SignUpToMeetUp([FromBody] SignUpToMeetUp meetUp)
        {
            await _commandDispatcher.DispatchAsync(meetUp);
            return Ok($"");
        }
        [HttpPost]
        [Route("SignOfFromMeetUp")]
        public async Task<IActionResult> SignOfFromMeetUp([FromBody] SignOfFromMeetUp meetUp)
        {
            await _commandDispatcher.DispatchAsync(meetUp);
            return Ok($"");
        }

        [HttpGet]
        public IActionResult GetCurrentUser()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Json(userId);
        }
    }
}