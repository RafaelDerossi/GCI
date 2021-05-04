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
         IRequestHandler<CadastrarAreaComumCommand, ValidationResult>,
         IRequestHandler<EditarAreaComumCommand, ValidationResult>,
         IRequestHandler<RemoverAreaComumCommand, ValidationResult>,
         IRequestHandler<AtivarAreaComumCommand, ValidationResult>,
         IRequestHandler<DesativarAreaComumCommand, ValidationResult>,
         IDisposable
    {

        private readonly IReservaAreaComumRepository _areaComumRepository;

        public AreaComumCommandHandler(IReservaAreaComumRepository areaComumRepository)
        {
            _areaComumRepository = areaComumRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarAreaComumCommand request, CancellationToken cancellationToken)
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
            areaComum.AdicionarEvento(new AreaComumCadastradaEvent
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


        public async Task<ValidationResult> Handle(EditarAreaComumCommand request, CancellationToken cancellationToken)  
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
            areaComum.AdicionarEvento(new AreaComumEditadaEvent
                (areaComum.Id, areaComum.Nome, areaComum.Descricao, areaComum.TermoDeUso, areaComum.Capacidade,
                areaComum.DiasPermitidos, areaComum.AntecedenciaMaximaEmMeses, areaComum.AntecedenciaMaximaEmDias,
                areaComum.AntecedenciaMinimaEmDias, areaComum.AntecedenciaMinimaParaCancelamentoEmDias,
                areaComum.RequerAprovacaoDeReserva, areaComum.TemHorariosEspecificos, areaComum.TempoDeIntervaloEntreReservas,
                areaComum.TempoDeDuracaoDeReserva, areaComum.NumeroLimiteDeReservaPorUnidade, areaComum.PermiteReservaSobreposta,
                areaComum.NumeroLimiteDeReservaSobreposta, areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade,
                areaComum.TempoDeIntervaloEntreReservasPorUnidade, areaComum.Periodos.ToList()));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(RemoverAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areaComumBd = await _areaComumRepository.ObterPorId(request.Id);
            if (areaComumBd == null)
            {
                AdicionarErro("Area Comum não encontrada.");
                return ValidationResult;
            }

            areaComumBd.EnviarParaLixeira();

            _areaComumRepository.Atualizar(areaComumBd);

            //Evento
            areaComumBd.AdicionarEvento(new AreaComumRemovidaEvent(areaComumBd.Id));

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



        private AreaComum AreaComumFactory(CadastrarAreaComumCommand request)
        {
            return new AreaComum
                (request.Nome, request.Descricao, request.TermoDeUso, request.CondominioId, request.NomeCondominio,
                request.Capacidade, request.DiasPermitidos, request.AntecedenciaMaximaEmMeses, request.AntecedenciaMaximaEmDias,
                request.AntecedenciaMinimaEmDias, request.AntecedenciaMinimaParaCancelamentoEmDias, request.RequerAprovacaoDeReserva,
                request.TemHorariosEspecificos, request.TempoDeIntervaloEntreReservas, request.Ativa, request.TempoDeDuracaoDeReserva,
                request.NumeroLimiteDeReservaPorUnidade, request.PermiteReservaSobreposta, request.NumeroLimiteDeReservaSobreposta,
                request.NumeroLimiteDeReservaSobrepostaPorUnidade, request.TempoDeIntervaloEntreReservasPorUnidade,
                new List<Periodo>(), new List<Reserva>());
        }
        
        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }

    }
}
