using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CondominioApp.ArquivoDigital.App.Aplication.Query;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages;
using CondominioApp.NotificacaoEmail.Api.Email;
using CondominioApp.NotificacaoEmail.App.DTO;
using CondominioApp.NotificacaoEmail.App.Service;
using CondominioApp.Principal.Aplication.Query.Interfaces;
using CondominioApp.Usuarios.App.Aplication.Query;
using CondominioApp.Usuarios.App.FlatModel;
using MediatR;
using System.Linq;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Comunicado;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Correspondencia;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Enquete;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Reserva;

namespace CondominioApp.NotificacaoEmail.Aplication.Events
{
    public class NotificacaoEmailCondominioAppApiEventHandler : EventHandler,         
        INotificationHandler<EnviarEmailComunicadoIntegrationEvent>,
        INotificationHandler<EnviarEmailCorrespondenciaIntegrationEvent>,
        INotificationHandler<EnviarEmailEnqueteIntegrationEvent>,
        INotificationHandler<EnviarEmailOcorrenciaIntegrationEvent>,
        INotificationHandler<EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent>,
        INotificationHandler<EnviarEmailRespostaOcorrenciaParaAdministracaoIntegrationEvent>,
        INotificationHandler<EnviarEmailReservaParaMoradorIntegrationEvent>,
        INotificationHandler<EnviarEmailReservaParaAdministracaoIntegrationEvent>,
        System.IDisposable
    {
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly IPrincipalQuery _principalQuery;
        private readonly IArquivoDigitalQuery _arquivoDigitalQuery;

        public NotificacaoEmailCondominioAppApiEventHandler
            (IUsuarioQuery usuarioQuery, IPrincipalQuery principalQuery, IArquivoDigitalQuery arquivoDigitalQuery)
        {
            _usuarioQuery = usuarioQuery;
            _principalQuery = principalQuery;
            _arquivoDigitalQuery = arquivoDigitalQuery;
        }


        #region Comunicado
        
        public async Task Handle(EnviarEmailComunicadoIntegrationEvent notification, CancellationToken cancellationToken)
        {            
            var anexos = await ObterAnexosDoComunicado(notification);

            var listaDeEmails = await ObterListaDeEmailsDoComunicado(notification);

            var comunicadoDTO = ComunicadoDTOFactory(notification, anexos, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailComunicadoComAnexo(comunicadoDTO));
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
                    return ObterEmailsDaListaDeMoradores(moradores);

                case VisibilidadeComunicado.PROPRIETARIOS_UNIDADES:
                    moradores = ObterMoradoresDasUnidades(notification.UnidadesIds, true);
                    return ObterEmailsDaListaDeMoradores(moradores);

                case VisibilidadeComunicado.UNIDADES:
                    moradores = ObterMoradoresDasUnidades(notification.UnidadesIds, false);
                    return ObterEmailsDaListaDeMoradores(moradores);

                default:
                    moradores = await _usuarioQuery.ObterMoradoresPorCondominioId(notification.CondominioId);
                    return ObterEmailsDaListaDeMoradores(moradores);
            }
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
            var condominio = _principalQuery.ObterPorId(notification.CondominioId).Result;

            return new ComunicadoDTO
                (notification.Titulo, notification.Descricao, notification.Categoria,
                 notification.TemAnexos, condominio.Id, condominio.LogoMarca, anexos, listaDeEmails);
        }

        #endregion



        #region Correspondencia
        public async Task Handle(EnviarEmailCorrespondenciaIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var listaDeEmails = await ObterListaDeEmailsDaCorrespondencia(notification);

            var correspondenciaDTO = CorrespondenciaDTOFactory(notification, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailCorrespondencia(correspondenciaDTO));
            await DisparadorDeEmail.Disparar();
        }
        private async Task<List<string>> ObterListaDeEmailsDaCorrespondencia(EnviarEmailCorrespondenciaIntegrationEvent notification)
        {
            var moradores = await _usuarioQuery.ObterMoradoresPorUnidadeId(notification.UnidadeId);
            return ObterEmailsDaListaDeMoradores(moradores);
        }
        private CorrespondenciaDTO CorrespondenciaDTOFactory
           (EnviarEmailCorrespondenciaIntegrationEvent notification, List<string> listaDeEmails)
        {
            var unidade = _principalQuery.ObterUnidadePorId(notification.UnidadeId).Result;

            return new CorrespondenciaDTO
                (notification.Assunto, notification.Titulo, notification.Descricao, unidade.CondominioLogoMarca, listaDeEmails);
        }

