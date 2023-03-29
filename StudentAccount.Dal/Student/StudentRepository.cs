using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentAccount.Model.Student;

namespace StudentAccount.Dal.Student;

public class StudentRepository : IStudentRepository
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;

    public StudentRepository(
        IMapper mapper,
        AppDbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }

    public async Task<Model.Student.Student> CreateAsync(Model.Student.Student model)
    {
        var entity = _mapper.Map<StudentDao>(model);

        var result = await _dbContext.Students.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Model.Student.Student>(result.Entity);
    }

    public async Task<List<Model.Student.Student>> GetAll()
    {
        var entities = await _dbContext.Students.AsNoTracking().ToListAsync();

        return _mapper.Map<List<Model.Student.Student>>(entities);
    }

    public async Task<Model.Student.Student> GetByIdAsync(int id)
    {
        var entity = await _dbContext.Students
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Id == id);

        return _mapper.Map<Model.Student.Student>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var existingEntity = await _dbContext.Students.FirstAsync(s => s.Id == id);
        _dbContext.Students.Remove(existingEntity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Model.Student.Student> UpdateAsync(Model.Student.Student entity)
    {
        var existingEntity = _mapper.Map<StudentDao>(entity);
        var entityEntry = _dbContext.Students.Update(existingEntity);

        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Model.Student.Student>(entityEntry.Entity);
    }
}