using System;
using System.Collections.Generic;
using System.Text;
using PlayTogether.Core;
using PlayTogether.Core.Domains;
using PlayTogether.Infrastructure.Dto;
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether.Infrastructure.Services.Jwt
{
    public interface IJwthandler
    {
        RefreshToken CreateRefreshToken(string email, string role);
        JsonWebToken CreateToken(string email, string role);
    }
}
