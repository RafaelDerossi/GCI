using CondominioApp.Core.DomainObjects;
using System;

namespace CondominioApp.Usuarios.App.Models
{
    public class Morador : Entity
    {
        public Guid UsuarioId { get; private set; }

        public Guid UnidadeId { get; private set; }

        public Guid CondominioId { get; private set; }

        public bool Proprietario { get; private set; }

        public bool Principal { get; private set; }

        public Morador(Guid usuarioId, Guid unidadeId, Guid condominioId, bool proprietario, bool principal)
        {
            UsuarioId = usuarioId;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
            Proprietario = proprietario;
            Principal = principal;
        }


        public void SetUsuarioId(Guid usuarioId) => UsuarioId = usuarioId;

        public void SetUnidadeId(Guid unidadeId) => UnidadeId = unidadeId;

        public void SetCondominioId(Guid condominioId) => CondominioId = condominioId;

        public void MarcarComoProprietario() => Proprietario = true;
        public void DesmarcarComoProprietario() => Proprietario = false;

        public void MarcarComoPrincipal() => Principal = true;
        public void DesmarcarComoPrincipal() => Principal = false;

    }
}
