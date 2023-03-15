using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace StudentAccount.Api.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentsController : ControllerBase
    {
       private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
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
        public async Task<IActionResult> PostASync()
        {
            return Ok();
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