using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents;
using CondominioApp.Ocorrencias.App.ValueObjects;
using FluentValidation.Results;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
  public class RespostaOcorrencia : Entity
    {
        public Guid OcorrenciaId { get; private set; }        

        public string Descricao { get; private set; }

        public TipoDoAutor TipoAutor  { get; private set; }

        public Guid AutorId { get; private set; }

        public string NomeDoAutor { get; private set; }

        public bool Visto { get; private set; }

        public Foto Foto { get; private set; }

        public NomeArquivo ArquivoAxexo { get; private set; }

        public RespostaOcorrencia()
        {
        }

        public RespostaOcorrencia
            (Guid ocorrenciaId, string descricao, TipoDoAutor tipoAutor, Guid autorId,
             string nomeDoAutor, bool visto, Foto foto, NomeArquivo arquivoAnexo)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = tipoAutor;
            AutorId = autorId;
            NomeDoAutor = nomeDoAutor;
            Visto = visto;
            Foto = foto;
            ArquivoAxexo = arquivoAnexo;
        }

        public void MarcarComoVisto() => Visto = true;

        public void SetMoradorIdFuncionarioId(Guid id) => AutorId = id;


        public ValidationResult Editar(string descricao, Foto foto, Guid autorId)
        {
            if (AutorId != autorId)
            {
                AdicionarErrosDaEntidade("Usuário não corresponde ao que criou a resposta.");
                return ValidationResult;
            }

            if (Visto)
            {
                AdicionarErrosDaEntidade("Resposta não pode mais ser editada.");
                return ValidationResult;
            }

            Descricao = descricao;          

            return ValidationResult;
        }



        public void EnviarPushParaMorador(Guid moradorId, StatusDaOcorrencia statusDaOcorrencia)
        {
            if (statusDaOcorrencia == StatusDaOcorrencia.EM_ANDAMENTO)
                EnviarPushOcorrenciaEmAndamento(moradorId);

            if (statusDaOcorrencia == StatusDaOcorrencia.RESOLVIDA)
                EnviarPushOcorrenciaResolvida(moradorId);
        }

        private void EnviarPushOcorrenciaEmAndamento(Guid moradorId)
        {
            var titulo = "Ocorrência em Andamento";

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(moradorId, titulo, Descricao));
        }

        private void EnviarPushOcorrenciaResolvida(Guid moradorId)
        {
            var titulo = "Ocorrência Resolvida";

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(moradorId, titulo, Descricao));
        }

        public void EnviarPushParaAdministracao(Guid condominioId)
        {
            var titulo = "Ocorrência Respondida";

            AdicionarEvento
                (new EnviarPushParaAdministracaoIntegrationEvent(condominioId, titulo, Descricao));
        }





        public void EnviarEmailParaMorador(Guid moradorId, StatusDaOcorrencia statusDaOcorrencia, string descricaoDaOcorrencia)
        {
            if (statusDaOcorrencia == StatusDaOcorrencia.EM_ANDAMENTO)
                EnviarEmailOcorrenciaEmAndamento(moradorId, descricaoDaOcorrencia);

            if (statusDaOcorrencia == StatusDaOcorrencia.RESOLVIDA)
                EnviarEmailOcorrenciaResolvida(moradorId, descricaoDaOcorrencia);
        }
        private void EnviarEmailOcorrenciaEmAndamento(Guid moradorId, string descricaoDaOcorrencia)
        {
            var titulo = "Ocorrência em Andamento";

            AdicionarEvento
                (new EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent
                (titulo, descricaoDaOcorrencia, Descricao, NomeDoAutor, 
                 DataDeCadastroFormatada, Foto.NomeDoArquivo, moradorId));
        }
        private void EnviarEmailOcorrenciaResolvida(Guid moradorId, string descricaoDaOcorrencia)
        {
            var titulo = "Ocorrência Resolvida";

            AdicionarEvento
                (new EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent
                (titulo, descricaoDaOcorrencia, Descricao, NomeDoAutor,
                 DataDeCadastroFormatada, Foto.NomeDoArquivo, moradorId));
        }

        
        
        public void EnviarEmailParaAdministracao(Guid condominioId, StatusDaOcorrencia statusDaOcorrencia, string descricaoDaOcorrencia)
        {
            var titulo = "Ocorrência Respondida";

            AdicionarEvento
                (new EnviarEmailRespostaOcorrenciaParaAdministracaoIntegrationEvent
                (titulo, descricaoDaOcorrencia, Descricao, NomeDoAutor, statusDaOcorrencia.ToString(),
                 DataDeCadastroFormatada, Foto.NomeDoArquivo, condominioId));
        }
                
    } 
}
