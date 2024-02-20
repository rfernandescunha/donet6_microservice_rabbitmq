using GeekShopping.Product.Api.Infra.Ioc;

namespace GeekShopping.Product.Api.Configs
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            InjectionRepository.Register(services, configuration);
            InjectionService.Register(services);
            InjectionAutoMapper.Register(services);
        }
    }
}
