using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentAccount.Model.CourseStudent;

namespace StudentAccount.Api.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseStudentsController : ControllerBase
    {

        private readonly ICourseStudentOrchestrator _courseStudentOrchestrator;
        public CourseStudentsController(
            ICourseStudentOrchestrator courseStudentOrchestrator)
        {
            _courseStudentOrchestrator = courseStudentOrchestrator;
        }

        [HttpPost("{courseId}/students/{studentId}")]
        public async Task<IActionResult> PostAsync(Guid courseId, int studentId)
        {
            var model = await _courseStudentOrchestrator.CreateAsync(courseId, studentId);

            return Ok(model);
        }

        [HttpGet("{courseId}/students")]
        public async Task<IActionResult> GetStudentsByCourseId(Guid courseId)
        {
            var model = await _courseStudentOrchestrator.GetStudentsAsync(courseId);

            return Ok(model);
        }
    }
}
