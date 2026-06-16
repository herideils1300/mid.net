using AbySalto.Mid.Application.Networking;
using AbySalto.Mid.Domain.Business.Networking;
using Microsoft.Extensions.DependencyInjection;
namespace AbySalto.Mid.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetFilteredProductsClient>();
            services.AddScoped<UriFactory>();
            return services;
        }
    }
}
