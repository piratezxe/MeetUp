using System;
using System.Collections.Generic;
using System.Text;
using Core.Domains;

namespace PlayTogether.Core.Domains
{
    public class Meet
    {
        public Guid Id { get; private set; }

        public string Title { get; protected set; }

        public DateTime CreatedTime { get; set; }

        public DateTime UpdatedTime { get; private set; }

        public DateTime DeadLine { get; private set; }

        public ISet<JoinToTheEvent> MeetMember = new HashSet<JoinToTheEvent>();

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
