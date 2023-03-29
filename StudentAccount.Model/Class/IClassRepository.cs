using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Model.Class;

public interface IClassRepository
{
    Task<List<Class>> GetAllAsync();
    Task<Class> GetByIdAsync(Guid id);
    Task<Class> CreateAsync(Class model);
}