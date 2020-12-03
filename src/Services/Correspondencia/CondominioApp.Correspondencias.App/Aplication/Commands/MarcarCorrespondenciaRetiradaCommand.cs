using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class MarcarCorrespondenciaRetiradaCommand : CorrespondenciaCommand
    {
        public MarcarCorrespondenciaRetiradaCommand(
            Guid correspondenciaId, string nomeRetirante, string observacao, Guid usuarioId, string nomeUsuario)
        {
            CorrespondenciaId = correspondenciaId;
            NomeRetirante = nomeRetirante;
            Observacao = observacao;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarCorrespondenciaRetiradaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarCorrespondenciaRetiradaCommandValidation : CorrespondenciaValidation<MarcarCorrespondenciaRetiradaCommand>
        {
            public MarcarCorrespondenciaRetiradaCommandValidation()
            {
                ValidateId();
                ValidateNomeRetirante();
                ValidateUsuarioId();
                ValidateNomeUsuario();
            }
        }
    }
}
