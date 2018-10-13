using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class Employer
    {
        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public IEnumerable<Job> JobsOffert { get; protected set; }

        public IEnumerable<Comments> Comments { get; protected set; }

        public Employer(Guid userId)
        {
            Id = new Guid();
            UserId = userId;
        }   
    }
}
