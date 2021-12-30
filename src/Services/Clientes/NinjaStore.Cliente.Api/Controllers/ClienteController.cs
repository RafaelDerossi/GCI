﻿using GCI.Core.Mediator;
using GCI.WebApi.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCI.Acoes.Aplication.Query;
using GCI.Acoes.Aplication.ViewModels;
using GCI.Acoes.Aplication.Commands;
using GCI.Acoes.Domain.FlatModel;

namespace GCI.Acoes.Api.Controllers
{
    [Route("api/cliente")]
    public class ClienteController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        private readonly IClienteQuery _clienteQuery;

        public ClienteController
            (IMediatorHandler mediatorHandler, IClienteQuery clienteQuery)
        {
            _mediatorHandler = mediatorHandler;
            _clienteQuery = clienteQuery;
        }


        /// <summary>
        /// Retorna cliente por id;
        /// </summary>
        /// <param name="id">Guid do cliente</param>
        /// <response code="200">
        /// Id: Guid do cliente;   
        /// DataDeCadastro: Data em que o cliente foi cadastrado;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que o cliente foi cadastrado;   
        /// DataDeAlteracao:  Data em que o cliente foi alterado;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que o cliente foi alterado;   
        /// Lixeira: Informa se o cliente esta na lixeira;   
        /// Nome: Nome do cliente;   
        /// Email: Endereço de e-mail do cliente;   
        /// Aldeia: Aldeia do cliente;   
        /// </response>
        [HttpGet("por-id/{id:Guid}")]
        public async Task<ActionResult<ClienteViewModel>> ObterTodos(Guid id)
        {
            var cliente = await _clienteQuery.ObterPorId(id);
            if (cliente == null)
                return CustomResponse("Nenhum cliente encontrado.");

            return ClienteViewModel.Mapear(cliente);
        }

        /// <summary>
        /// Retorna todos os cliente cadastrados;
        /// </summary>
        /// <response code="200">
        /// Id: Guid do cliente;   
        /// DataDeCadastro: Data em que o cliente foi cadastrado;   
        /// DataDeCadastroFormatada: Data formatada para exibição em que o cliente foi cadastrado;   
        /// DataDeAlteracao:  Data em que o cliente foi alterado;   
        /// DataDeAlteracaoFormatada: Data formatada para exibição em que o cliente foi alterado;   
        /// Lixeira: Informa se o cliente esta na lixeira;   
        /// Nome: Nome do cliente;   
        /// Email: Endereço de e-mail do cliente;   
        /// Aldeia: Aldeia do cliente;   
        /// </response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> ObterTodos()
        {
            var clientes = await _clienteQuery.ObterTodos();
            if (clientes.Count() == 0)
                return CustomResponse("Nenhum cliente encontrado.");

            return clientes.Select(ClienteViewModel.Mapear).ToList();
        }


        /// <summary>
        /// Adiciona um novo cliente
        /// </summary>
        /// <param name="viewModel">
        /// Nome: Nome do cliente (Obrigatório)(De 1 a 200 caracteres);             
        /// Email: Endereço de e-mail do cliente (Obrigatório);   
        /// Aldeia: Aldeia do cliente (Obrigatório)(De 1 a 200 caracteres);   
        /// </param>        
        [HttpPost]
        public async Task<ActionResult> Post(AdicionaClienteViewModel viewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var comando = new AdicionarClienteCommand
                (viewModel.Nome, viewModel.Email, viewModel.Aldeia);           

            return CustomResponse(await _mediatorHandler.EnviarComando(comando));
        }        
    }
}
