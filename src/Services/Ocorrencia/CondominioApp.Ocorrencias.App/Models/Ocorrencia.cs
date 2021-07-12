using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Ocorrencia;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoPushIntegrationEvents;
using CondominioApp.Ocorrencias.App.ValueObjects;
using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace CondominioApp.Ocorrencias.App.Models
{
   public class Ocorrencia : Entity, IAggregateRoot
    {
        public const int Max = 200;

        public string Descricao { get; private set; }
        public Foto Foto { get; private set; }
        public bool Publica { get; private set; }


        public StatusDaOcorrencia Status { get; private set; }        
        public DateTime? DataResolucao { get; private set; }

        public Guid UnidadeId { get; private set; }
        public Guid MoradorId { get; private set; }
        public string NomeMorador { get; set; }
        public Guid CondominioId { get; private set; }
        
        public bool Panico { get; private set; }


        private readonly List<RespostaOcorrencia> _Respostas;
        public IReadOnlyCollection<RespostaOcorrencia> Respostas => _Respostas;


        public string Url
        {
            get
            {
                if (Foto == null)
                    return "";

                return StoragePaths.ObterUrlDeArquivo(CondominioId.ToString(), Foto.NomeDoArquivo);
            }
        }


        public Ocorrencia()
        {
            _Respostas = new List<RespostaOcorrencia>();
        }
        public Ocorrencia
            (string descricao, Foto foto, bool publica, Guid unidadeId,
            Guid moradorId, string nomeMorador, Guid condominioId, bool panico)
        {
            _Respostas = new List<RespostaOcorrencia>();
            Descricao = descricao;
            Foto = foto;
            Publica = publica;
            UnidadeId = unidadeId;
            MoradorId = moradorId;
            NomeMorador = nomeMorador;
            CondominioId = condominioId;            
            Panico = panico;
        }

        
        
        
        
        public void SetDescricao(string descricao) => Descricao = descricao;        

        public void SetFoto(Foto foto) => Foto = foto;

        public void SetMoradorId(Guid id) => MoradorId = id;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;



        public void MarcarComoPublica() => Publica = true;

        public void MarcarComoPrivada() => Publica = false;


        public void MarcarComoOcorrenciaDePanico() => Panico = true;

        public void DesmarcarComoOcorrenciaDePanico() => Panico = false;


       


        public ValidationResult AdicionarRespostaDeSindico(RespostaOcorrencia resposta, StatusDaOcorrencia novoStatus)
        {
            if (resposta.TipoAutor == TipoDoAutor.MORADOR)
            {
                AdicionarErrosDaEntidade("Autor da resposta inválido!");
                return ValidationResult;
            }

            if (novoStatus == StatusDaOcorrencia.PENDENTE)
            {
                AdicionarErrosDaEntidade("Novo Status da Ocorrência deve ser 'Em Andamento' ou  'Resolvida'!");
                return ValidationResult;
            }

            if (novoStatus == StatusDaOcorrencia.EM_ANDAMENTO)
            {
                var retornoOcorrencia = ColocarEmAndamento();
                if (!retornoOcorrencia.IsValid)
                    return retornoOcorrencia;
            }

            if (novoStatus == StatusDaOcorrencia.RESOLVIDA)
            {
                var retornoOcorrencia = MarcarComoResolvida();
                if (!retornoOcorrencia.IsValid)
                    return retornoOcorrencia;
            }           

            _Respostas.Add(resposta);

            return ValidationResult;
        }

        public ValidationResult AdicionarRespostaDeMorador(RespostaOcorrencia resposta)
        {

            if (resposta.TipoAutor == TipoDoAutor.MORADOR && !Publica && MoradorId != resposta.MoradorIdFuncionarioId)
            {
                AdicionarErrosDaEntidade("Somente o usuário que criou a ocorrência privada pode responder!");
                return ValidationResult;
            }

            if (Status == StatusDaOcorrencia.RESOLVIDA)
            {
                AdicionarErrosDaEntidade("Ocorrência já está resolvida!");
                return ValidationResult;
            }

            _Respostas.Add(resposta);

            return ValidationResult;
        }

        private ValidationResult ColocarEmAndamento()
        {
            if (Status == StatusDaOcorrencia.RESOLVIDA)
            {
                AdicionarErrosDaEntidade("Ocorrência já está resolvida!");
                return ValidationResult;
            }
            Status = StatusDaOcorrencia.EM_ANDAMENTO;
            return ValidationResult;
        }

        private ValidationResult MarcarComoResolvida()
        {
            if (Status == StatusDaOcorrencia.RESOLVIDA)
            {
                AdicionarErrosDaEntidade("Ocorrência já está resolvida!");
                return ValidationResult;
            }
            Status = StatusDaOcorrencia.RESOLVIDA;
            DataResolucao = DataHoraDeBrasilia.Get();
            return ValidationResult;
        }


        public ValidationResult Editar(string descricao, Foto foto, bool publica)
        {
            if (Status != StatusDaOcorrencia.PENDENTE)
            {
                AdicionarErrosDaEntidade("Ocorrência não pode ser editada pois já foi respondida!");
                return ValidationResult;
            }               

            SetDescricao(descricao);
            SetFoto(foto);
            MarcarComoPrivada();
            if (publica)
                MarcarComoPublica();

            return ValidationResult;
        }

        public ValidationResult Remover()
        {
            if (Status != StatusDaOcorrencia.PENDENTE)
            {
                AdicionarErrosDaEntidade("Ocorrência não pode ser removida pois já foi respondida!");
                return ValidationResult;
            }

            return ValidationResult;
        }


        public void EnviarPushNovaOcorrencia()
        {
            var titulo = ObterTituloParaNovoPushEEmail();

            AdicionarEvento
              (new EnviarPushParaAdministracaoIntegrationEvent(CondominioId, titulo, Descricao));

            AdicionarEvento
            (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, Descricao));

            return;
        }

        public void EnviarPushOcorrenciaEditada()
        {
            var titulo = "Ocorrência Editada";

            AdicionarEvento
                 (new EnviarPushParaAdministracaoIntegrationEvent(CondominioId, titulo, Descricao));

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, Descricao));
        }

        public void EnviarPushOcorrenciaRemovida()
        {
            var titulo = "Ocorrência Removida";

            AdicionarEvento
                 (new EnviarPushParaAdministracaoIntegrationEvent(CondominioId, titulo, Descricao));

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, Descricao));
        }



        public void EnviarEmailNovaOcorrencia()
        {         
            var titulo = ObterTituloParaNovoPushEEmail();
            
            AdicionarEvento
                 (new EnviarEmailOcorrenciaIntegrationEvent
                 (titulo, Descricao, NomeMorador, ObterStatusPrivacidade(),
                  Status.ToString(), DataDeCadastroFormatada, Foto.NomeDoArquivo,
                  UnidadeId));

            return;
        }

        public void EnviarEmailOcorrenciaEditada()
        {
            var titulo = "Ocorrência Editada";

            AdicionarEvento
                 (new EnviarEmailOcorrenciaIntegrationEvent
                 (titulo, Descricao, NomeMorador, ObterStatusPrivacidade(),
                  Status.ToString(), DataDeAlteracaoFormatada, Foto.NomeDoArquivo,
                  UnidadeId));

            return;
        }

        public void EnviarEmailOcorrenciaRemovida()
        {
            var titulo = "Ocorrência Removida";

            AdicionarEvento
                 (new EnviarEmailOcorrenciaIntegrationEvent
                 (titulo, Descricao, NomeMorador, ObterStatusPrivacidade(),
                  Status.ToString(), DataDeAlteracaoFormatada, Foto.NomeDoArquivo,
                  UnidadeId));

            return;
        }


        public string ObterStatusPrivacidade()
        {
            if (Publica)
                return "Pública";
            return "Privada";
        }

        public string ObterTituloParaNovoPushEEmail()
        {
            if (Panico)
                return "EMERGÊNCIA"; ;
            return "Nova Ocorrência";
        }
    }
}
