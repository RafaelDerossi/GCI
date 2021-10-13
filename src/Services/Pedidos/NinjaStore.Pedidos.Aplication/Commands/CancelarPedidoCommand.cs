using NinjaStore.Core.Messages.DTO;
using NinjaStore.Pedidos.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace NinjaStore.Pedidos.Aplication.Commands
{
    public class CancelarPedidoCommand : PedidoCommand
    {
        public CancelarPedidoCommand(Guid pedidoId, string justiicativa)
        {
            AggregateId = pedidoId;
            Id = pedidoId;
            JustificativaCancelamento = justiicativa;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new CancelarPedidoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CancelarPedidoCommandValidation : PedidoValidation<CancelarPedidoCommand>
        {
            public CancelarPedidoCommandValidation()
            {
                ValidateId();
                ValidateJustificaticaCancelamento();
            }
        }

    }
}
