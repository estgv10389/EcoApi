using EcoApi.Data;

namespace EcoApi.Seeders
{
    public class DataSeeder
    {
        public static void SeedData(AppDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Models.Role { Name = "Admin" },
                    new Models.Role { Name = "User" },
                    new Models.Role { Name = "Manager" }
                );
                context.SaveChanges();
            }
        }
    }
}
