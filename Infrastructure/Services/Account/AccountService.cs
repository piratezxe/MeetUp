using Microsoft.Extensions.Caching.Memory;
using PlayTogether.Core;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Services.Jwt;
using System;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepo;

        private readonly IEncrypter _encrypter;

        private readonly IJwthandler _jwthandler;

        private readonly IMemoryCache _cache;

        public AccountService(IJwthandler jwthandler, IUserRepository userRepo, IEncrypter encrypter, IMemoryCache cache)
        {
            _jwthandler = jwthandler;
            _cache = cache;
            _encrypter = encrypter;
            _userRepo = userRepo;
        }

        public async Task LoginAsync(string password, string email)
        {
            var user = await _userRepo.GetAsyncByEmail(email);
            if (user == null)
            {
                throw new ArgumentNullException($"User with {email} not exist");
            }

            var hash = _encrypter.GetHash(user.Salt, password);

            if (user.Password == hash)
                return;

            throw new ArgumentException($"Password: {password} is invalid");
        }

        public JsonWebToken RefreshAccessToken(string token)
        {
            var acessToken =_cache.Get<JsonWebToken>(token);

            if(acessToken.RefreshTokens == null)
            {
                throw new ArgumentNullException("Refresh Token is not exist");
            }

            if(acessToken.RefreshTokens.Revoked)
            {
                throw new ArgumentException("Refresh token is revoke");
            }

            var new_token  = _jwthandler.CreateToken(acessToken.RefreshTokens.Email, acessToken.RefreshTokens.Role);
            new_token.RefreshTokens = acessToken.RefreshTokens;

            return new_token;
        }

        public async Task RevokeTokenAsync(string token)
        {
            var acessToken = _cache.Get<JsonWebToken>(token);
            if (acessToken.RefreshTokens.Token == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if (acessToken.RefreshTokens.Revoked)
            {
                throw new Exception("Refresh token was already revoked.");
            }
            acessToken.RefreshTokens.Revoked = true;
            await Task.CompletedTask;
        }
    }
}
