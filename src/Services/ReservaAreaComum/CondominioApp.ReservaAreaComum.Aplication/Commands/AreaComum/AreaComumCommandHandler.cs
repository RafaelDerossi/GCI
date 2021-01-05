using CondominioApp.Core.Messages;
using CondominioApp.ReservaAreaComum.Aplication.Events;
using CondominioApp.ReservaAreaComum.Domain;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System;
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

        private IReservaAreaComumRepository _areaComumRepository;

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
                areaComum.NumeroLimiteDeReservaSobrepostaPorUnidade, areaComum.Periodos.ToList()));

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(EditarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areacomum = await _areaComumRepository.ObterPorId(request.Id);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

            areacomum.SetNome(request.Nome);
            areacomum.SetDescricao(request.Descricao);
            areacomum.SetTermoDeUso(request.TermoDeUso);
            areacomum.SetCapacidade(request.Capacidade);
            areacomum.SetDiasPermitidos(request.DiasPermitidos);
            areacomum.SetAntecedenciaMaximaEmMeses(request.AntecedenciaMaximaEmMeses);
            areacomum.SetAntecedenciaMaximaEmDias(request.AntecedenciaMaximaEmDias);
            areacomum.SetAntecedenciaMinimaEmDias(request.AntecedenciaMinimaEmDias);
            areacomum.SetAntecedenciaMinimaParaCancelamentoEmDias(request.AntecedenciaMinimaParaCancelamentoEmDias);
            areacomum.SetTempoDeIntervaloEntreReservas(request.TempoDeIntervaloEntreReservas);
            areacomum.SetTempoDeDuracaoDeReserva(request.TempoDeDuracaoDeReserva);
            areacomum.SetNumeroLimiteDeReservaPorUnidade(request.NumeroLimiteDeReservaPorUnidade);
            areacomum.SetNumeroLimiteDeReservaSobreposta(request.NumeroLimiteDeReservaSobreposta);
            areacomum.SetNumeroLimiteDeReservaSobrepostaPorUnidade(request.NumeroLimiteDeReservaSobrepostaPorUnidade);

            areacomum.DesabilitarAprovacaoDeReserva();
            if (request.RequerAprovacaoDeReserva) areacomum.HabilitarAprovacaoDeReserva();

            areacomum.DesabilitarHorariosEspecifcos();
            if (request.TemHorariosEspecificos) areacomum.HabilitarHorariosEspecifcos();

            areacomum.DesativarAreaComum();
            if (request.Ativa) areacomum.AtivarAreaComum();

            areacomum.DesabilitarReservaSobreposta();
            if (request.PermiteReservaSobreposta) areacomum.HabilitarReservaSobreposta();           
           


            if (areacomum.Periodos != null)
            {
                foreach (Periodo periodo in areacomum.Periodos)
                {
                    _areaComumRepository.RemoverPeriodo(periodo);
                }
            }
            areacomum.RemoverTodosOsPeriodos();

            if (request.Periodos == null || request.Periodos.Count() == 0)
            {
                AdicionarErro("Informe um ou mais períodos de funcionamento da area comum.");
                return ValidationResult;
            }

            foreach (Periodo periodo in request.Periodos)
            {
                var resultado = areacomum.AdicionarPeriodo(periodo);
                if (!resultado.IsValid) return resultado;
                _areaComumRepository.AdicionarPeriodo(periodo);
            }          


            _areaComumRepository.Atualizar(areacomum);

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
                request.NumeroLimiteDeReservaSobrepostaPorUnidade);
        }
        
        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }

    }
}
