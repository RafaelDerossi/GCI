﻿using GCI.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation.Results;
using GCI.Acoes.Aplication.Commands;
using GCI.Acoes.Aplication.Query;
using GCI.Acoes.Domain.Interfaces;
using GCI.Acoes.Infra.Data.Repository;
using GCI.Core.Data;

namespace GCI.Acoes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {            
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            //Cliente
            services.AddScoped<IRequestHandler<AdicionarClienteCommand, ValidationResult>, ClienteCommandHandler>();            
                        
            //Query
            services.AddScoped<IClienteQuery, ClienteQuery>();
            
            //Repositório            
            services.AddScoped<IClienteRepository, ClienteRepository>();                                    


            

        }
    }
}
