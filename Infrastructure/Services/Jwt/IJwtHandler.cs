using System;
using System.Collections.Generic;
using System.Text;
using PlayTogether.Infrastructure.Dto;
using PlayTogether.Infrastructure.Settings;

namespace PlayTogether.Infrastructure.Services.Jwt
{
    public interface IJwthandler
    {
        JwtDto CreateToken(string email, string role);
    }
}
