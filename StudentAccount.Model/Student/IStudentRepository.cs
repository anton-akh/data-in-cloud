using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Model.Student;

public interface IStudentRepository
{
    Task<Student> CreateAsync(Student model);
    Task<List<Student>> GetAll();
    Task<Student> GetByIdAsync(int id);
    Task DeleteAsync(int id);
    Task<Student> UpdateAsync(Student existingEntity);
}