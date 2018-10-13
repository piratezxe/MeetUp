using System;
using System.Collections.Generic;
using System.Text;

namespace PlayTogether.Core.Domains
{
    public class Notification
    {
        public Guid Id { get; protected set; }

        public Guid JobId { get; protected set; }

        public string NotificationStatus { get; private set; }

        public DateTime CreatedTime { get; private set; }

        public enum Status
        {
            Pending,
            rejected,
            Accepted
        }

        public Notification()
        {
            NotificationStatus =  Status.Pending.ToString();
            JobId = new Guid();
            CreatedTime = DateTime.UtcNow;
        }
    }
}
