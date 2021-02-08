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


        protected VeiculoCondominio() { }

        public VeiculoCondominio(Guid veiculoId, Guid unidadeId, Guid condominioId, Guid usuarioId)
        {
            VeiculoId = veiculoId;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
            UsuarioId = usuarioId; 
        }

        public void SetUnidadeId(Guid id) => UnidadeId = id;

        public void SetCondominioId(Guid id) => CondominioId = id;

        public void SetUsuarioId(Guid id) => UsuarioId = id;

    }
}