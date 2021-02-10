using CondominioApp.NotificacaoPush.App.DTO;

namespace CondominioApp.NotificacaoPush.App.Services.Interfaces
{
   public interface INotificacaoPushService
   {      

        void AdcionarDispositivo(DispositivoDTO dispositivo);

        void CriarNotificacao(NotificacaoPushDTO push);
    }
}
