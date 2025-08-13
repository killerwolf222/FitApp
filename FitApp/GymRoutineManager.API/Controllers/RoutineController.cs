using GymRoutineManager.Application.Services;
using GymRoutineManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GymRoutineManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoutineController : ControllerBase
    {
        private readonly RoutineService _service;

        public RoutineController(RoutineService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var routines = await _service.GetAllAsync();
            var dtoList = routines.Select(r => new RoutineDto
            {
                Id = r.Id,
                Name = r.Name
            }).ToList();

            return Ok(dtoList);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Routine routine)
        {
            if (routine == null) return BadRequest();

            await _service.AddRoutineAsync(routine);
            return Ok("Rutina creada");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _service.DeleteRoutineAsync(id);
            if (!eliminado)
                return NotFound("Rutina no encontrada");

            return Ok("Rutina eliminada");
        }
    }

    public class RoutineDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
