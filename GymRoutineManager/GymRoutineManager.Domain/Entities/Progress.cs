namespace GymRoutineManager.Domain.Entities
{
    public class Progress
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public DateTime Fecha { get; set; }
        public double Peso { get; set; }
        public int Reps { get; set; }
    }
}
