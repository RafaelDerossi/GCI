﻿using AutoMapper;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Events;
using CondominioAppMarketplace.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioAppMarketplace.App
{
    public class AppServiceLead : AppService, IAppServiceLead
    {
        private readonly IItemDeVendaRepository _itemDeVendaRepository;
        
        private readonly IMapper _mapper;

        public AppServiceLead(IItemDeVendaRepository itemDeVendaRepository, IMapper mapper)
        {
            _itemDeVendaRepository = itemDeVendaRepository;
            
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeadMarketplaceViewModel>> ObterPorParceiro(Guid ParceiroId)
        {
            var leads = await _itemDeVendaRepository.ObterLeads(x => x.ItemDeVenda.ParceiroId == ParceiroId && !x.Lixeira, true, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<LeadMarketplaceViewModel>>(leads));
        }

        public async Task<IEnumerable<LeadMarketplaceViewModel>> ObterPorVendedor(Guid VendedorId)
        {
            var leads = await _itemDeVendaRepository.ObterLeads(x => x.ItemDeVenda.VendedorId == VendedorId && !x.Lixeira, true, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<LeadMarketplaceViewModel>>(leads));
        }

        public async Task<IEnumerable<LeadMarketplaceViewModel>> ObterTodos()
        {
            var leads = await _itemDeVendaRepository.ObterLeads(x => !x.Lixeira, true, 250);

            return await Task.FromResult(_mapper.Map<IEnumerable<LeadMarketplaceViewModel>>(leads));
        }


        public async Task<ValidationResult> EnviarLead(LeadNovoViewModel ViewModel)
        {
            var lead = _mapper.Map<Lead>(ViewModel);

            _itemDeVendaRepository.AdicionarLead(lead);

            var ItemDeVenda = await _itemDeVendaRepository.ObterPorId(lead.ItemDeVendaId);

            lead.AdicionarEvento(new NotificarVendedorEvent(lead.Id, ItemDeVenda.VendedorId));

            return await PersistirDados(_itemDeVendaRepository.UnitOfWork);           
           
        }

        public void Dispose()
        {
            _itemDeVendaRepository?.Dispose();
        }
    }
}