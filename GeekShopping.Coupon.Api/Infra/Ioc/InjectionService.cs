using GeekShopping.Coupon.Api.Domain.Interfaces.IServices;
using GeekShopping.Coupon.Api.Domain.Services;

namespace GeekShopping.Card.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICouponServices, CouponServices>();

        }
    }
}