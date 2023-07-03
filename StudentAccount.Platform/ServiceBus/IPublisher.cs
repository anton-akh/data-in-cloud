using System;
using System.Threading.Tasks;

namespace StudentAccount.Platform.ServiceBus;

public interface IPublisher
{
    Task PublishAsync(Guid guid);
}