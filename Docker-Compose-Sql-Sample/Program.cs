
using Docker_Compose_Sql_Sample.Data;
using Docker_Compose_Sql_Sample.Extensions;
using Docker_Compose_Sql_Sample.Services;

namespace Docker_Compose_Sql_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var sqlconnstring = builder.Configuration.GetConnectionString("sqlblogdb");
            builder.Services.AddSqlServer<ApplicationDbContext>(sqlconnstring);

            builder.Services.AddScoped<IBlogService, BlogService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.CreateDbIfNotExists();

            app.Run();
        }
    }
}
