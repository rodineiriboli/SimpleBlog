using Microsoft.Extensions.DependencyInjection;
using SimpleBlog.Application.Helpers;
using SimpleBlog.Application.Interfaces;
using SimpleBlog.Application.Services;
using SimpleBlog.Domain.Interfaces;
using SimpleBlog.Infra.Data.Repositories;

namespace SimpleBlog.Infra.IoC
{
    public static class ServiceCollectionExtensions
    {
        //public static void AddRoyalLibraryDbContext(this IServiceCollection services, string connectionString)
        //    => services.AddDbContext<IRoyalLibraryDbContext, RoyalLibraryDbContext>(options => options.UseSqlServer(connectionString));

        //public static void RegisterInfra(this IServiceCollection services)
        //    => services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void RegisterRepositories(this IServiceCollection services)
            => services.AddScoped<IUserRepository, UserRepository>();

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthAppService, AuthAppService>();
            services.AddScoped<IUserService, UsersService>();
            services.AddTransient<ICryptoPassHelper, CryptoPassHelper>();
        }
    }
}
