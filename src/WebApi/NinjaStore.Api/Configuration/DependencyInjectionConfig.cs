using NinjaStore.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using NinjaStore.Produtos.Aplication.Commands;
using NinjaStore.Produtos.Aplication.Events;
using NinjaStore.Produtos.Domain.Interfaces;
using NinjaStore.Produtos.Infra.Data.Repository;
using NinjaStore.Produtos.Aplication.Query;

namespace NinjaStore.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();


            #region Cliente -Contexto
            //Cliente
            //services.AddScoped<IRequestHandler<AdicionarCorrespondenciaCommand, ValidationResult>, CorrespondenciaCommandHandler>();            
            //services.AddScoped<INotificationHandler<RegistraHistoricoEvent>, HistoricoEventHandler>();            
            #endregion

            #region Produto -Contexto
            //Produto
            services.AddScoped<IRequestHandler<AdicionarProdutoCommand, ValidationResult>, ProdutoCommandHandler>();            
            services.AddScoped<INotificationHandler<ProdutoAdicionadoEvent>, ProdutoEventHandler>();            

            #endregion

            #region Pedido -Contexto

            //Pedido            

            #endregion



            #region Querys            
            services.AddScoped<IProdutoQuery, ProdutoQuery>();            
            //services.AddScoped<IClienteQuery, ClienteQuery>();            
            //services.AddScoped<IPedidoQuery, PedidoQuery>();
            #endregion

            #region Repositórios                        
            services.AddScoped<IProdutoRepository, ProdutoRepository>();            
            //services.AddScoped<IClienteRepository, ClienteRepository>();            
            //services.AddScoped<IPedidoRepository, PedidoRepository>();            

            #endregion

            #region Repositórios Query                           
            services.AddScoped<IProdutoQueryRepository, ProdutoQueryRepository>();                                    
            #endregion

        }
    }
}
