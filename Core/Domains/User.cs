using System;

namespace PlayTogether.Core.Domains
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string FullName { get; protected set; }

        public string UserName { get; protected set; }

        public string Email { get;  set; }
        public string Password { get; set; }

        public string Salt { get; protected set;  }

        public DateTime CreatedAt { get; protected set; }

        public bool Activity { get; protected set; }

        public  string Role { get; protected set; }

        public DateTime LastActivity { get; protected set; }

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
