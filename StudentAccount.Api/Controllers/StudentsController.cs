using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentAccount.Model.Student;
using StudentAccount.Orchestrators.Student.Contract;

namespace StudentAccount.Api.Controllers
{
    [ApiController]
    [Route("api/v1/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentOrchestrator _studentOrchestrator;

        public StudentsController(
            IMapper mapper,
            ILogger<StudentsController> logger, 
            IStudentOrchestrator studentOrchestrator)
        {
            _mapper = mapper;
            _logger = logger;
            _studentOrchestrator = studentOrchestrator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _studentOrchestrator.GetAllAsync();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentById = await _studentOrchestrator.GetByIdAsync(id);

            return Ok(studentById);
        }

        [HttpPost]
        public async Task<IActionResult> PostSync(CreateStudent student)
        {
            var model = _mapper.Map<Student>(student);

            var result = await _studentOrchestrator.CreateAsync(model);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, EditStudent model)
        {
            var modelToUpdate = _mapper.Map<Student>(model);
            modelToUpdate.Id = id;

            var entity = await _studentOrchestrator.UpdateAsync(id, modelToUpdate);

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedEntity = await _studentOrchestrator.DeleteAsync(id);

            return Ok(deletedEntity);
        }
    }
}