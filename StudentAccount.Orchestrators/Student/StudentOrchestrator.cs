using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.Student;
using StudentAccount.Platform.Exception;

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

    public async Task<List<Model.Student.Student>> GetAllAsync()
    {
        return await _studentRepository.GetAll();
    }

    public async Task<Model.Student.Student> GetByIdAsync(int id)
    {
        var studentById = await _studentRepository.GetByIdAsync(id);

        if (studentById == null)
        {
            throw new ResourceNotFoundException($"Student with id = {id} not found");
        }

        return studentById;
    }

    public async Task<Model.Student.Student> DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);

        await _studentRepository.DeleteAsync(id);

        return entity;
    }

    public async Task<Model.Student.Student> UpdateAsync(int id, Model.Student.Student modelToUpdate)
    {
        var existingEntity = await GetByIdAsync(id);

        existingEntity.LastName = modelToUpdate.LastName;
        existingEntity.FirstName = modelToUpdate.FirstName;

        return await _studentRepository.UpdateAsync(existingEntity);
    }
}