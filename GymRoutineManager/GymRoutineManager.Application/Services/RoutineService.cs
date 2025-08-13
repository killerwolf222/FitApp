using GymRoutineManager.Domain.Entities;
using GymRoutineManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GymRoutineManager.Application.Services
{
    public class RoutineService
    {
        private readonly GymContext _context;

        public RoutineService(GymContext context)
        {
            _context = context;
        }

        public async Task<List<Routine>> GetAllAsync()
        {
            return await _context.Routines.Include(r => r.Exercises).ToListAsync();
        }

        public async Task AddRoutineAsync(Routine routine)
        {
            _context.Routines.Add(routine);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteRoutineAsync(int id)
        {
            var routine = await _context.Routines
                .Include(r => r.Exercises)  // Cargar ejercicios si quieres manipularlos
                .FirstOrDefaultAsync(r => r.Id == id);

            if (routine == null)
                return false;   

            // Si no tienes configurada eliminación en cascada en la BD,
            // puedes eliminar los ejercicios asociados manualmente:
            // _context.Exercises.RemoveRange(routine.Exercises);

            _context.Routines.Remove(routine);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
