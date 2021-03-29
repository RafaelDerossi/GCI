using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Messages.CommonMessages.IntegrationEvents;
using CondominioApp.Ocorrencias.App.ValueObjects;
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

        public void SetDescricao(string descricao) => Descricao = descricao;

        public void EnviarPushOcorrenciaEmAndamento(Guid moradorId)
        {
            var titulo = "OCORRÊNCIA EM ANDAMENTO";

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(moradorId, titulo, Descricao));
        }

        public void EnviarPushOcorrenciaResolvida(Guid moradorId)
        {
            var titulo = "OCORRÊNCIA RESOLVIDA";

            AdicionarEvento
                (new EnviarPushParaMoradorIntegrationEvent(moradorId, titulo, Descricao));
        }

        public void EnviarPushNovaMsgDeMorador(Guid condominioId)
        {
            var titulo = "OCORRÊNCIA RESPONDIDA";

            AdicionarEvento
                (new EnviarPushParaSindicoIntegrationEvent(condominioId, titulo, Descricao));
        }

    }
}
