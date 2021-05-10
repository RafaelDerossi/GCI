using CondominioApp.Core.Messages;
using CondominioApp.NotificacaoPush.App.DTO;
using CondominioApp.NotificacaoPush.App.OneSignalApps;
using CondominioApp.NotificacaoPush.App.Services.Interfaces;
using CondominioApp.OneSignal.Recursos;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.Models;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CondominioApp.NotificacaoPush.App.Aplication.Commands
{
    public class NotificacaoPushCommandHandler : CommandHandler,
         IRequestHandler<EnviarNotificacaoParaTodosNoCondominioCommand, ValidationResult>,         
         IDisposable
    {

        private readonly IUsuarioQuery _usuarioQueryRepository;
        private readonly INotificacaoPushService _notificacaoPushService;

        public NotificacaoPushCommandHandler(IUsuarioQuery usuarioQueryRepository, INotificacaoPushService notificacaoPushService)
        {
            _usuarioQueryRepository = usuarioQueryRepository;
            _notificacaoPushService = notificacaoPushService;
        }

        public async Task<ValidationResult> Handle(EnviarNotificacaoParaTodosNoCondominioCommand request, CancellationToken cancellationToken)
        {
            if (!request.EstaValido())
                return request.ValidationResult;

            var dispositivosIds = await ObterDispositivosIds(request.CondominioId);

            var notificacaoDTO = new NotificacaoPushDTO(new MoradorOneSignalApp(), dispositivosIds);

            notificacaoDTO.AdicionarMensagem(CodigosDeLingua.English, request.Titulo, request.Conteudo);

            _notificacaoPushService.CriarNotificacao(notificacaoDTO);

            return ValidationResult;
        }
        private async Task<List<string>> ObterDispositivosIds(System.Guid condominioId)
        {
            var moradores = await _usuarioQueryRepository.ObterMoradoresPorCondominioId(condominioId);

            var dispositivosIds = new List<string>();

            foreach (var morador in moradores)
            {
                var dispositivos = await _usuarioQueryRepository.ObterMobilesPorMoradorFuncionarioId(morador.Id);
                foreach (Mobile dispositivo in dispositivos)
                {
                    dispositivosIds.Add(dispositivo.DeviceKey.ToString());
                }
            }

            return dispositivosIds;
        }


        public void Dispose()
        {
            _usuarioQueryRepository?.Dispose();
        }


    }
}
