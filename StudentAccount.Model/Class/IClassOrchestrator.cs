using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Model.Class;

public interface IClassOrchestrator
{
    Task<List<Class>> GetAllAsync();
    Task<Class> GetByIdAsync(Guid id);
    Task<Class> CreateAsync(Class model);
    Task<Class> UpdateAsync(Guid id, Class modelToUpdate);
    Task<Class> DeleteAsync(Guid id);
}