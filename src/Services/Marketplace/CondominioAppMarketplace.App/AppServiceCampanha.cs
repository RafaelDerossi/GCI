using AutoMapper;
using CondominioAppMarketplace.App.Interfaces;
using CondominioAppMarketplace.App.ViewModel;
using CondominioAppMarketplace.Domain;
using CondominioAppMarketplace.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CondominioAppMarketplace.App
{
    public class AppServiceCampanha : AppService, IAppServiceCampanha
    {
        private readonly ICampanhaRepository _repository;

        private readonly IMapper _mapper;

        public AppServiceCampanha(ICampanhaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CampanhaViewModel>> CampanhasAtivas()
        {
            DateTime Hoje = DateTime.Now.Date;

            var campanhas = await _repository.Obter(x => x.DataDeInicio.Date <= Hoje &&
                                                    x.DataDeFim.Date >= Hoje &&
                                                    x.Ativo &&
                                                    !x.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<CampanhaViewModel>>(campanhas));
        }

        public async Task<IEnumerable<CampanhaViewModel>> CampanhasExpiradas()
        {
            DateTime Hoje = DateTime.Now.Date;

            var campanhas = await _repository.Obter(x => x.DataDeFim.Date < Hoje &&
                                                    x.Ativo &&
                                                    !x.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<CampanhaViewModel>>(campanhas));
        }

        public async Task<IEnumerable<CampanhaViewModel>> CampanhasFuturas()
        {
            DateTime Hoje = DateTime.Now.Date;

            var campanhas = await _repository.Obter(x => x.DataDeInicio.Date > Hoje &&
                                                    x.Ativo &&
                                                    !x.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<CampanhaViewModel>>(campanhas));
        }


        public async Task<IEnumerable<CampanhaViewModel>> CampanhasAtivasDoParceiro(Guid ParceiroId)
        {
            DateTime Hoje = DateTime.Now.Date;

            var campanhas = await _repository.Obter(x => x.DataDeInicio.Date <= Hoje &&
                                                    x.DataDeFim.Date >= Hoje &&
                                                    x.Ativo &&
                                                    x.ItemDeVenda.ParceiroId == ParceiroId &&
                                                    !x.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<CampanhaViewModel>>(campanhas));
        }

        public async Task<IEnumerable<CampanhaViewModel>> CampanhasExpiradasDoParceiro(Guid ParceiroId)
        {
            DateTime Hoje = DateTime.Now.Date;

            var campanhas = await _repository.Obter(x => x.DataDeFim.Date < Hoje &&
                                                    x.Ativo &&
                                                    x.ItemDeVenda.ParceiroId == ParceiroId &&
                                                    !x.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<CampanhaViewModel>>(campanhas));
        }

        public async Task<IEnumerable<CampanhaViewModel>> CampanhasFuturasDoParceiro(Guid ParceiroId)
        {
            DateTime Hoje = DateTime.Now.Date;

            var campanhas = await _repository.Obter(x => x.DataDeInicio.Date > Hoje &&
                                                    x.Ativo &&
                                                    x.ItemDeVenda.ParceiroId == ParceiroId &&
                                                    !x.Lixeira, true, 100);

            return await Task.FromResult(_mapper.Map<IEnumerable<CampanhaViewModel>>(campanhas));
        }

        public async Task<ValidationResult> ReconfigurarIntervalos(IntervaloDeCampanhaViewModel ViewModel)
        {
            var campanha = await _repository.ObterPorId(ViewModel.CampanhaId);

            var result = campanha.ConfigurarIntervalo(ViewModel.NovaDataDeInicio, ViewModel.NovaDataDeFinal);

            if (!result.IsValid) return result;

            _repository.Atualizar(campanha);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<bool> ContabilizarCliques(Guid CampanhaId)
        {
            var campanha = await _repository.ObterPorId(CampanhaId);

            campanha.ContaCliques();

            _repository.Atualizar(campanha);

            return await _repository.UnitOfWork.Commit();
        }

        public async Task<ValidationResult> IniciarCampanha(CampanhaNovaViewModel ViewModel)
        {
            var CampanhaNova = _mapper.Map<Campanha>(ViewModel);

            if (_repository.VerificaExistenciaDaCampanha(CampanhaNova.ItemDeVendaId))
            {
                AdicionarErro("Ja existe uma campanha ativa para este produto!");
                return ValidationResult;
            }

            _repository.Adicionar(CampanhaNova);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<bool> DeclinarCampanha(Guid CampanhaId)
        {
            var Campanha = await _repository.ObterPorId(CampanhaId);

            Campanha.Desativar();

            _repository.Atualizar(Campanha);

            return await _repository.UnitOfWork.Commit();
        }


        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
