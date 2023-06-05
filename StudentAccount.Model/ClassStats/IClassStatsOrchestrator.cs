using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Model.ClassStats;

public interface IClassStatsOrchestrator
{
    Task<List<string>> GetStatsAsync();
}