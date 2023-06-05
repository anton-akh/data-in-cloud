using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentAccount.Model.Class;
using System.Threading.Tasks;
using StudentAccount.Model.ClassStats;

namespace StudentAccount.Api.Controllers
{
    [ApiController]
    [Route("api/v1/stats")]
    public class ClassStatsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ClassesController> _logger;
        private readonly IClassStatsOrchestrator _classStatsOrchestrator;

        public ClassStatsController(
            IMapper mapper,
            ILogger<ClassesController> logger,
            IClassStatsOrchestrator classStatsOrchestrator)
        {
            _mapper = mapper;
            _logger = logger;
            _classStatsOrchestrator = classStatsOrchestrator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _classStatsOrchestrator.GetStatsAsync();

            return Ok(students);
        }
    }
}