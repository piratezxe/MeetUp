using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class Seeker
    {
        public Guid Id { get; protected set; }

        public Guid UserId { get; protected set; }

        public Adress Adress { get; protected set; }


    }
}
