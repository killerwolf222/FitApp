namespace GymRoutineManager.Domain.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public int RoutineId { get; set; }
        public Routine? Routine { get; set; }
    }
}
