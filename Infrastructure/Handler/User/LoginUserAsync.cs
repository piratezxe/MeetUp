using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using PlayTogether.Core;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Dto;
using PlayTogether.Infrastructure.Services;
using PlayTogether.Infrastructure.Services.Account;
using PlayTogether.Infrastructure.Services.Jwt;
using PlayTogether.Infrastructure.Services.UserServices;

namespace PlayTogether.Infrastructure.Handler
{
    public class LoginUserAsync : ICommandHandler<LoginAsync>
    {
        private readonly IUserService _userService;

        private readonly IAccountService _accountService;

        private readonly IJwthandler _jwtHandler;

        private readonly IMemoryCache _memoryCache;


        public LoginUserAsync(IAccountService accountService, IUserService userService, IJwthandler jwtHandler, IMemoryCache memoryCache)
        {
            _accountService = accountService;
            _userService = userService;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }
        public async Task HandlerAsync(LoginAsync command)
        {
            await _accountService.LoginAsync(command.Password, command.Email);
            var user = await _userService.GetByEmailAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Email, "user");
            jwt.RefreshTokens = _jwtHandler.CreateRefreshToken(user.Email, "user");
            _memoryCache.Set(command.TokenId, jwt, TimeSpan.FromMinutes(1));

            //set refresh token to database 
            _memoryCache.Set<JsonWebToken>(jwt.RefreshTokens.Token, jwt);
        }
    }
}
