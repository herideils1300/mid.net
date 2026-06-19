using AbySalto.Mid.Domain.Business.Authorization;
using AbySalto.Mid.Domain.Business.Databasing;
using AbySalto.Mid.Domain.Business.Logging;
using AbySalto.Mid.Domain.Interfaces.Logging;
using AbySalto.Mid.Infrastructure.Products.Repository;
using AbySalto.Mid.Infrastructure.Products.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbySalto.Mid.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Hasher>();
            services.AddSingleton<ErrorWriter>();
            services = AddDatabase(services, configuration);
            services = AddServices(services);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<AuthenticateUserService>();
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Db>((services) =>
            {
                Db db = new Db(configuration.GetConnectionString("TestDbConnection") ?? throw new Exception("Connection string not found."));
                return db;
            });
            services.AddSingleton<UserRepository>();
            services.AddSingleton<FavouritesRepository>();
            return services;
        }
    }
}
