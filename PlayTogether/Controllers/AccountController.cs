using Microsoft.AspNetCore.Mvc;
using PlayTogether.Api.Base;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayTogether.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userContext;

        public AccountController(IUserService UserContext, ICommandDispatcher _dispatcher)
            : base(_dispatcher)
        {
            _userContext = UserContext;
        }

        // POST api/values
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword password)
        {
            await _commandDispatcher.DispatchAsync(password);
            return NoContent();
        }
    }
}
