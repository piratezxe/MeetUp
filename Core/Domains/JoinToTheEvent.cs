using System;

namespace Core.Domains
{
    public class JoinToTheEvent
    {
        public Guid Id {get; set;}
        public Guid UserId {get; set;}

        public Guid MeetUpId {get; set;}

        public DateTime JoinDateTime {get;set;}

        public JoinToTheEvent(Guid _UserId, Guid _MeetUpId)
        {
            Id = Guid.NewGuid();
            UserId = _UserId;
            MeetUpId = _MeetUpId;
            JoinDateTime = DateTime.UtcNow;
        }
    }
}