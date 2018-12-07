using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Commands;
using PlayTogether.Infrastructure.Commands.Account;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Repository.Token;
using PlayTogether.Infrastructure.Services.Account;
using PlayTogether.Infrastructure.Services.Jwt;
using PlayTogether.Infrastructure.Services.UserServices;

namespace PlayTogether.Infrastructure.Handler
{
    public class LoginUserAsync : ICommandHandler<LoginAsync>
    {

        private readonly IUserRepository _userRepository;

        private readonly IJwthandler _jwtHandler;

        private readonly IMemoryCache _memoryCache;

        private readonly IAccountService _accountService;

        private readonly IPasswordHasher<User> _passwordHasher;

        private readonly ITokenRepository _tokenRepository;


        public LoginUserAsync(IUserRepository userRepository,IAccountService accountService, 
            IJwthandler jwtHandler, IMemoryCache memoryCache, IPasswordHasher<User> passwordHasher, ITokenRepository tokenRepository)
        {
            _accountService = accountService;
            _tokenRepository = tokenRepository;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _memoryCache = memoryCache;
        }
        public async Task HandlerAsync(LoginAsync command)
        {
            await _accountService.LoginAsync(command.Password, command.Email);

            var user = await _userRepository.GetAsyncByEmail(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Email, "user");

            var refreshToken = new RefreshToken(user, _passwordHasher);
            jwt.RefreshTokens = refreshToken;
            await _tokenRepository.AddToken(refreshToken);

            _memoryCache.Set(command.TokenId, jwt, TimeSpan.FromMinutes(1));

        }
    }
}
