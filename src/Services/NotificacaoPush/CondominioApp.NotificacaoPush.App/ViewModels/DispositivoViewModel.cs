using CondominioApp.OneSignal.Recursos.Dispositivos.Enuns;

namespace CondominioApp.NotificacaoPush.App.ViewModel
{
   public class DispositivoViewModel
    {
        public string Identificador { get; set; }

        public string CodigoDaLingua { get; set; }

        public string Modelo { get; set; }

        public string SOdoDispositivo { get; set; }

        public TipoDeDispositivo TipoDoDispositivo { get; set; }
        
    }
}
