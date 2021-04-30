﻿using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Mediator;
using CondominioApp.ReservaAreaComum.Aplication.Commands;
using CondominioApp.ReservaAreaComum.Domain.Interfaces;
using CondominioApp.ReservaAreaComum.Domain.ReservaStrategy;
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
        private readonly IRegrasDeReserva _regrasDeReserva;

        private Timer timer;

        public FilaDeReservaHostedService
            (IMediatorHandler mediatorHandler,
             IReservaAreaComumRepository reservaAreaComumRepository,
             IRegrasDeReserva regrasDeReserva)
        {
            _mediatorHandler = mediatorHandler;
            _reservaAreaComumRepository = reservaAreaComumRepository;
            _regrasDeReserva = regrasDeReserva;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(120));
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
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;                        
                    }
                        

                    if (!areaComum.RequerAprovacaoDeReserva)
                    {
                        var comando = new AprovarReservaAutomaticamenteCommand(reserva.Id, "");
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
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;
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
                        var Resultado = _mediatorHandler.EnviarComando(comando).Result;
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
