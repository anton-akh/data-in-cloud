using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using StudentAccount.Model.Class;
using StudentAccount.Platform.ServiceBus;

namespace StudentAccount.Orchestrators.Class;

public class ClassOrchestrator : IClassOrchestrator
{
    private readonly IPublisher _publisher;
    private readonly IClassRepository _repository;

    public ClassOrchestrator(
        IPublisher publisher,
        IClassRepository repository)
    {
        _publisher = publisher;
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
        var entity = await _repository.CreateAsync(model);

        await _publisher.PublishAsync(entity.Id);

        return entity;
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