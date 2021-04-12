using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
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

        public Guid MoradorIdFuncionarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public bool Visto { get; private set; }

        public Foto Foto { get; private set; }

        public RespostaOcorrencia()
        {
        }

        public RespostaOcorrencia
            (Guid ocorrenciaId, string descricao, TipoDoAutor tipoAutor, Guid moradorIdFuncionarioId,
            string nomeUsuario, bool visto, Foto foto)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = tipoAutor;
            MoradorIdFuncionarioId = moradorIdFuncionarioId;
            NomeUsuario = nomeUsuario;
            Visto = visto;
            Foto = foto;
        }

        public void MarcarComoVisto() => Visto = true;

        public void SetMoradorIdFuncionarioId(Guid id) => MoradorIdFuncionarioId = id;


        public ValidationResult Editar(string descricao, Foto foto, Guid moradorIdFuncionarioId)
        {
            if (MoradorIdFuncionarioId != moradorIdFuncionarioId)
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
            Foto = foto;

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

        public void EnviarPushParaSindico(Guid condominioId)
        {
            var titulo = "Ocorrência Respondida";

            AdicionarEvento
                (new EnviarPushParaSindicoIntegrationEvent(condominioId, titulo, Descricao));
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
                (titulo, descricaoDaOcorrencia, Descricao, NomeUsuario, 
                 DataDeCadastroFormatada, Foto.NomeDoArquivo, moradorId));
        }
        private void EnviarEmailOcorrenciaResolvida(Guid moradorId, string descricaoDaOcorrencia)
        {
            var titulo = "Ocorrência Resolvida";

            AdicionarEvento
                (new EnviarEmailRespostaOcorrenciaParaMoradorIntegrationEvent
                (titulo, descricaoDaOcorrencia, Descricao, NomeUsuario,
                 DataDeCadastroFormatada, Foto.NomeDoArquivo, moradorId));
        }

        
        
        public void EnviarEmailParaSindico(Guid condominioId, StatusDaOcorrencia statusDaOcorrencia, string descricaoDaOcorrencia)
        {
            var titulo = "Ocorrência Respondida";

            AdicionarEvento
                (new EnviarEmailRespostaOcorrenciaParaSindicoIntegrationEvent
                (titulo, descricaoDaOcorrencia, Descricao, NomeUsuario, statusDaOcorrencia.ToString(),
                 DataDeCadastroFormatada, Foto.NomeDoArquivo, condominioId));
        }

    } 
}
