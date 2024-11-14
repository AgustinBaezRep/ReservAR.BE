using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;
using ReservAR.Domain.Common.Models;
using ReservAR.Infraestructure.Persistance;
using ReservAR.Infraestructure.Persistance.OutboxMessages;

namespace ReservAR.Infraestructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ProcessOutboxMessagesJob(ReservarDbContext dbContext, IPublisher publisher) : IJob
{
    private readonly ReservarDbContext _dbContext = dbContext;
    private readonly IPublisher _publisher = publisher;
    private readonly JsonSerializerSettings _jsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All,
        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    public async Task Execute(IJobExecutionContext context)
    {
        var messages = await _dbContext.Set<OutboxMessage>()
            .Where(w => w.ProcessedOnDateTime == null)
            .Take(20)
            .ToListAsync(context.CancellationToken);

        foreach (var outboxMessage in messages)
        {
            try
            {
                var domainEvent = JsonConvert
                    .DeserializeObject<IDomainEvent>(outboxMessage.Content,
                        _jsonSerializerSettings);

                if (domainEvent is null)
                    outboxMessage.Error = $"The domain event of the message is null.";
                else
                    await _publisher.Publish(domainEvent, context.CancellationToken);
            }
            catch (Exception ex)
            {
                outboxMessage.Error = $"Could not publish domain event. Exception message: {ex.Message}";
            }

            outboxMessage.ProcessedOnDateTime = DateTime.UtcNow;
        }

        if (messages.Count != 0)
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
