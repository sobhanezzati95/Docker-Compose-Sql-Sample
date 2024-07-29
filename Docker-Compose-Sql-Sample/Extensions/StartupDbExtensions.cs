using Docker_Compose_Sql_Sample.Data;
using EFCore.AutomaticMigrations;

namespace Docker_Compose_Sql_Sample.Extensions
{
    public static class StartupDbExtensions
    {
        public static async void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var blogContext = services.GetRequiredService<ApplicationDbContext>();

            blogContext.Database.EnsureCreated();

            // MigrateDatabaseToLatestVersion.Execute(blogContext);


            //MigrateDatabaseToLatestVersion.Execute(blogContext, 
            //   new DbMigrationsOptions { ResetDatabaseSchema = true,  });

            blogContext.MigrateToLatestVersion();
            DBInitializerSeedData.InitializeDatabase(blogContext);
        }
    }
}
