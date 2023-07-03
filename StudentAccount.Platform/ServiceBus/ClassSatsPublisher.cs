using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace StudentAccount.Platform.ServiceBus;

public class ClassSatsPublisher : IPublisher
{
    private readonly ServiceBusClient _client;
    protected virtual string QueueName => "course-stats";
    private readonly ServiceBusSender _publisher;

    public ClassSatsPublisher(ServiceBusClient client)
    {
        _client = client;
        _publisher = _client.CreateSender(QueueName);
    }

    public async Task PublishAsync(Guid guid)
    {
        await _publisher.SendMessageAsync(new ServiceBusMessage(guid.ToString("N")));
    }
}