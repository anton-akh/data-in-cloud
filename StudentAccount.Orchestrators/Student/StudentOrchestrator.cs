using System.Threading.Tasks;
using StudentAccount.Model.Student;

namespace StudentAccount.Orchestrators.Student;

public class StudentOrchestrator : IStudentOrchestrator
{
    private readonly IStudentRepository _studentRepository;

    public StudentOrchestrator(
        IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }


    public async Task<Model.Student.Student> CreateAsync(
        Model.Student.Student model)
    {
        return await _studentRepository.CreateAsync(model);
    }
}