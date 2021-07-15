using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Aplication.Events;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.Commands
{
    public class AreaComumCommandHandler : CommandHandler,
         IRequestHandler<AdicionarAreaComumCommand, ValidationResult>,
         IRequestHandler<AtualizarAreaComumCommand, ValidationResult>,
         IRequestHandler<ApagarAreaComumCommand, ValidationResult>,
         IRequestHandler<AtivarAreaComumCommand, ValidationResult>,
         IRequestHandler<DesativarAreaComumCommand, ValidationResult>,
         IRequestHandler<AdicionarFotoDeAreaComumCommand, ValidationResult>,
         IRequestHandler<RemoverFotoDaAreaComumCommand, ValidationResult>,
         IDisposable
    {

        private readonly IReservaAreaComumRepository _areaComumRepository;

        public AreaComumCommandHandler(IReservaAreaComumRepository areaComumRepository)
        {
            _areaComumRepository = areaComumRepository;
        }


        public async Task<ValidationResult> Handle(AdicionarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var areaComum = AreaComumFactory(request);         

            if (request.Periodos == null || request.Periodos.Count() == 0)
                AdicionarErro("Informe um Período de funcionamento para a area comum.");

            if (!ValidationResult.IsValid) return ValidationResult;

            foreach (Periodo periodo in request.Periodos)
            {
               var Result = areaComum.AdicionarPeriodo(periodo);
                if (!Result.IsValid) return Result;
            }           

            _areaComumRepository.Adicionar(areaComum);

            //Evento
            areaComum.AdicionarEvento(new AreaComumAdicionadaEvent
                (areaComum.Id, areaComum.Nome, areaComum.Descricao, areaComum.TermoDeUso,
                areaComum.CondominioId, areaComum.NomeCondominio, areaComum.Capacidade,
                areaComum.DiasPermitidos, areaComum.AntecedenciaMaximaEmMeses,
                areaComum.AntecedenciaMaximaEmDias, areaComum.AntecedenciaMinimaEmDias,
                areaComum.AntecedenciaMinimaParaCancelamentoEmDias, areaComum.RequerAprovacaoDeReserva,
                areaComum.TemHorariosEspecificos, areaComum.TempoDeIntervaloEntreReservas, areaComum.Ativa,
                areaComum.TempoDeDuracaoDeReserva, areaComum.NumeroLimiteDeReservaPorUnidade,
                areaComum.PermiteReservaSobreposta, areaComum.NumeroLimiteDeReservaSobreposta,
                areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade,
                areaComum.TempoDeIntervaloEntreReservasPorUnidade, areaComum.Periodos.ToList()));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(AtualizarAreaComumCommand request, CancellationToken cancellationToken)  
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areaComum = await _areaComumRepository.ObterPorId(request.Id);
            if (areaComum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            areaComum.SetNome(request.Nome);
            areaComum.SetDescricao(request.Descricao);
            areaComum.SetTermoDeUso(request.TermoDeUso);
            areaComum.SetCapacidade(request.Capacidade);
            areaComum.SetDiasPermitidos(request.DiasPermitidos);
            areaComum.SetAntecedenciaMaximaEmMeses(request.AntecedenciaMaximaEmMeses);
            areaComum.SetAntecedenciaMaximaEmDias(request.AntecedenciaMaximaEmDias);
            areaComum.SetAntecedenciaMinimaEmDias(request.AntecedenciaMinimaEmDias);
            areaComum.SetAntecedenciaMinimaParaCancelamentoEmDias(request.AntecedenciaMinimaParaCancelamentoEmDias);
            areaComum.SetTempoDeIntervaloEntreReservas(request.TempoDeIntervaloEntreReservas);
            areaComum.SetTempoDeDuracaoDeReserva(request.TempoDeDuracaoDeReserva);
            areaComum.SetNumeroLimiteDeReservaPorUnidade(request.NumeroLimiteDeReservaPorUnidade);
            areaComum.SetNumeroLimiteDeReservaSobreposta(request.NumeroLimiteDeReservaSobreposta);
            areaComum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(request.NumeroLimiteDeReservaSobrepostaPorUnidade);
            areaComum.SetTempoDeIntervaloEntreReservasPorUnidade(request.TempoDeIntervaloEntreReservasPorUnidade);

            areaComum.DesabilitarAprovacaoDeReserva();
            if (request.RequerAprovacaoDeReserva) areaComum.HabilitarAprovacaoDeReserva();

            areaComum.DesabilitarHorariosEspecifcos();
            if (request.TemHorariosEspecificos) areaComum.HabilitarHorariosEspecifcos();           

            areaComum.DesabilitarReservaSobreposta();
            if (request.PermiteReservaSobreposta) areaComum.HabilitarReservaSobreposta();           
           


            if (areaComum.Periodos != null)
            {
                foreach (Periodo periodo in areaComum.Periodos)
                {
                    _areaComumRepository.RemoverPeriodo(periodo);
                }
            }
            areaComum.RemoverTodosOsPeriodos();

            if (request.Periodos == null || request.Periodos.Count() == 0)
            {
                AdicionarErro("Informe um ou mais períodos de funcionamento da area comum.");
                return ValidationResult;
            }

            foreach (Periodo periodo in request.Periodos)
            {
                var resultado = areaComum.AdicionarPeriodo(periodo);
                if (!resultado.IsValid) return resultado;
                _areaComumRepository.AdicionarPeriodo(periodo);
            }          


            _areaComumRepository.Atualizar(areaComum);

            //Evento
            areaComum.AdicionarEvento(new AreaComumAtualizadaEvent
                (areaComum.Id, areaComum.Nome, areaComum.Descricao, areaComum.TermoDeUso, areaComum.Capacidade,
                areaComum.DiasPermitidos, areaComum.AntecedenciaMaximaEmMeses, areaComum.AntecedenciaMaximaEmDias,
                areaComum.AntecedenciaMinimaEmDias, areaComum.AntecedenciaMinimaParaCancelamentoEmDias,
                areaComum.RequerAprovacaoDeReserva, areaComum.TemHorariosEspecificos, areaComum.TempoDeIntervaloEntreReservas,
                areaComum.TempoDeDuracaoDeReserva, areaComum.NumeroLimiteDeReservaPorUnidade, areaComum.PermiteReservaSobreposta,
                areaComum.NumeroLimiteDeReservaSobreposta, areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade,
                areaComum.TempoDeIntervaloEntreReservasPorUnidade, areaComum.Periodos.ToList()));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(ApagarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areaComumBd = await _areaComumRepository.ObterPorId(request.Id);
            if (areaComumBd == null)
            {
                AdicionarErro("Area Comum não encontrada.");
                return ValidationResult;
            }            

            _areaComumRepository.Apagar(x=>x.Id == areaComumBd.Id);

            //Evento
            areaComumBd.AdicionarEvento(new AreaComumApagadaEvent(areaComumBd.Id));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(AtivarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areaComumBd = await _areaComumRepository.ObterPorId(request.Id);
            if (areaComumBd == null)
            {
                AdicionarErro("Area Comum não encontrada.");
                return ValidationResult;
            }

            areaComumBd.AtivarAreaComum();

            _areaComumRepository.Atualizar(areaComumBd);

            areaComumBd.AdicionarEvento(new AreaComumAtivadaEvent(areaComumBd.Id));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(DesativarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areaComumBd = await _areaComumRepository.ObterPorId(request.Id);
            if (areaComumBd == null)
            {
                AdicionarErro("Area Comum não encontrada.");
                return ValidationResult;
            }

            areaComumBd.DesativarAreaComum();

            _areaComumRepository.Atualizar(areaComumBd);

            areaComumBd.AdicionarEvento(new AreaComumDesativadaEvent(areaComumBd.Id));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }



        public async Task<ValidationResult> Handle(AdicionarFotoDeAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var areaComum = _areaComumRepository.ObterPorId(request.AreaComumId);
            if (areaComum == null)
            {
                AdicionarErro("Área Comum não encontrada.");
                return ValidationResult;
            }

            var fotoDaAreaComum = FotoDaAreaComumFactory(request);
            
            _areaComumRepository.AdicionarFotoDaAreaComum(fotoDaAreaComum);           

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoverFotoDaAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var fotoDaAreaComum = await _areaComumRepository.ObterFotoDaAreaComumPorId(request.Id);
            if (fotoDaAreaComum == null)
            {
                AdicionarErro("Foto não encontrada.");
                return ValidationResult;
            }

            _areaComumRepository.RemoverFotoDaAreaComum(fotoDaAreaComum);            

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }



        private AreaComum AreaComumFactory(AdicionarAreaComumCommand request)
        {
            return new AreaComum
                (request.Id, request.Nome, request.Descricao, request.TermoDeUso, request.CondominioId, request.NomeCondominio,
                 request.Capacidade, request.DiasPermitidos, request.AntecedenciaMaximaEmMeses, request.AntecedenciaMaximaEmDias,
                 request.AntecedenciaMinimaEmDias, request.AntecedenciaMinimaParaCancelamentoEmDias, request.RequerAprovacaoDeReserva,
                 request.TemHorariosEspecificos, request.TempoDeIntervaloEntreReservas, request.Ativa, request.TempoDeDuracaoDeReserva,
                 request.NumeroLimiteDeReservaPorUnidade, request.PermiteReservaSobreposta, request.NumeroLimiteDeReservaSobreposta,
                 request.NumeroLimiteDeReservaSobrepostaPorUnidade, request.TempoDeIntervaloEntreReservasPorUnidade,
                 new List<Periodo>(), new List<Reserva>());
        }

        private FotoDaAreaComum FotoDaAreaComumFactory(AdicionarFotoDeAreaComumCommand request)
        {
            return new FotoDaAreaComum(request.AreaComumId, request.CondominioId, request.Foto);
        }

        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }

    }
}
