namespace GymRoutineManager.Application.DTOs
{
    public class RoutineDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<ExerciseDTO> Exercises { get; set; } = new();
    }
}
