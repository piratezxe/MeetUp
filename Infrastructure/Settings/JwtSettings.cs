using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Issuer { get; set; }
        public int Time { get; set; }
        public string Key { get; set; }

    }
}

