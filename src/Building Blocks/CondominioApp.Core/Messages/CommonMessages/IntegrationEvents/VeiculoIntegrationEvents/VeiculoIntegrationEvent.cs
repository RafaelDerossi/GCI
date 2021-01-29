using System;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class VeiculoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; protected set; }

        public Guid VeiculoId { get; protected set; }

        public string Placa { get; protected set; }

        public string Modelo { get; protected set; }

        public string Cor { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public string NomeUsuario { get; set; }

        public Guid UnidadeId { get; protected set; }

        public Guid CondominioId { get; protected set; }
    }
}