
using PlayTogether.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlayTogether.Infrastructure.Services.Account
{
    public interface ITokenManager
    {
        Task<bool> IsCurrentActiveTokenAsync();
        Task DeactivateCurrentAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);

    }
}
