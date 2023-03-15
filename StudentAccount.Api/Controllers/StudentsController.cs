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
    [Route("students")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<StudentsController> _logger;
        private IStudentOrchestrator _studentOrchestrator;

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
            return Ok(new List<WeatherForecast>());
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(new List<WeatherForecast>());
        }

        [HttpPost]
        public async Task<IActionResult> PostSync(CreateStudent student)
        {
            var model = _mapper.Map<Student>(student);

            var result = await _studentOrchestrator.CreateAsync(model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(object model)
        {

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            return Ok();
        }
    }
}