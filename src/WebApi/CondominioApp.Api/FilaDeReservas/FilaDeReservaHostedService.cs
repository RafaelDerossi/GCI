using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.Api.FilaDeReservas
{
    public class FilaDeReservaHostedService : IHostedService
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IReservaAreaComumRepository _reservaAreaComumRepository;

        public FilaDeReservaHostedService(IMediatorHandler mediatorHandler, IReservaAreaComumRepository reservaAreaComumRepository)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumRepository = reservaAreaComumRepository;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }

        private void ExecuteProcess(object state)
        {
            if (_reservaAreaComumRepository.ObterQtdDeReservasProcessando().Result > 0)
            {
                var reserva = _reservaAreaComumRepository.ObterPrimeiraNaFilaParaSerProcessada().Result;

                var areaComum = _reservaAreaComumRepository.ObterPorId(reserva.Id).Result;

                var retorno = areaComum.ValidarReserva(reserva);

                if (retorno.IsValid)
                {

                    if (areaComum.RequerAprovacaoDeReserva)
                    {
                        var comando = new AguardarAprovacaoDaReservaPelaAdmCommand(reserva.Id, reserva.Justificativa);
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;                        
                    }
                        

                    if (!areaComum.RequerAprovacaoDeReserva)
                    {
                        var comando = new AprovarReservaAutomaticamenteCommand(reserva.Id, reserva.Justificativa);
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;
                    }                        

                }
                
                if (!retorno.IsValid)
                {
                    switch (reserva.Status)
                    {
                        case Core.Enumeradores.StatusReserva.PROCESSANDO:
                            break;
                        case Core.Enumeradores.StatusReserva.APROVADA:
                            break;
                        case Core.Enumeradores.StatusReserva.REPROVADA:
                            break;
                        case Core.Enumeradores.StatusReserva.AGUARDANDO_APROVACAO:
                            break;
                        case Core.Enumeradores.StatusReserva.NA_FILA:
                            break;
                        case Core.Enumeradores.StatusReserva.CANCELADA:
                            break;
                        case Core.Enumeradores.StatusReserva.EXPIRADA:
                            break;
                        case Core.Enumeradores.StatusReserva.REMOVIDA:
                            break;
                        default:
                            break;
                    }
                }
            }
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
