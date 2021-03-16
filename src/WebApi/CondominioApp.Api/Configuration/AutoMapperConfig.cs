using CondominioApp.ArquivoDigital.App.AutoMapper;
using CondominioApp.Correspondencias.App.AutoMapper;
using CondominioApp.Enquetes.App.AutoMapper;
using CondominioApp.Principal.Aplication.AutoMapper;
using CondominioApp.ReservaAreaComum.Aplication.AutoMapper;
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
                cfg.AddProfile(new ViewModelToEntityComunicado());
                cfg.AddProfile(new EntityToViewModelComunicado());
                cfg.AddProfile(new ViewModelToEntityAreaComum());
                cfg.AddProfile(new EntityToViewModelAreaComum());
                cfg.AddProfile(new EntityToViewModelContrato());
                cfg.AddProfile(new EntityToViewModelUsuario());
                cfg.AddProfile(new EntityToViewModelArquivoDigital());
                //cfg.AddProfile(new EntityToViewModelEstatistica());
                //cfg.AddProfile(new ViewModelToEntityEstatistica());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }              
    }  
}