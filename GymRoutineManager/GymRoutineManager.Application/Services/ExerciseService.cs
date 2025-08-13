using GymRoutineManager.Domain.Entities;
using GymRoutineManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymRoutineManager.Application.Services
{
    public class ExerciseService
    {
        private readonly GymContext _context;

        public ExerciseService(GymContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllByRoutineIdAsync(int routineId)
        {
            return await _context.Exercises
                .Where(e => e.RoutineId == routineId)
                .ToListAsync();
        }

        public async Task AddExerciseAsync(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task DeleteExerciseAsync(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
