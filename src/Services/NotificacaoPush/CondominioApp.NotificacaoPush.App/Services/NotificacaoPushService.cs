using CondominioApp.NotificacaoPush.App.DTO;
using CondominioApp.NotificacaoPush.App.Services.Interfaces;
using CondominioApp.OneSignal;
using CondominioApp.OneSignal.Recursos.Dispositivos;
using CondominioApp.OneSignal.Recursos.Notificacoes;
using FluentValidation.Results;

namespace CondominioApp.NotificacaoPush.App.Services
{
    public class NotificacaoPushService : INotificacaoPushService
    {
        private IOneSignalClient _OneSignalClient;


        public ValidationResult AdcionarDispositivo(DispositivoDTO dispositivo)
        {
            _OneSignalClient = new OneSignalClient(dispositivo.AppOneSignal.ApiKey);

            var opcoes = new OpcoesDoAdicionarDispositvo();

            opcoes.AppId = dispositivo.AppOneSignal.AppId;
            opcoes.Identificador = dispositivo.Identificador;
            opcoes.Lingua = dispositivo.CodigoDaLingua;
            opcoes.ModeloDoDispositivo = dispositivo.Modelo;
            opcoes.SODoDispositivo = dispositivo.SOdoDispositivo;
            opcoes.TipoDoDispositivo = dispositivo.TipoDoDispositivo;
            
            RetornoDoAdicionarDispositivo retorno = _OneSignalClient.Devices.Adicionar(opcoes);

            return retorno.ValidationResult;
        }

        public ValidationResult CriarNotificacao(NotificacaoPushDTO notificacao)
        {
            _OneSignalClient = new OneSignalClient(notificacao.AppOneSignal.ApiKey);

            var opcoes = new OpcoesDoCriarNotificacao();
                                    
            opcoes.AppId = notificacao.AppOneSignal.AppId;
            opcoes.Titulos = notificacao.Titulos;
            opcoes.Conteudo = notificacao.Conteudo;
            opcoes.IncluirIdsDePlayers = notificacao.DispositivosIds;

            RetornoDoCriarNotificacao retorno = _OneSignalClient.Notifications.Criar(opcoes);

            return retorno.ValidationResult;

        }
    }
}
