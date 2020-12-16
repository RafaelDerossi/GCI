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
    public class ReservaCommandHandler : CommandHandler,
         IRequestHandler<CadastrarReservaCommand, ValidationResult>,       
         IDisposable
    {

        private IAreaComumRepository _areaComumRepository;

        public ReservaCommandHandler(IAreaComumRepository areaComumRepository)
        {
            _areaComumRepository = areaComumRepository;
        }


        public async Task<ValidationResult> Handle(CadastrarReservaCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido()) return request.ValidationResult;

            var reserva = ReservaFactory(request);

            var areacomum = await _areaComumRepository.ObterPorId(request.AreaComumId);
            if (areacomum == null)
            {
                AdicionarErro("Area Comum não encontrada!");
                return ValidationResult;
            }

           var Result = areacomum.AdicionarReserva(reserva);

            if (!Result.IsValid) return Result;
            
            _areaComumRepository.AdicionarReserva(reserva);


           //Evento
           //

            return await PersistirDados(_areaComumRepository.UnitOfWork);
        }


        
        private Reserva ReservaFactory(CadastrarReservaCommand request)
        {
            return new Reserva
                (request.AreaComumId, request.Observacao, request.UnidadeId, request.NumeroUnidade, request.AndarUnidade,
                 request.DescricaoGrupoUnidade, request.UsuarioId, request.NomeUsuario, request.DataDeRealizacao,
                 request.HoraInicio, request.HoraFim, request.Ativa, request.Preco, request.EstaNaFila, request.Origem,
                 request.ReservadoPelaAdministracao);
        }
        
        public void Dispose()
        {
            _areaComumRepository?.Dispose();
        }

    }
}
