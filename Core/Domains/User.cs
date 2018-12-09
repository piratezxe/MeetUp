using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string FullName { get; protected set; }

        public string UserName { get; protected set; }

        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public string Salt { get; protected set;  }


        public DateTime CreatedAt { get; protected set; }

        public bool Activity { get; protected set; }

        public DateTime LastActivity { get; protected set; }

        protected User()
        {

        }
        public User(string email, string password, string salt, string username)
        {
            Email = email.ToLowerInvariant();
            Password = password;
            Salt = salt;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UserName = username;
        }
    }
}
