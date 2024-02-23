using GeekShopping.Card.Api.Infra.Ioc;
using GeekShopping.Cart.Api.Infra.Ioc;

namespace GeekShopping.Card.Api.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectionRepository.Register(services, configuration);
            InjectionApiClientService.Register(services);
            InjectionService.Register(services);
            InjectionAutoMapper.Register(services);
        }
    }
}
