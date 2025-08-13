using GymRoutineManager.Domain.Entities;
using GymRoutineManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymRoutineManager.Infrastructure.Repositories
{
    public class ProgressRepository
    {
        private readonly GymContext _context;

        public ProgressRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<List<Progress>> GetByExerciseIdAsync(int exerciseId)
        {
            return await _context.Progresses
                .Where(p => p.ExerciseId == exerciseId)
                .OrderBy(p => p.Fecha)
                .ToListAsync();
        }

        public async Task AddProgressAsync(Progress progress)
        {
            _context.Progresses.Add(progress);
            await _context.SaveChangesAsync();
        }
    }
}