using GymRoutineManager.Application.Services;
using GymRoutineManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymRoutineManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly ExerciseService _service;

        public ExerciseController(ExerciseService service)
        {
            _service = service;
        }

        [HttpGet("routine/{routineId}")]
        public async Task<IActionResult> GetByRoutine(int routineId)
        {
            var exercises = await _service.GetAllByRoutineIdAsync(routineId);
            return Ok(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Exercise exercise)
        {
            if (exercise == null)
                return BadRequest("El objeto ejercicio es nulo");

            if (string.IsNullOrWhiteSpace(exercise.Name))
                return BadRequest("El nombre es obligatorio");

            if (exercise.Sets <= 0)
                return BadRequest("Sets debe ser mayor que 0");

            if (exercise.Reps <= 0)
                return BadRequest("Reps debe ser mayor que 0");

            if (exercise.Weight < 0)
                return BadRequest("Peso no puede ser negativo");

            if (exercise.RoutineId <= 0)
                return BadRequest("RoutineId inválido");

            try
            {
                await _service.AddExerciseAsync(exercise);
                return Ok("Ejercicio creado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ex = await _service.GetByIdAsync(id);
            if (ex == null)
                return NotFound("Ejercicio no encontrado");

            try
            {
                await _service.DeleteExerciseAsync(id);
                return Ok("Ejercicio eliminado");
            }
            catch (Exception ex2)
            {
                return StatusCode(500, $"Error eliminando ejercicio: {ex2.Message}");
            }
        }
    }
}
