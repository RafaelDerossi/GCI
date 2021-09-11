using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.ReservaAreaComum.Aplication.FilaDeReservas
{
    public class FilaDeReservaHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remover membros particulares não lidos", Justification = "<Pendente>")]
        private Timer Timer;        

        public FilaDeReservaHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(120));
            return Task.CompletedTask;
        }

        private void ExecuteProcess(object state)
        {
            using var scope = _serviceProvider.CreateScope();
            var _mediatorHandler = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
            var _reservaAreaComumRepository = scope.ServiceProvider.GetRequiredService<IReservaAreaComumRepository>();
            var _regrasDeReserva = scope.ServiceProvider.GetRequiredService<IReservaStrategy>();

            if (_reservaAreaComumRepository.ObterQtdDeReservasProcessando().Result > 0)
            {
                var reserva = _reservaAreaComumRepository.ObterPrimeiraNaFilaParaSerProcessada().Result;

                var areaComum = _reservaAreaComumRepository.ObterPorId(reserva.AreaComumId).Result;

                var retorno = areaComum.ValidarReserva(reserva, _regrasDeReserva);

                if (retorno.IsValid)
                {

                    if (areaComum.RequerAprovacaoDeReserva)
                    {
                        var comando = new AguardarAprovacaoDaReservaPelaAdmCommand(reserva.Id, "");
                        _mediatorHandler.EnviarComando(comando);                        
                    }
                        

                    if (!areaComum.RequerAprovacaoDeReserva)
                    {
                        var comando = new AprovarReservaAutomaticamenteCommand(reserva.Id, "");
                        _mediatorHandler.EnviarComando(comando);
                    }                    
                }
                
                if (!retorno.IsValid)
                {
                    if (reserva.Status == StatusReserva.NA_FILA)
                    {
                        var comando = new EnviarReservaParaFilaCommand(reserva.Id, reserva.Justificativa);
                        _mediatorHandler.EnviarComando(comando);
                    }


                    if (reserva.Status == StatusReserva.REPROVADA)
                    {
                        var comando = new ReprovarReservaAutomaticamenteCommand(reserva.Id, reserva.Justificativa);
                        _mediatorHandler.EnviarComando(comando);
                    }
                }                
            }

            Thread.Sleep(20000);

            if (_reservaAreaComumRepository.ObterQtdDeReservasAguardandoAprovacaoAteHoje().Result > 0)
            {
                var reservas = _reservaAreaComumRepository.ObterReservasAguardandoAprovacaoAteHoje().Result;

                var reserva = reservas.FirstOrDefault();

                if (reserva.EstaExpirada())
                {
                    var comando = new MarcarReservaComoExpiradaCommand(reserva.Id, "");
                    _mediatorHandler.EnviarComando(comando);                    
                }
            }

            Thread.Sleep(5000);

            if (_reservaAreaComumRepository.ObterQtdDeReservasNaFilaAteHoje().Result > 0)
            {
                var reservas = _reservaAreaComumRepository.ObterReservasNaFilaAteHoje().Result;

                var reserva = reservas.FirstOrDefault();

                if (reserva.EstaExpirada())
                {
                    var comando = new MarcarReservaComoExpiradaCommand(reserva.Id, "");
                    _mediatorHandler.EnviarComando(comando);                    
                }
            }

            Thread.Sleep(5000);

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
