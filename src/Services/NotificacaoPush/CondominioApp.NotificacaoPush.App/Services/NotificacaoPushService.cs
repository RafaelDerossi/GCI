using CondominioApp.Core.Helpers;
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

            var opcoes = new OpcoesDoAdicionarDispositvo
            {
                AppId = dispositivo.AppOneSignal.AppId,
                Identificador = dispositivo.Identificador,
                Lingua = dispositivo.CodigoDaLingua,
                ModeloDoDispositivo = dispositivo.Modelo,
                SODoDispositivo = dispositivo.SOdoDispositivo,
                TipoDoDispositivo = dispositivo.TipoDoDispositivo
            };

            RetornoDoAdicionarDispositivo retorno = _OneSignalClient.Devices.Adicionar(opcoes);

            return retorno.ValidationResult;
        }

        public ValidationResult CriarNotificacao(NotificacaoPushDTO notificacao)
        {
            _OneSignalClient = new OneSignalClient(notificacao.AppOneSignal.ApiKey);

            var opcoes = new OpcoesDoCriarNotificacao
            {
                AppId = notificacao.AppOneSignal.AppId,
                Titulos = notificacao.Titulos
            };

            foreach (var item in notificacao.Conteudo)
            {
                opcoes.Conteudo.Add(item.Key, RemoverHTML.RemoverHTMLdeString(item.Value));
            }

            opcoes.IncluirIdsDePlayers = notificacao.DispositivosIds;

            RetornoDoCriarNotificacao retorno = _OneSignalClient.Notifications.Criar(opcoes);

            return retorno.ValidationResult;

        }

    }
}
