using Microsoft.Extensions.Caching.Memory;
using PlayTogether.Core;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Repository;
using PlayTogether.Infrastructure.Services.Jwt;
using System;
using System.Threading.Tasks;
using PlayTogether.Infrastructure.Repository.Token;

namespace PlayTogether.Infrastructure.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepo;

        private readonly IEncrypter _encrypter;

        private readonly IJwthandler _jwthandler;

        private readonly ITokenRepository _repository;

        public AccountService(IJwthandler jwthandler, IUserRepository userRepo, IEncrypter encrypter, ITokenRepository repository)
        {
            _repository = repository;
            _jwthandler = jwthandler;
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

        public async Task<JsonWebToken> RefreshAccessTokenAsync(string token)
        {
            var refreshToken = await _repository.GetAsync(token);

            if(refreshToken == null)
            {
                throw new ArgumentNullException("Refresh Token is not exist");
            }

            if(refreshToken.Revoked)
            {
                throw new ArgumentException("Refresh token is revoke");
            }
            var user = await _userRepo.GetAsync(refreshToken.UserId);

            var jwt  = _jwthandler.CreateToken(user.Email, user.Role);
            jwt.RefreshTokens = refreshToken;

            return jwt;
        }

        public async Task RevokeTokenAsync(string token)
        {
            var refreshToken = await _repository.GetAsync(token);
            if (refreshToken.Token == null)
            {
                throw new Exception("Refresh token was not found.");
            }
            if (refreshToken.Revoked)
            {
                throw new Exception("Refresh token was already revoked.");
            }
            refreshToken.Revoke();
            await _repository.UpdateAsync(refreshToken);
        }
    }
}
