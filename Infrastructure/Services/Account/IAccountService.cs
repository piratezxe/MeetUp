using PlayTogether.Core;
using PlayTogether.Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.Account
{
    public interface IAccountService : IService
    {
        JsonWebToken RefreshAccessToken(string token);
        Task LoginAsync(string password, string email);
        Task RevokeTokenAsync(string token);
    }
}
