using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class VeiculoCondominio : Entity
    {
        public Guid VeiculoId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public Guid CondominioId { get; private set; }

        public Guid UsuarioId { get; private set; }

        public string Tag { get; private set; }

        public string Observacao { get; private set; }

        protected VeiculoCondominio() { }

        public VeiculoCondominio
            (Guid veiculoId, Guid unidadeId, Guid condominioId, Guid usuarioId, string tag, string observacao)
        {
            VeiculoId = veiculoId;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
            UsuarioId = usuarioId;
            Tag = tag;
            Observacao = observacao;
        }

        public void SetTag(string tag) => Tag = tag;

        public void SetObservacao(string observacao) => Observacao = observacao;

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetUsuarioId(Guid id) => UsuarioId = id;

    }
}