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
        private readonly IUserService _userContext;

        private readonly IJwthandler _jwthandler;

        private readonly IMemoryCache _memoryCache;

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService, IUserService UserContext, ICommandDispatcher _dispatcher, IJwthandler jwthandler, IMemoryCache memoryCache)
            : base(_dispatcher)
        {
            _accountService = accountService;
            _userContext = UserContext;
            _memoryCache = memoryCache;
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
        [Route("GetAuthorize")]
        [HttpGet]
        public async Task<IActionResult> GetAuthorize()
        {
            var token = _jwthandler.CreateToken("karol@gmail.com", "user");
            return Json(token);
        }

        [HttpPut]
        [Route("token")]
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
            var jwt = _memoryCache.Get<JsonWebToken>(token.Token);
            return Json(jwt);
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
