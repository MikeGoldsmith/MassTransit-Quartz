namespace MassTransit.Scheduling
{
    using System;

    public interface RescheduleMessage :
        CorrelatedBy<Guid>
    {
        /// <summary>
        /// The time at which the message should be published
        /// </summary>
        DateTime ScheduledTime { get; }

        /// <summary>
        /// The token of the scheduled message
        /// </summary>
        Guid TokenId { get; }
    }
}