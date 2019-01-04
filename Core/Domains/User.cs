using System;
using System.Collections.Generic;

namespace PlayTogether.Core.Domains
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string UserName { get; protected set; }

        public string Email { get; private set; }
        public string Password { get; set; }

        public string Salt { get; protected set;  }

        public IList<Guid> SavedMeetUp = new List<Guid>(); 

        public DateTime CreatedAt { get; protected set; }

        public string Role { get; protected set; }

        protected User()
        {

        }

        public User(Guid userId, string email, string password, string salt, string username, string role)
        {
            Role = role;
            Email = email.ToLowerInvariant();
            Password = password;
            Salt = salt;
            Id = userId;
            CreatedAt = DateTime.UtcNow;
            UserName = username;
        }
    }
}
