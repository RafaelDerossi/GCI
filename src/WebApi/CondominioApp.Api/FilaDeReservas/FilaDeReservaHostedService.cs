using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.App.Aplication.Query;
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
        private readonly IReservaAreaComumQuery _reservaAreaComumQuery;
        private Timer timer;

        public FilaDeReservaHostedService(IMediatorHandler mediatorHandler, IReservaAreaComumQuery reservaAreaComumQuery)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumQuery = reservaAreaComumQuery;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }

        private void ExecuteProcess(object state)
        {
            if (_reservaAreaComumQuery.ObterQtdDeReservasProcessando().Result > 0)
            {
                var reserva = _reservaAreaComumQuery.ObterPrimeiraNaFilaParaSerProcessada().Result;

                var areaComum = _reservaAreaComumQuery.ObterPorId(reserva.AreaComumId).Result;

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
                    if (reserva.Status == StatusReserva.NA_FILA)
                    {
                        var comando = new EnviarReservaParaFilaCommand(reserva.Id, reserva.Justificativa);
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;
                    }


                    if (reserva.Status == StatusReserva.REPROVADA)
                    {
                        var comando = new ReprovarReservaCommand(reserva.Id, reserva.Justificativa);
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;
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
