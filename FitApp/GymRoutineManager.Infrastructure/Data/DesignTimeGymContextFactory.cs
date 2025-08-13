using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GymRoutineManager.Infrastructure.Data
{
    public class DesignTimeGymContextFactory : IDesignTimeDbContextFactory<GymContext>
    {
        public GymContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<GymContext>();
            optionsBuilder.UseSqlServer("Server=GABRIEL-G15\\MSSQLSERVER01;Database=GymRoutineDB;Trusted_Connection=True;TrustServerCertificate=True;");
            return new GymContext(optionsBuilder.Options);
        }
    }
}