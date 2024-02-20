using AutoMapper;
using GeekShopping.Cart.Api.Infra.CrossCutting.AutoMapper;

namespace GeekShopping.Cart.Api.Infra.Ioc
{
    public static class InjectionAutoMapper
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            var configAutoMapper = new MapperConfiguration(x =>
            {

                x.AddProfile(new DtoToEntityProfile());
                x.AddProfile(new EntityToDtoProfile());


            });

            IMapper mapper = configAutoMapper.CreateMapper();
            serviceCollection.AddSingleton(mapper);

        }
    }
}