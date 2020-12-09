using CondominioApp.Correspondencias.App.AutoMapper;
using CondominioApp.Enquetes.App.AutoMapper;
using CondominioAppMarketplace.App.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CondominioApp.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void ConfigurarAutoMapper(this IServiceCollection services)
        {

            //Configuração AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToViewModelLoja());
                cfg.AddProfile(new ViewModelToEntityLoja());
                cfg.AddProfile(new EntityToViewModelEnquete());
                cfg.AddProfile(new EntityToViewModelCorrespondencia());
                cfg.AddProfile(new ViewModelToEntityUnidadeComunicado());

                //cfg.AddProfile(new EntityToViewModelEstatistica());
                //cfg.AddProfile(new ViewModelToEntityEstatistica());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}