        #endregion



        #region Enquete
        public async Task Handle(EnviarEmailEnqueteIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var listaDeEmails = await ObterListaDeEmailsDaEnquete(notification);

            var enqueteDTO = EnqueteDTOFactory(notification, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailEnquete(enqueteDTO));
            await DisparadorDeEmail.Disparar();
        }
        private async Task<List<string>> ObterListaDeEmailsDaEnquete(EnviarEmailEnqueteIntegrationEvent notification)
        {
            IEnumerable<MoradorFlat> moradores = new List<MoradorFlat>();
            if (notification.ApenasProprietarios)
                moradores = await _usuarioQuery.ObterProprietariosPorCondominioId(notification.CondominioId);

            if (!notification.ApenasProprietarios)
                moradores = await _usuarioQuery.ObterMoradoresPorCondominioId(notification.CondominioId);

            var listaDeEmails = ObterEmailsDaListaDeMoradores(moradores);

            var administradores = await _usuarioQuery.ObterFuncionariosAdmPorCondominioId(notification.CondominioId);
            if (administradores != null)
            {
                var listaDeEmailsAdministracao = ObterEmailsDaListaDeFuncionarios(administradores);
                foreach (var email in listaDeEmailsAdministracao)
                {
                    listaDeEmails.Add(email);
                }
            }

            return listaDeEmails;
        }
        private EnqueteDTO EnqueteDTOFactory
          (EnviarEmailEnqueteIntegrationEvent notification, List<string> listaDeEmails)
        {
            var condominio = _principalQuery.ObterPorId(notification.CondominioId).Result;

            return new EnqueteDTO
                (notification.Descricao, notification.DataInicio, notification.DataFim, condominio.Nome,
                 condominio.LogoMarca, notification.NomeFuncionario, notification.Alternativas, listaDeEmails);
        }

        #endregion




        #region Ocorrencia

