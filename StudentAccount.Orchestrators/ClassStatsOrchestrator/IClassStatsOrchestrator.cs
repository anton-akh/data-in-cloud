using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.ClassStats;
using StudentAccount.Platform.ServiceBus;

namespace StudentAccount.Orchestrators.ClassStatsOrchestrator;

public class ClassStatsOrchestrator : IClassStatsOrchestrator
{
    private readonly ISubscriber _subscriber;

    public ClassStatsOrchestrator(ISubscriber subscriber)
    {
        _subscriber = subscriber;
    }

    public async Task<List<string>> GetStatsAsync()
    {
        return _subscriber.Data;
    }
}