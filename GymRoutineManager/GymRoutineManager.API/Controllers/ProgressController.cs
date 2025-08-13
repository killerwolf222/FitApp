using GymRoutineManager.Domain.Entities;
using GymRoutineManager.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymRoutineManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgressController : ControllerBase
    {
        private readonly IProgressService _service;

        public ProgressController(IProgressService service)
        {
            _service = service;
        }

        [HttpGet("exercise/{exerciseId}")]
        public async Task<IActionResult> GetByExercise(int exerciseId)
        {
            var progress = await _service.GetByExerciseIdAsync(exerciseId);
            return Ok(progress);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Progress progress)
        {
            if (progress == null)
                return BadRequest();

            await _service.AddProgressAsync(progress);
            return Ok("Progreso registrado");
        }
    }
}