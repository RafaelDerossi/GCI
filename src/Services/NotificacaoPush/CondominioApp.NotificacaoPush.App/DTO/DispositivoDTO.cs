using CondominioApp.NotificacaoPush.App.OneSignalApps;
using CondominioApp.OneSignal.Recursos.Dispositivos.Enuns;

namespace CondominioApp.NotificacaoPush.App.DTO
{
   public class DispositivoDTO
    {
        public IOneSignalApp AppOneSignal { get; set; }

        public string Identificador { get; set; }

        public string CodigoDaLingua { get; set; }

        public string Modelo { get; set; }

        public string SOdoDispositivo { get; set; }

        public TipoDeDispositivo TipoDoDispositivo { get; set; }
        
    }
}
