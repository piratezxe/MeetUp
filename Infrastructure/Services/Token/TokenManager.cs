using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using PlayTogether.Core;
using PlayTogether.Infrastructure.Services.Jwt;
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether.Infrastructure.Services.Account
{
    public class AccountToken : ITokenManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IDistributedCache _distributedCache;

        private readonly JwtSettings _jwtSettings;

        public AccountToken(IDistributedCache distributedCache, IHttpContextAccessor httpContextAccessor, JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
            _distributedCache = distributedCache;
            _httpContextAccessor = httpContextAccessor;
        }

        private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccessor
                .HttpContext.Request.Headers["authorization"];

            return authorizationHeader == string.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(' ').Last();
        }

        public async Task<bool> IsCurrentActiveTokenAsync()
             => await IsActiveAsync(GetCurrentAsync());


        public async Task DeactivateCurrentAsync()
        {
            await DeactivateAsync(GetCurrentAsync());
        }

        public async Task<bool> IsActiveAsync(string token)
            => await _distributedCache.GetStringAsync(token) == null;

        public async Task DeactivateAsync(string token)
            => await _distributedCache.SetStringAsync(token, " " , 
                new DistributedCacheEntryOptions {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_jwtSettings.Time)
                });
    }
}

