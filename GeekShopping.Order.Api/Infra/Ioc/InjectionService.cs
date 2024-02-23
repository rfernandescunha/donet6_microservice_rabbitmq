using GeekShopping.Order.Api.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GeekShopping.Order.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<RabbitMqConsumerServices>();

        }
    }
}