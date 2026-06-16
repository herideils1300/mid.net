using AbySalto.Mid.Application.Networking;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Outbound.Networking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AbySalto.Mid.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(AddServices);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<GetAllProductsClient>();
            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
