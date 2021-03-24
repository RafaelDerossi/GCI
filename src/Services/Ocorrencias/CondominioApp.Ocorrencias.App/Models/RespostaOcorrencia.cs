using CondominioApp.Core.DomainObjects;
using CondominioApp.Core.Enumeradores;
using CondominioApp.Ocorrencias.App.ValueObjects;
using System;

namespace CondominioApp.Ocorrencias.App.Models
{
  public class RespostaOcorrencia : Entity
    {
        public Guid OcorrenciaId { get; private set; }

        public string Descricao { get; private set; }

        public TipoDoAutor TipoAutor  { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string NomeUsuario { get; private set; }

        public bool Visto { get; private set; }

        public Foto Foto { get; private set; }

        public RespostaOcorrencia()
        {
        }

        public RespostaOcorrencia
            (Guid ocorrenciaId, string descricao, TipoDoAutor tipoAutor, Guid usuarioId,
            string nomeUsuario, bool visto, Foto foto)
        {
            OcorrenciaId = ocorrenciaId;
            Descricao = descricao;
            TipoAutor = tipoAutor;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            Visto = visto;
            Foto = foto;
        }

        public void MarcarComoVisto() => Visto = true;

    }
}
