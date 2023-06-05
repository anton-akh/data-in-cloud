using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace StudentAccount.Platform.ServiceBus;

public class ClassStatsSubscriber : ISubscriber
{
    private readonly ServiceBusClient _client;
    private ServiceBusProcessor _subscriber;
    protected virtual string QueueName => "course-stats";
    private List<string> _guids = new List<string>();

    public List<string> Data => _guids;

    public ClassStatsSubscriber(
        ServiceBusClient client)
    {
        _client = client;
    }

    protected virtual async System.Threading.Tasks.Task ProcessAsync(ProcessMessageEventArgs arg)
    {
        _guids.Add(arg.Message.Body.ToString());

        await arg.CompleteMessageAsync(arg.Message);
    }

    public async Task SubscribeAsync()
    {
        _subscriber = _client.CreateProcessor(QueueName);

        _subscriber.ProcessMessageAsync += ProcessAsync;
        _subscriber.ProcessErrorAsync += HandleErrorAsync;
        
        await _subscriber.StartProcessingAsync();
    }

    private async Task HandleErrorAsync(ProcessErrorEventArgs arg)
    {
        Console.WriteLine($"Error: {arg.Exception.Message}");
    }
}