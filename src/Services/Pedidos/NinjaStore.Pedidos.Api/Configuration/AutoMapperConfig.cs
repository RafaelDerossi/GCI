using Microsoft.Extensions.DependencyInjection;

namespace NinjaStore.Pedidos.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {
            //Configuração AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelParaDTO());                                
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }              
    }  
}