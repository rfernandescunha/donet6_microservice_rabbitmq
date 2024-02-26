using GeekShopping.Payment.Api.Infra.Ioc;
using GeekShopping.Payment.Api.Infra.Ioc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeekShopping.Payment.Api.Configs
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
