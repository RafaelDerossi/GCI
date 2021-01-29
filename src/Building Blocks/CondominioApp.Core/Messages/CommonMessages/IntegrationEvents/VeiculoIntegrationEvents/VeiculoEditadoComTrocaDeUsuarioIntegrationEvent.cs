using System;

namespace CondominioApp.Core.Messages.CommonMessages.IntegrationEvents
{
    public class VeiculoEditadoComTrocaDeUsuarioIntegrationEvent : VeiculoIntegrationEvent
    {        
        public VeiculoEditadoComTrocaDeUsuarioIntegrationEvent(
            Guid id, Guid veiculoId, string placa, string modelo, string cor, Guid usuarioId,
            string nomeUsuario, Guid unidadeId, Guid condominioId)
        {
            Id = id;
            VeiculoId = veiculoId;
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
            UnidadeId = unidadeId;
            CondominioId = condominioId;
        }
    }
}