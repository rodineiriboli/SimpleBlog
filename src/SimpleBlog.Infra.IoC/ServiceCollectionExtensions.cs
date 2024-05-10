using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Services;

namespace SimpleBlog.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        //public static void AddRoyalLibraryDbContext(this IServiceCollection services, string connectionString)
        //    => services.AddDbContext<IRoyalLibraryDbContext, RoyalLibraryDbContext>(options => options.UseSqlServer(connectionString));

        //public static void RegisterInfra(this IServiceCollection services)
        //    => services.AddScoped<IUnitOfWork, UnitOfWork>();

        //public static void RegisterRepositories(this IServiceCollection services)
        //    => services.AddScoped<IBookRepository, BookRepository>();

        public static void RegisterServices(this IServiceCollection services)
            => services.AddScoped<IAuthAppService, AuthAppService>();
    }
}
