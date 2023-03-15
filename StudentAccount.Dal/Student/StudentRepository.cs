using System.Threading.Tasks;
using AutoMapper;
using StudentAccount.Model.Student;

namespace StudentAccount.Dal.Student;

public class StudentRepository : IStudentRepository
{
    private readonly IMapper _mapper;
    private readonly AppContext _context;

    public StudentRepository(
        IMapper mapper,
        AppContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Model.Student.Student> CreateAsync(Model.Student.Student model)
    {
        var entity = _mapper.Map<StudentDao>(model);

        var result = await _context.Students.AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<Model.Student.Student>(result.Entity);
    }
}