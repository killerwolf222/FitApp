using GymRoutineManager.Domain.Entities;
using GymRoutineManager.Infrastructure.Repositories;

namespace GymRoutineManager.Application.Services
{
    public class ProgressService : IProgressService
    {
        private readonly ProgressRepository _repository;

        public ProgressService(ProgressRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Progress>> GetByExerciseIdAsync(int exerciseId)
        {
            return await _repository.GetByExerciseIdAsync(exerciseId);
        }

        public async Task AddProgressAsync(Progress progress)
        {
            await _repository.AddProgressAsync(progress);
        }
    }

    public interface IProgressService
    {
        Task<List<Progress>> GetByExerciseIdAsync(int exerciseId);
        Task AddProgressAsync(Progress progress);
    }
}