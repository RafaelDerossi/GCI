using CondominioApp.Core.Enumeradores;
using System;
using System.Collections.Generic;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents.NotificacaoEmailIntegrationEvent.Correspondencia
{
    public class EnviarEmailCorrespondenciaIntegrationEvent : IntegrationEvent
    {
        public string Assunto { get; private set; }

        public string Titulo { get; private set; }

        public string Descricao { get; private set; }
        
        public Guid UnidadeId { get; private set; }

        public string NomeArquivoFoto { get; private set; }

        public string RecebidoPor { get; private set; }        

        public string Codigo { get; private set; }

        public string Tipo { get; private set; }

        public string Localizacao { get; private set; }

        public string Observacao { get; private set; }
        

        public EnviarEmailCorrespondenciaIntegrationEvent
            (string assunto, string titulo, string descricao, Guid unidadeId,
             string nomeArquivoFoto, string recebidoPor, string codigo, string tipo,
             string localizacao, string observacao)
        {
            Assunto = assunto;
            Titulo = titulo;
            Descricao = descricao;
            UnidadeId = unidadeId;
            NomeArquivoFoto = nomeArquivoFoto;
            RecebidoPor = recebidoPor;
            Codigo = codigo;
            Tipo = tipo;
            Localizacao = localizacao;
            Observacao = observacao;
        }

    }
}