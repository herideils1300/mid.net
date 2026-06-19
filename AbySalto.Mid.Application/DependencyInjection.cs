using AbySalto.Mid.Application.Interfaces.Networking;
using AbySalto.Mid.Application.Products.Networking;
using AbySalto.Mid.Domain.Business.Networking;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Domain.Data.Model;
using Microsoft.Extensions.DependencyInjection;
namespace AbySalto.Mid.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IClient<ParamsModel, ProductDto[]>, GetFilteredProductsClient>();
            services.AddSingleton<IClient<int, ProductDto>, GetProductByIdClient>();
            return services;
        }
    }
}
