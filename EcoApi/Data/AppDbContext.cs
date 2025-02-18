using Microsoft.EntityFrameworkCore;

namespace EcoApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Role> Roles { get; set; }
        public DbSet<Models.Recommendation> Recommendations { get; set; }
        public DbSet<Models.Report> Reports { get; set; }
        public DbSet<Models.Activity> Activities { get; set; }
        public DbSet<Models.Asset> Assets { get; set; }
        public DbSet<Models.CarbonGoal> CarbonGoals { get; set; }
        public DbSet<Models.EmissionFactor> EmissionFactors { get; set; }

    }
}
