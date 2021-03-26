  using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
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
        public Guid CondominioId { get; private set; }       
        
        public bool Panico { get; private set; }


        private readonly List<RespostaOcorrencia> _Respostas;
        public IReadOnlyCollection<RespostaOcorrencia> Respostas => _Respostas;


        public Ocorrencia()
        {
            _Respostas = new List<RespostaOcorrencia>();
        }
        public Ocorrencia
            (string descricao, Foto foto, bool publica, Guid unidadeId,
            Guid moradorId, Guid condominioId, bool panico)
        {
            _Respostas = new List<RespostaOcorrencia>();
            Descricao = descricao;
            Foto = foto;
            Publica = publica;
            UnidadeId = unidadeId;
            MoradorId = moradorId;
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


        public void ColocarEmAndamento()
        {
            Status = StatusDaOcorrencia.EM_ANDAMENTO;            
        }

        public void MarcarComoResolvida()
        {
            Status = StatusDaOcorrencia.RESOLVIDA;
            DataResolucao = DataHoraDeBrasilia.Get();
        }

        public ValidationResult AdicionarResposta(RespostaOcorrencia resposta)
        {
            if (Status == StatusDaOcorrencia.RESOLVIDA)
            {
                AdicionarErrosDaEntidade("Ocorrência já está resolvida!");
                return ValidationResult;
            }

            if (resposta.TipoAutor == TipoDoAutor.MORADOR && !Publica && MoradorId != resposta.UsuarioId)
            {
                AdicionarErrosDaEntidade("Somente o usuário que criou a ocorrência privada pode responder!");
                return ValidationResult;
            }

            _Respostas.Add(resposta);

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

            EnviarParaLixeira();

            return ValidationResult;
        }

        public void EnviarPushNovaOcorrencia()
        {
            var titulo = "";
            if (Panico)
            {
                titulo = "ALERTA";

                AdicionarEvento
                 (new EnviarPushParaSindicoIntegrationEvent(CondominioId, titulo, Descricao));

                AdicionarEvento
                (new EnviarPushParaUnidadeIntegrationEvent(UnidadeId, titulo, Descricao));

                return;
            }

            titulo = "NOVA OCORRÊNCIA";

            AdicionarEvento
                 (new EnviarPushParaSindicoIntegrationEvent(CondominioId, titulo, Descricao));

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, Descricao));
        }

        public void EnviarPushOcorrenciaEditada()
        {
            var titulo = "OCORRÊNCIA EDITADA";

            AdicionarEvento
                 (new EnviarPushParaSindicoIntegrationEvent(CondominioId, titulo, Descricao));

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, Descricao));
        }

        public void EnviarPushOcorrenciaRemovida()
        {           

            var titulo = "OCORRÊNCIA REMOVIDA";

            AdicionarEvento
                 (new EnviarPushParaSindicoIntegrationEvent(CondominioId, titulo, Descricao));

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(MoradorId, titulo, Descricao));
        }
    }
}
