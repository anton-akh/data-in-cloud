using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentAccount.Model.CourseStudent;

public interface ICourseStudentOrchestrator
{
    Task<CourseStudent> CreateAsync(Guid courseId, int studentId);
    Task<List<int>> GetStudentsAsync(Guid courseId);
}