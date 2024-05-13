using SimpleBlog.Api.Configuration;
using SimpleBlog.Application.Mappers;
using SimpleBlog.Infra.IoC;

namespace SimpleBlog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

            //services.AddJwtConfiguration(configuration);
            builder.Services.AddJwtConfiguration(builder.Configuration);



            // Database
            builder.Services.AddDatabaseConfiguration(builder.Configuration);


            // Add services to the container.

            //IoC
            builder.Services.RegisterServices();
            builder.Services.RegisterRepositories();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //Add Swagger Configuration
            builder.Services.AddSwaggerConfiguration();


            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerSetup();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
