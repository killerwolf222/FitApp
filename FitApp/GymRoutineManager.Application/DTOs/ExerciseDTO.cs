namespace GymRoutineManager.Application.DTOs
{
    public class ExerciseDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}
