using GymRoutineManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymRoutineManager.Infrastructure.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<Routine> Routines { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Progress> Progresses { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Routine>()
                .HasMany(r => r.Exercises)
                .WithOne(e => e.Routine)
                .HasForeignKey(e => e.RoutineId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
