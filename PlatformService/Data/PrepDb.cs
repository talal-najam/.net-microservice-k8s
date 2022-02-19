using PlatformService.Models;
using Microsoft.EntityFrameworkCore;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IServiceCollection app, bool isProd)
        {
            var serviceCollection = app.BuildServiceProvider();
            using( var serviceScope = serviceCollection.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext context, bool isProd)
        {
            // if(isProd)
            // {
                System.Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            // }

            if(!context.Platforms.Any())
            {
                System.Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() {Name="DotNet", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="SQL Server Express", Publisher="Microsoft", Cost="Free"},
                    new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="Free"}
                );

                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("--> We already have data!");
            }
        }
    }
}
