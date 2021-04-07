using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.ArquivoDigital.App.Aplication.Query;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.NotificacaoEmail.Api.Email;
using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using MediatR;
using System.Linq;


namespace CondominioApp.NotificacaoEmail.Aplication.Events
{
    public class NotificacaoEmailEventHandler : EventHandler, 
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent>,
        INotificationHandler<EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent>,
        INotificationHandler<EnviarEmailComunicadoIntegrationEvent>,
        System.IDisposable
    {
        private IUsuarioQuery _usuarioQuery;
        private IPrincipalQuery _principalQuery;
        private IArquivoDigitalQuery _arquivoDigitalQuery;

        public NotificacaoEmailEventHandler
            (IUsuarioQuery usuarioQuery, IPrincipalQuery principalQuery, IArquivoDigitalQuery arquivoDigitalQuery)
        {
            _usuarioQuery = usuarioQuery;
            _principalQuery = principalQuery;
            _arquivoDigitalQuery = arquivoDigitalQuery;
        }



        #region Usuario
        public async Task Handle(EnviarEmailConfirmacaoDeCadastroDeUsuarioIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioQuery.ObterPorId(notification.UsuarioId);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeUsuario(usuario));
            await DisparadorDeEmail.Disparar();
        }

        public async Task Handle(EnviarEmailConfirmacaoDeCadastroDeMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(notification.MoradorId);

            var condominio = await _principalQuery.ObterPorId(morador.CondominioId);

            var logoCondominio = condominio.LogoMarca; //"https://condominioappstorage.blob.core.windows.net/condominioapp/Uploads/usuario/572d0886-11c4-4fb3-b806-0d7cf6695bc8.png";

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailConfirmacaoDeCadastroDeMorador(morador, logoCondominio));
            await DisparadorDeEmail.Disparar();
        }

        #endregion



        #region Comunicado
        public async Task Handle(EnviarEmailComunicadoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var condominioDTO = await CondominioDTOFactory(notification.CondominioId);

            var anexos = await ObterAnexosDoComunicado(notification);

            var listaDeEmails = await ObterListaDeEmailsDoComunicado(notification);

            var comunicadoDTO = ComunicadoDTOFactory(notification, condominioDTO, anexos, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailComunicadoComAnexo(comunicadoDTO));
            await DisparadorDeEmail.Disparar();
        }


        private async Task<CondominioDTO> CondominioDTOFactory(System.Guid condominioId)
        {
            var condominioFlat = await _principalQuery.ObterPorId(condominioId);

            return new CondominioDTO
                (condominioFlat.Id, condominioFlat.Nome, condominioFlat.Descricao,
                 condominioFlat.LogoMarca, condominioFlat.Telefone);            
        }

        private async Task<List<ArquivoDTO>> ObterAnexosDoComunicado(EnviarEmailComunicadoIntegrationEvent notification)
        {
            var anexos = new List<ArquivoDTO>();
            if (!notification.TemAnexos)
                return anexos;

            var arquivos = await _arquivoDigitalQuery.ObterArquivosPorAnexadoPorId(notification.Id);
            foreach (var arq in arquivos)
            {
                var arquivo = new ArquivoDTO(arq.Nome.NomeDoArquivo, arq.Nome.ExtensaoDoArquivo);
                anexos.Add(arquivo);
            }

            return anexos;
        }

        private async Task<List<string>> ObterListaDeEmailsDoComunicado(EnviarEmailComunicadoIntegrationEvent notification)
        {
            switch (notification.Visibilidade)
            {
                case VisibilidadeComunicado.PROPRIETARIOS:
                    var moradores = await _usuarioQuery.ObterProprietariosPorCondominioId(notification.CondominioId);
                    return ObterEmailsDaLista(moradores);

                case VisibilidadeComunicado.PROPRIETARIOS_UNIDADES:
                    moradores = ObterMoradoresDasUnidades(notification.UnidadesIds, true);
                    return ObterEmailsDaLista(moradores);
                    
                case VisibilidadeComunicado.UNIDADES:
                    moradores = ObterMoradoresDasUnidades(notification.UnidadesIds, false);
                    return ObterEmailsDaLista(moradores);

                default:
                    moradores = await _usuarioQuery.ObterMoradoresPorCondominioId(notification.CondominioId);
                    return ObterEmailsDaLista(moradores);
            }
        }

        private List<string> ObterEmailsDaLista(IEnumerable<MoradorFlat> moradores)
        {
            var listaDeEmails = new List<string>();
            if (moradores != null)
            {
                foreach (var morador in moradores)
                {
                    if (!string.IsNullOrEmpty(morador.Email))
                        listaDeEmails.Add(morador.Email);
                }
            }
            return listaDeEmails;
        }

        private IEnumerable<MoradorFlat> ObterMoradoresDasUnidades(IEnumerable<System.Guid> unidades, bool proprietarios)
        {
            var moradores = new List<MoradorFlat>();

            if (unidades.Count() > 0)
            {
                if (proprietarios)
                {
                    foreach (var unidadeId in unidades)
                    {
                        var moradoresDaUnidade = _usuarioQuery.ObterProprietariosPorUnidadeId(unidadeId).Result;

                        if (moradoresDaUnidade != null)
                        {
                            foreach (var morador in moradoresDaUnidade)
                            {
                                moradores.Add(morador);
                            }
                        }
                    }
                    return moradores;
                }
                
                foreach (var unidadeId in unidades)
                {
                    var moradoresDaUnidade = _usuarioQuery.ObterMoradoresPorUnidadeId(unidadeId).Result;
                    
                    if (moradoresDaUnidade != null)
                    {
                        foreach (var morador in moradoresDaUnidade)
                        {
                            moradores.Add(morador);
                        }
                    }
                    return moradores;
                }
            }

            return moradores;
        }

        private ComunicadoDTO ComunicadoDTOFactory
            (EnviarEmailComunicadoIntegrationEvent notification, CondominioDTO condominioDTO,
            List<ArquivoDTO> anexos, List<string> listaDeEmails)
        {
           return new ComunicadoDTO
               (notification.Id, notification.DataDeCadastro, notification.Titulo, notification.Descricao, notification.DataDeRealizacao,
                notification.NomeFuncionario, notification.Categoria, notification.TemAnexos,
                condominioDTO, anexos, listaDeEmails);
        }

        #endregion

        public void Dispose()
        {
            _usuarioQuery?.Dispose();
        }        
    }
}
