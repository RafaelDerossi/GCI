using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Aplication.Events;
using NinjaStore.Produtos.Domain.Interfaces;
using NinjaStore.Produtos.Infra.Data.Repository;
using NinjaStore.Produtos.Aplication.Query;
using NinjaStore.Core.Data;

namespace NinjaStore.Produtos.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));


            //Produto
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, ValidationResult>, ProdutoCommandHandler>();            
            
            //Query
            services.AddScoped<IProdutoQuery, ProdutoQuery>();            
            
            //Repositório
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            
        }
    }
}