        public async Task Handle(EnviarEmailOcorrenciaIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var listaDeEmails = await ObterListaDeEmailsDaOcorrencia(notification);

            var ocorrenciaDTO = OcorrenciaDTOFactory(notification, listaDeEmails);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailOcorrencia(ocorrenciaDTO));
            await DisparadorDeEmail.Disparar();
        }
        private async Task<List<string>> ObterListaDeEmailsDaOcorrencia(EnviarEmailOcorrenciaIntegrationEvent notification)
        {
            var listaDeEmails = new List<string>();

            var unidade = await _principalQuery.ObterUnidadePorId(notification.UnidadeId);

            var administradores = await _usuarioQuery.ObterFuncionariosAdmPorCondominioId(unidade.CondominioId);
            if (administradores != null)
            {
                listaDeEmails = ObterEmailsDaListaDeFuncionarios(administradores);
            }

            return listaDeEmails;
        }
        private OcorrenciaDTO OcorrenciaDTOFactory
         (EnviarEmailOcorrenciaIntegrationEvent notification, List<string> listaDeEmails)
        {
            var unidade = _principalQuery.ObterUnidadePorId(notification.UnidadeId).Result;

            return new OcorrenciaDTO
                (notification.Titulo, notification.Descricao, notification.NomeMorador,
                 unidade.ObterDescricaoUnidade(), notification.StatusPrivacidade, notification.StatusOcorrencia,
                 notification.DataDeCadastro, notification.Foto, unidade.CondominioNome, unidade.CondominioLogoMarca,
                 listaDeEmails);
        }

        #endregion


        #region Resposta Ocorrencia

        public async Task Handle(EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(notification.moradorId);
            var listaDeEmails = new List<string>
            {
                morador.Email
            };

            var respostaOcorrenciaDTO = RespostaOcorrenciaDTOFactory(notification, listaDeEmails, morador.CondominioId);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailRespostaOcorrencia(respostaOcorrenciaDTO));
            await DisparadorDeEmail.Disparar();
        }
        public async Task Handle(EnviarEmailRespostaOcorrenciaParaAdministracaoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var listaDeEmails = new List<string>();

            var administradores = await _usuarioQuery.ObterFuncionariosAdmPorCondominioId(notification.CondominioId);
            if (administradores != null)
            {
                listaDeEmails = ObterEmailsDaListaDeFuncionarios(administradores);
            }

            var respostaOcorrenciaDTO = RespostaOcorrenciaDTOFactory(notification, listaDeEmails, notification.CondominioId);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailRespostaOcorrencia(respostaOcorrenciaDTO));
            await DisparadorDeEmail.Disparar();
        }
        private RespostaOcorrenciaDTO RespostaOcorrenciaDTOFactory
       (EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent notification, List<string> listaDeEmails, System.Guid condominioId)
        {
            var condominio = _principalQuery.ObterPorId(condominioId).Result;

            return new RespostaOcorrenciaDTO
                (notification.Titulo, notification.DescricaoDaOcorrencia, notification.Resposta,
                 notification.NomeSindico, notification.DataDaResposta,
                 notification.Foto, condominio.Nome, condominio.LogoMarca, listaDeEmails);
        }
        private RespostaOcorrenciaDTO RespostaOcorrenciaDTOFactory
       (EnviarEmailRespostaOcorrenciaParaAdministracaoIntegrationEvent notification, List<string> listaDeEmails, System.Guid condominioId)
        {
            var condominio = _principalQuery.ObterPorId(condominioId).Result;

            return new RespostaOcorrenciaDTO
                (notification.Titulo, notification.DescricaoDaOcorrencia, notification.Resposta,
                 notification.NomeMorador, notification.DataDaResposta,
                 notification.Foto, condominio.Nome, condominio.LogoMarca, listaDeEmails);
        }


        #endregion



        #region Reserva

        public async Task Handle(EnviarEmailReservaParaMoradorIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(notification.MoradorId);
            var listaDeEmails = new List<string>
            {
                morador.Email
            };

            var reservaDTO = ReservaDTOParaMoradorFactory(notification, listaDeEmails, morador);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailReserva(reservaDTO));
            await DisparadorDeEmail.Disparar();
        }
        private ReservaDTO ReservaDTOParaMoradorFactory
         (EnviarEmailReservaParaMoradorIntegrationEvent notification, List<string> listaDeEmails, MoradorFlat morador)
        {
            var condominio = _principalQuery.ObterPorId(notification.CondominioId).Result;
            return new ReservaDTO
                (notification.Titulo, notification.AreaComumNome, notification.DataRealizacao,
                 notification.HoraInicio, notification.HoraFim, morador.NomeCompleto, notification.UnidadeDescricao,
                 notification.Valor, notification.Observacao, notification.Justificativa, notification.DataDeCadastro,
                 condominio.Nome, condominio.LogoMarca, listaDeEmails, notification.CorFundoTitulo);

        }


        public async Task Handle(EnviarEmailReservaParaAdministracaoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var morador = await _usuarioQuery.ObterMoradorPorId(notification.MoradorId);

            var listaDeEmails = new List<string>();

            var administradores = await _usuarioQuery.ObterFuncionariosAdmPorCondominioId(notification.CondominioId);
            if (administradores != null)
            {
                listaDeEmails = ObterEmailsDaListaDeFuncionarios(administradores);
            }

            var reservaDTO = ReservaDTOParaAdministracaoFactory(notification, listaDeEmails, morador);

            var DisparadorDeEmail = new DisparadorDeEmails(new EmailReserva(reservaDTO));
            await DisparadorDeEmail.Disparar();
        }
        private ReservaDTO ReservaDTOParaAdministracaoFactory
         (EnviarEmailReservaParaAdministracaoIntegrationEvent notification, List<string> listaDeEmails, MoradorFlat morador)
        {
            var condominio = _principalQuery.ObterPorId(notification.CondominioId).Result;

            return new ReservaDTO
                (notification.Titulo, notification.AreaComumNome, notification.DataRealizacao,
                 notification.HoraInicio, notification.HoraFim, morador.NomeCompleto, notification.UnidadeDescricao,
                 notification.Valor, notification.Observacao, notification.Justificativa, notification.DataDeCadastro,
                 condominio.Nome, condominio.LogoMarca, listaDeEmails, notification.CorFundoTitulo);
        }


        #endregion





        private List<string> ObterEmailsDaListaDeMoradores(IEnumerable<MoradorFlat> moradores)
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
        private List<string> ObterEmailsDaListaDeFuncionarios(IEnumerable<FuncionarioFlat> funcionarios)
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



        public void Dispose()
        {
            _usuarioQuery?.Dispose();
        }        

    }
}
