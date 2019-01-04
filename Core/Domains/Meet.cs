using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class Meet
    {
        public Guid Id { get; private set; }

        public string Title { get; protected set; }

        public DateTime CreatedTime { get; }

        public DateTime UpdatedTime { get; private set; }

        public DateTime DeadLine { get; private set; }

        public ISet<User> MeetMember = new HashSet<User>();

        public Guid FounderId  { get; private set; }

        public Adress Adress { get; private set; }
        public Meet(string title, DateTime deadline, Guid founderId, Adress adress)
        {
            Title = title;
            Id = new Guid();
            DeadLine = deadline;
            FounderId = founderId;
            Adress = adress;
            CreatedTime = DateTime.UtcNow;
            UpdatedTime = CreatedTime;
        }

    }
}
