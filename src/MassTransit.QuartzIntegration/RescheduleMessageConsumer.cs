namespace MassTransit.QuartzIntegration
{
    using Quartz;
    using Scheduling;


    public class RescheduleMessageConsumer : Consumes<RescheduleMessage>.Context
    {
        readonly IScheduler _scheduler;

        public RescheduleMessageConsumer(IScheduler scheduler)
        {
            _scheduler = scheduler;
        }

        public void Consume(IConsumeContext<RescheduleMessage> context)
        {
            ITrigger trigger = TriggerBuilder.Create()
                .ForJob(context.Message.TokenId.ToString("N"))
                .StartAt(context.Message.ScheduledTime)
                .WithIdentity(new TriggerKey(context.Message.TokenId.ToString("N")))
                .Build();

            _scheduler.RescheduleJob(trigger.Key, trigger);
        }
    }
}