using CondominioApp.OneSignal.Recursos.Dispositivos;
using CondominioApp.OneSignal.Recursos.Notificacoes;

namespace CondominioApp.OneSignal
{
   public interface IOneSignalClient
    {
        IRecursosDeDispositivo Devices { get; }

        IRecursosDeNotificacao Notifications { get; }
    }
}
