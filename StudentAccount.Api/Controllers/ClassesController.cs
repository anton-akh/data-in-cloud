using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentAccount.Model.Class;
using StudentAccount.Orchestrators.Class.Contract;
using System;
using System.Threading.Tasks;

namespace StudentAccount.Api.Controllers
{
    [ApiController]
    [Route("api/v1/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClassesController> _logger;
        private readonly IClassOrchestrator _studentOrchestrator;

        public ClassesController(
            IMapper mapper,
            ILogger<ClassesController> logger,
            IClassOrchestrator studentOrchestrator)
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
        public async Task<IActionResult> GetById(Guid id)
        {
            var studentById = await _studentOrchestrator.GetByIdAsync(id);

            return Ok(studentById);
        }

        [HttpPost]
        public async Task<IActionResult> PostSync(CreateClass student)
        {
            var model = _mapper.Map<Class>(student);

            var result = await _studentOrchestrator.CreateAsync(model);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, EditClass model)
        {
            var modelToUpdate = _mapper.Map<Class>(model);
            modelToUpdate.Id = id;

            var entity = await _studentOrchestrator.UpdateAsync(id, modelToUpdate);

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deletedEntity = await _studentOrchestrator.DeleteAsync(id);

            return Ok(deletedEntity);
        }
    }
}