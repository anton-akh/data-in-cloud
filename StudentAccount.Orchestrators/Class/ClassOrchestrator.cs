using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.Class;

namespace StudentAccount.Orchestrators.Class;

public class ClassOrchestrator : IClassOrchestrator
{
    private readonly IClassRepository _repository;

    public ClassOrchestrator(
        IClassRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Model.Class.Class>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Model.Class.Class> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Model.Class.Class> CreateAsync(Model.Class.Class model)
    {
        return await _repository.CreateAsync(model);
    }

    public Task<Model.Class.Class> UpdateAsync(Guid id, Model.Class.Class modelToUpdate)
    {
        throw new NotImplementedException();
    }

    public Task<Model.Class.Class> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}