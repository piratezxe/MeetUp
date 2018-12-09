using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Text;
=======
>>>>>>> IocRepair-

namespace PlayTogether.Core.Domains
{
    public class User
    {
        public Guid Id { get; protected set; }

        public string FullName { get; protected set; }

        public string UserName { get; protected set; }

<<<<<<< HEAD
        public string Email { get; protected set; }
        public string Password { get; protected set; }

        public string Salt { get; protected set;  }


=======
        public string Email { get;  set; }
        public string Password { get; set; }

        public string Salt { get; protected set;  }

>>>>>>> IocRepair-
        public DateTime CreatedAt { get; protected set; }

        public bool Activity { get; protected set; }

<<<<<<< HEAD
=======
        public  string Role { get; protected set; }

>>>>>>> IocRepair-
        public DateTime LastActivity { get; protected set; }

        protected User()
        {

        }
<<<<<<< HEAD
        public User(string email, string password, string salt, string username)
        {
            Email = email.ToLowerInvariant();
            Password = password;
            Salt = salt;
            Id = Guid.NewGuid();
=======
        public User(Guid userId, string email, string password, string salt, string username, string role)
        {
            Role = role;
            Email = email.ToLowerInvariant();
            Password = password;
            Salt = salt;
            Id = userId;
>>>>>>> IocRepair-
            CreatedAt = DateTime.UtcNow;
            UserName = username;
        }
    }
}
