using Microsoft.AspNetCore.Mvc;
using PlayTogether.Api.Base;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.UserServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PlayTogether.Infrastructure.Services.Jwt;

namespace PlayTogether.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userContext;

        private readonly IJwthandler _jwthandler;

        public AccountController(IUserService UserContext, ICommandDispatcher _dispatcher, IJwthandler jwthandler)
            : base(_dispatcher)
        {
            _userContext = UserContext;
            _jwthandler = jwthandler;
        }

        // POST api/values
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword password)
        {
            await _commandDispatcher.DispatchAsync(password);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var token = _jwthandler.CreateToken("karol@gmail.com", "user");
            return Json(token);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAuthorize()
        {
            var token = _jwthandler.CreateToken("karol@gmail.com", "user");
            return Json(token);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginAsync login)
        {
            await _commandDispatcher.DispatchAsync(login);
            return NoContent();
        }
    }
}
