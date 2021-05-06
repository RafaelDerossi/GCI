using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservasStrategy;
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
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IReservaAreaComumRepository _reservaAreaComumRepository;
        private readonly IReservaStrategy _regrasDeReserva;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:Remover membros particulares não lidos", Justification = "<Pendente>")]
        private Timer Timer;        

        public FilaDeReservaHostedService
            (IMediatorHandler mediatorHandler,
             IReservaAreaComumRepository reservaAreaComumRepository,
             IReservaStrategy regrasDeReserva)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumRepository = reservaAreaComumRepository;
            _regrasDeReserva = regrasDeReserva;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Timer = new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(120));
            return Task.CompletedTask;
        }

        private void ExecuteProcess(object state)
        {
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

                Thread.Sleep(2000);
            }


            if (_reservaAreaComumRepository.ObterQtdDeReservasAguardandoAprovacaoAteHoje().Result > 0)
            {
                var reservas = _reservaAreaComumRepository.ObterReservasAguardandoAprovacaoAteHoje().Result;

                foreach (var reserva in reservas)
                {
                    if (reserva.EstaExpirada())
                    {
                        var comando = new MarcarReservaComoExpiradaCommand(reserva.Id, "");
                        _mediatorHandler.EnviarComando(comando);
                        Thread.Sleep(2000);
                    }
                }
            }


            if (_reservaAreaComumRepository.ObterQtdDeReservasNaFilaAteHoje().Result > 0)
            {
                var reservas = _reservaAreaComumRepository.ObterReservasNaFilaAteHoje().Result;

                foreach (var reserva in reservas)
                {
                    if (reserva.EstaExpirada())
                    {
                        var comando = new MarcarReservaComoExpiradaCommand(reserva.Id, "");
                        _mediatorHandler.EnviarComando(comando);
                        Thread.Sleep(2000);
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
