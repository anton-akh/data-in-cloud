using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentAccount.Model.Class;
using StudentAccount.Model.CourseStudent;
using StudentAccount.Model.Student;
using StudentAccount.Platform.BlobStorage;

namespace StudentAccount.Orchestrators.CourseStudent;

public class CourseStudentOrchestrator : ICourseStudentOrchestrator
{
    private readonly IStudentOrchestrator _studentOrchestrator;
    private readonly IClassOrchestrator _classOrchestrator;
    private readonly IBlobStorage _courseStudentStorage;

    public CourseStudentOrchestrator(
        IStudentOrchestrator studentOrchestrator,
        IClassOrchestrator classOrchestrator,
        IBlobStorage courseStudentStorage)
    {
        _studentOrchestrator = studentOrchestrator;
        _classOrchestrator = classOrchestrator;
        _courseStudentStorage = courseStudentStorage;
    }

    public async Task<Model.CourseStudent.CourseStudent> CreateAsync(Guid courseId, int studentId)
    {
        var student = await _studentOrchestrator.GetByIdAsync(studentId);

        var course = await _classOrchestrator.GetByIdAsync(courseId);

        var relationFileName = $"{courseId:N}_{studentId}";
        var exists = await _courseStudentStorage.ContainsFileByNameAsync(relationFileName);

        if (!exists)
        {
            await _courseStudentStorage.PutContextAsync(relationFileName);
        }

        return new Model.CourseStudent.CourseStudent
        {
            CourseId = courseId,
            StudentId = studentId
        };
    }

    public async Task<List<int>> GetStudentsAsync(Guid courseId)
    {
        var course = await _classOrchestrator.GetByIdAsync(courseId);

        var clients = await _courseStudentStorage.FindByCourseAsync(courseId);

        return clients;
    }
}