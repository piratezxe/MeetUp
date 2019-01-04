using System;
using Microsoft.AspNetCore.Mvc;
using PlayTogether.Api.Base;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Services.UserServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using PlayTogether.Infrastructure.Dto;
using PlayTogether.Infrastructure.Services.Jwt;
using System.Linq;
using PlayTogether.Core;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Services.Account;

namespace PlayTogether.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {

        private readonly IMemoryCache _memoryCache;

        public AccountController(ICommandDispatcher _dispatcher, IMemoryCache memoryCache)
            : base(_dispatcher)
        {
            _memoryCache = memoryCache;
        }

        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePassword password)
        {
            await _commandDispatcher.DispatchAsync(password);
            return NoContent();
        }
        [HttpPut]
        [Route("refresh")]
        public async Task<IActionResult> RefreshToken([FromBody]Token token)
        {
            await _commandDispatcher.DispatchAsync(token);
            var jwt = _memoryCache.Get<JsonWebToken>(token.token);
            return Json(jwt);
        }
        [HttpPut]
        [Route("revoke")]
        public async Task<IActionResult> RevokeToken([FromBody]RevokeToken token)
        {
            await _commandDispatcher.DispatchAsync(token);
            return Ok(null);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginAsync login)
        {
            login.TokenId = Guid.NewGuid();
            await _commandDispatcher.DispatchAsync(login);
            var jwt = _memoryCache.Get<JsonWebToken>(login.TokenId);
            return Json(jwt);
        }

    }
}
