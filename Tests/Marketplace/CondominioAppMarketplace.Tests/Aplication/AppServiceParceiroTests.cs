using System;
using System.Threading.Tasks;
using AutoMapper;
using CondominioApp.Core.ValueObjects;
using CondominioAppMarketplace.App;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using CondominioAppMarketplace.Infra.Repositories;
using CondominioAppMarketplace.Tests.Domain;
using Moq;
using Moq.AutoMock;
using Xunit;

namespace CondominioAppMarketplace.Tests.Aplication
{
    public class AppServiceParceiroTests
    {
        private readonly AutoMocker _mocker;
        private readonly AppServiceLead _appServiceLead;

        public AppServiceParceiroTests()
        {
            _mocker = new AutoMocker();
            _appServiceLead = _mocker.CreateInstance<AppServiceLead>();
        }

        //[Fact(DisplayName = "Enviar Lead")]
        //[Trait("Categoria", "Lead - AppServiceLead")]
        //public async Task EnviarLead()
        //{
        //    //Arrange
        //    LeadNovoViewModel ViewModel = new LeadNovoViewModel()
        //    {
        //        NomeDoCondominio = "Condominio",
        //        NomeDoCliente = "Cliente",
        //        Bloco = "Bloco",
        //        Unidade = "Unidade",
        //        Observacao = "Obs",
        //        TelefoneDoCliente = null,
        //        EmailDoMorador = "fulano@gmail.com",
        //        ItemDeVendaId = Guid.NewGuid()
        //    };
          

        //    var lead = new Lead(ViewModel.NomeDoCondominio, ViewModel.NomeDoCliente, ViewModel.Bloco,
        //        ViewModel.Unidade, ViewModel.Observacao, null, new Email(ViewModel.EmailDoMorador),
        //        ViewModel.ItemDeVendaId);                                

        //    var itemDeVenda = new ItemDeVenda(10, 2, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(3),
        //       Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid());
        //       itemDeVenda.SetEntidadeId(lead.ItemDeVendaId);

        //    _mocker.GetMock<IMapper>().Setup(r => r.Map<Lead>(ViewModel))
        //        .Returns(lead);

        //    _mocker.GetMock<IItemDeVendaRepository>().Setup(r => r.ObterPorId(lead.ItemDeVendaId))
        //        .Returns(Task.FromResult(itemDeVenda));

        //    _mocker.GetMock<IItemDeVendaRepository>().Setup(r => r.UnitOfWork.Commit())
        //        .Returns(Task.FromResult(true));

        //    //Act
        //    var result = await _appServiceLead.EnviarLead(ViewModel);

        //    //Assert
        //    Assert.True(result.IsValid);
        //    _mocker.GetMock<IItemDeVendaRepository>().Verify(r => r.UnitOfWork.Commit(), Times.Once);
        //}

       
    }
}