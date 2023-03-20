using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Model.Student;

public interface IStudentOrchestrator
{
    Task<Student> CreateAsync(Student model);
    Task<List<Student>> GetAllAsync();
    Task<Student> GetByIdAsync(int id);
    Task<Student> DeleteAsync(int id);
    Task<Student> UpdateAsync(int id, Student modelToUpdate);
}