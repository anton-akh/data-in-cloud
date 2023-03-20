using System.Threading.Tasks;
using AutoMapper;
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
}