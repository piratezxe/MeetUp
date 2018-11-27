using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class RefreshToken
    {
        public string Email { get; set; }

        public string Role {get;set;}

		public string Token { get; set; }

		public bool Revoked { get; set; }
    }
}
