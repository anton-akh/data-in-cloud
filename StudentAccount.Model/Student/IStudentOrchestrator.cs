using System.Threading.Tasks;

namespace StudentAccount.Model.Student;

public interface IStudentOrchestrator
{
    Task<Student> CreateAsync(Student model);
}