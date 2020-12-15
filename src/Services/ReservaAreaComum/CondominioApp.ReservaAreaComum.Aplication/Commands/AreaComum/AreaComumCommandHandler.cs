using CondominioApp.Core.Messages;
using CondominioApp.Principal.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain;
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
         IDisposable
    {

        private IAreaComumRepository _areaComumRepository;

        public AreaComumCommandHandler(IAreaComumRepository areaComumRepository)
        {
            _areaComumRepository = areaComumRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var AreaComum = AreaComumFactory(request);         

            if (request.Periodos == null || request.Periodos.Count() == 0)
                AdicionarErro("Informe um Período de funcionamento para a area comum.");

            if (!ValidationResult.IsValid) return ValidationResult;

            foreach (Periodo periodo in request.Periodos)
            {
               var Result = AreaComum.AdicionarPeriodo(periodo);
                if (!Result.IsValid) return Result;
            }           

            _areaComumRepository.Adicionar(AreaComum);

           //Evento
           //

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        public async Task<ValidationResult> Handle(EditarAreaComumCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var areacomum = await _areaComumRepository.ObterPorId(request.AreaComumId);
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

            //public void HabilitarAprovacaoDeReserva() => RequerAprovacaoDeReserva = true;
            //public void DesabilitarAprovacaoDeReserva() => RequerAprovacaoDeReserva = false;

            //public void HabilitarHorariosEspecifcos() => TemHorariosEspecificos = true;
            //public void DesabilitarHorariosEspecifcos() => TemHorariosEspecificos = false;

            //public void AtivarAreaComun() => Ativa = true;
            //public void DesativarAreaComun() => Ativa = false;

            //public void HabilitarReservaSobreposta() => PermiteReservaSobreposta = true;
            //public void DesabilitarReservaSobreposta() => PermiteReservaSobreposta = false;


            if (areacomum.Unidades != null)
            {
                foreach (Unidade unidade in areacomum.Unidades)
                {
                    _ComunicadoRepository.RemoverUnidade(unidade);
                }
            }
            areacomum.RemoverTodasUnidade();

            if (areacomum.Visibilidade == VisibilidadeComunicado.UNIDADES || areacomum.Visibilidade == VisibilidadeComunicado.PROPRIETARIOS_UNIDADES)
            {
                if (request.Unidades == null || request.Unidades.Count() == 0)
                {
                    AdicionarErro("Informe uma ou mais unidades.");
                    return ValidationResult;
                }

                foreach (Unidade unidade in request.Unidades)
                {
                    var resultado = areacomum.AdicionarUnidade(unidade);
                    if (!resultado.IsValid) return resultado;
                    _ComunicadoRepository.AdicionarUnidade(unidade);
                }
            }


            _ComunicadoRepository.Atualizar(areacomum);

            return await PersistirDados(_ComunicadoRepository.UnitOfWork);
        }




        private AreaComum AreaComumFactory(CadastrarAreaComumCommand request)
        {
            return new AreaComum
                (request.Nome, request.Descricao, request.TermoDeUso, request.CondominioId, request.NomeCondominio,
                request.Capacidade, request.DiasPermitidos, request.AntecedenciaMaximaEmMeses, request.AntecedenciaMaximaEmDias,
                request.AntecedenciaMinimaEmDias, request.AntecedenciaMinimaParaCancelamentoEmDias, request.RequerAprovacaoDeReserva,
                request.TemHorariosEspecificos, request.TempoDeIntervaloEntreReservas, request.Ativa, request.TempoDeDuracaoDeReserva,
                request.NumeroLimiteDeReservaPorUnidade, request.DataInicioBloqueio, request.DataFimBloqueio,
                request.PermiteReservaSobreposta, request.NumeroLimiteDeReservaSobreposta, request.NumeroLimiteDeReservaSobrepostaPorUnidade);
        }
        
        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }

    }
}
