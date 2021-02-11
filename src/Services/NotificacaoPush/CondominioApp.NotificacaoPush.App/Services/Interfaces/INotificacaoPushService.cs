using CondominioApp.NotificacaoPush.App.DTO;
using FluentValidation.Results;

namespace CondominioApp.NotificacaoPush.App.Services.Interfaces
{
   public interface INotificacaoPushService
   {

        ValidationResult AdcionarDispositivo(DispositivoDTO dispositivo);

        ValidationResult CriarNotificacao(NotificacaoPushDTO notificacao);
    }
}
