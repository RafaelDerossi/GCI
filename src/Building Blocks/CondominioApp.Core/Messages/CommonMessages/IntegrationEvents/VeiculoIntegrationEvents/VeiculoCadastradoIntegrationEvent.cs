using System;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class VeiculoCadastradoIntegrationEvent : IntegrationEvent
    {
        public Guid VeiculoId { get; protected set; }

        public string Placa { get; protected set; }

        public string Modelo { get; protected set; }

        public string Cor { get; protected set; }

        public Guid UsuarioId { get; protected set; }

        public string NomeUsuario { get; set; }

        public Guid UnidadeId { get; protected set; }

        public VeiculoCadastradoIntegrationEvent(
            Guid veiculoId, string placa, string modelo, string cor, Guid usuarioId,
            string nomeUsuario, Guid unidadeId)
        {
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            UnidadeId = unidadeId; 
        }
    }
}