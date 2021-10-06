using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Aplication.Events;
using NinjaStore.Produtos.Domain.Interfaces;
using NinjaStore.Produtos.Infra.Data.Repository;
using NinjaStore.Produtos.Aplication.Query;

namespace NinjaStore.Produtos.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Produto
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, ValidationResult>, ProdutoCommandHandler>();            
            services.AddScoped<INotificationHandler<ProdutoAdicionadoEvent>, ProdutoEventHandler>();

            //Query
            services.AddScoped<IProdutoQuery, ProdutoQuery>();            
            
            //Repositório
            services.AddScoped<IProdutoRepository, ProdutoRepository>();            
            
            //Repositório Query
            services.AddScoped<IProdutoQueryRepository, ProdutoQueryRepository>();
            
        }
    }
}
