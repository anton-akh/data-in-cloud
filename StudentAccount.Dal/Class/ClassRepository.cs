using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAccount.Model.Class;

namespace StudentAccount.Dal.Class;

public class ClassRepository : IClassRepository
{
    private readonly IMapper _mapper;
    private readonly CosmosDbContext _context;

    public ClassRepository(
        IMapper mapper,
        CosmosDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<Model.Class.Class>> GetAllAsync()
    {
        var entities = await _context.Classes.ToListAsync();

        return _mapper.Map<List<Model.Class.Class>>(entities);
    }

    public async Task<Model.Class.Class> GetByIdAsync(Guid id)
    {
        var entity = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);

        return _mapper.Map<Model.Class.Class>(entity);
    }

    public async Task<Model.Class.Class> CreateAsync(Model.Class.Class model)
    {
        var entity = _mapper.Map<ClassDao>(model);
        entity.Id = Guid.NewGuid();

        await _context.Classes.AddAsync(entity);

        return _mapper.Map<Model.Class.Class>(entity);
    }
}