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
    public class NotificacaoEmailCondominioAppApiEventHandler : EventHandler,         
        INotificationHandler<EnviarEmailComunicadoIntegrationEvent>,
        INotificationHandler<EnviarEmailCorrespondenciaIntegrationEvent>,
        INotificationHandler<EnviarEmailEnqueteIntegrationEvent>,
        System.IDisposable
    {
        private IUsuarioQuery _usuarioQuery;
        private IPrincipalQuery _principalQuery;
        private IArquivoDigitalQuery _arquivoDigitalQuery;

        public NotificacaoEmailCondominioAppApiEventHandler
            (IUsuarioQuery usuarioQuery, IPrincipalQuery principalQuery, IArquivoDigitalQuery arquivoDigitalQuery)
        {
            _usuarioQuery = usuarioQuery;
            _principalQuery = principalQuery;
            _arquivoDigitalQuery = arquivoDigitalQuery;
        }

         
        public async Task Handle(EnviarEmailComunicadoIntegrationEvent notification, CancellationToken cancellationToken)
        {            
            var anexos = await ObterAnexosDoComunicado(notification);

            var listaDeEmails = await ObterListaDeEmailsDoComunicado(notification);

            var comunicadoDTO = ComunicadoDTOFactory(notification, anexos, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailComunicadoComAnexo(comunicadoDTO));
            await DisparadorDeEmail.Disparar();
        }

        public async Task Handle(EnviarEmailCorrespondenciaIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var listaDeEmails = await ObterListaDeEmailsDaCorrespondencia(notification);

            var correspondenciaDTO = CorrespondenciaDTOFactory(notification, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailCorrespondencia(correspondenciaDTO));
            await DisparadorDeEmail.Disparar();
        }

        public async Task Handle(EnviarEmailEnqueteIntegrationEvent notification, CancellationToken cancellationToken)
        {            
            var listaDeEmails = await ObterListaDeEmailsDaEnquete(notification);

            var enqueteDTO = EnqueteDTOFactory(notification, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailEnquete(enqueteDTO));
            await DisparadorDeEmail.Disparar();
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
        private List<string> ObterEmailsDaLista(IEnumerable<FuncionarioFlat> funcionarios)
        {
            var listaDeEmails = new List<string>();
            if (funcionarios != null)
            {
                foreach (var funcionario in funcionarios)
                {
                    if (!string.IsNullOrEmpty(funcionario.Email))
                        listaDeEmails.Add(funcionario.Email);
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
            (EnviarEmailComunicadoIntegrationEvent notification, List<ArquivoDTO> anexos,
            List<string> listaDeEmails)
        {
           var condominio =  _principalQuery.ObterPorId(notification.CondominioId).Result;

           return new ComunicadoDTO
               (notification.Titulo, notification.Descricao, notification.Categoria,
                notification.TemAnexos, condominio.Id, condominio.LogoMarca, anexos, listaDeEmails);
        }



        private async Task<List<string>> ObterListaDeEmailsDaCorrespondencia(EnviarEmailCorrespondenciaIntegrationEvent notification)
        {
            var moradores = await _usuarioQuery.ObterMoradoresPorUnidadeId(notification.UnidadeId);
            return ObterEmailsDaLista(moradores);
        }
        private CorrespondenciaDTO CorrespondenciaDTOFactory
           (EnviarEmailCorrespondenciaIntegrationEvent notification, List<string> listaDeEmails)
        {
            var unidade = _principalQuery.ObterUnidadePorId(notification.UnidadeId).Result;

            return new CorrespondenciaDTO
                (notification.Assunto, notification.Titulo, notification.Descricao, unidade.CondominioLogoMarca, listaDeEmails);
        }




        private async Task<List<string>> ObterListaDeEmailsDaEnquete(EnviarEmailEnqueteIntegrationEvent notification)
        {
            IEnumerable<MoradorFlat> moradores = new List<MoradorFlat>();
            if (notification.ApenasProprietarios)
                moradores = await _usuarioQuery.ObterProprietariosPorCondominioId(notification.CondominioId);

            if (!notification.ApenasProprietarios)
                moradores = await _usuarioQuery.ObterMoradoresPorCondominioId(notification.CondominioId);

            var listaDeEmails = ObterEmailsDaLista(moradores);

            var sindico = await _usuarioQuery.ObterSindicoPorCondominioId(notification.CondominioId);
            if (sindico != null)
            {
                var usuario = await _usuarioQuery.ObterPorId(sindico.UsuarioId);
                listaDeEmails.Add(usuario.Email.Endereco);
            }

            return listaDeEmails;
        }
        private EnqueteDTO EnqueteDTOFactory
          (EnviarEmailEnqueteIntegrationEvent notification, List<string> listaDeEmails)
        {
            var condominio = _principalQuery.ObterPorId(notification.CondominioId).Result;

            return new EnqueteDTO
                (notification.Descricao, notification.DataInicio, notification.DataFim, condominio.Nome, 
                 condominio.LogoMarca, notification.NomeFuncionario, listaDeEmails);
        }

        public void Dispose()
        {
            _usuarioQuery?.Dispose();
        }        
    }
}
