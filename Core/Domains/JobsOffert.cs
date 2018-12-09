using System;

namespace PlayTogether.Core.Domains
{
    public class Job
    {
        public Benefits beneftis { get; protected set; }

        public Guid Id { get; protected set; }

        public DateTime CreationDate { get; protected set; }

        public decimal MoneyPerHours { get; protected set; }

        public Adress RealizedLocation { get; protected set; }

        public DateTime StartTime { get; protected set; }

        public float AmountOfTime { get; protected set; }

        public bool Activity { get; protected set; }

        public DateTime LastUpdate { get; protected set; }

        public Job(decimal moneyPerHours, Adress realizedLocation, DateTime startTime, float amountOfTime)
        {
            MoneyPerHours = moneyPerHours;
            RealizedLocation = realizedLocation;
            StartTime = startTime;
            AmountOfTime = amountOfTime;
            Activity = true;
            Id = new Guid();
            CreationDate = DateTime.UtcNow;
        }
    }
}