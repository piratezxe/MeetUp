using System;
using System.Collections.Generic;
using System.Text;
using PlayTogether.Core.Domains;

namespace PlayTogether.Core
{
    public class JsonWebToken
    {
        public Guid TokenId { get; set; }
        public string AccessToken { get; set; }
        public RefreshToken RefreshTokens { get; set; }
        public long Expires { get; set; }

        public JsonWebToken()
        {
            TokenId = new Guid();
        }     
    }
}
