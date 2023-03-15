using System.Threading.Tasks;

namespace StudentAccount.Model.Student;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student model);
}