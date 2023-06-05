using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Platform.ServiceBus;

public interface ISubscriber
{
    Task SubscribeAsync();
    public List<string> Data { get; }
}