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

            // Database
            builder.Services.AddDatabaseConfiguration(builder.Configuration);

            //IoC
            builder.Services.RegisterServices();
            builder.Services.RegisterRepositories();

            //SignalR - Web Socket
            //builder.Services.AddSignalR();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            //Add Swagger Configuration
            builder.Services.AddSwaggerConfiguration();

            builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

            //JWT
            builder.Services.AddJwtConfiguration(builder.Configuration);

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerSetup();
            }
            

            app.UseCors(cors =>
            cors//.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            /*.WithOrigins("")*/);

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            //app.MapHub<HubProvider>("new-post");

            app.Run();
        }
    }
}
