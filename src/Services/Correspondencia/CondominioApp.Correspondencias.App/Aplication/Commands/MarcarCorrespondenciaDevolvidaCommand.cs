using CondominioApp.Core.Enumeradores;
using CondominioApp.Core.Helpers;
using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class MarcarCorrespondenciaDevolvidaCommand : CorrespondenciaCommand
    {
        public MarcarCorrespondenciaDevolvidaCommand(
            Guid correspondenciaId, string observacao, Guid usuarioId, string nomeUsuario)
        {
            CorrespondenciaId = correspondenciaId;
            Observacao = observacao;
            UsuarioId = usuarioId;
            NomeUsuario = nomeUsuario;
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new MarcarCorrespondenciaDevolvidaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class MarcarCorrespondenciaDevolvidaCommandValidation : CorrespondenciaValidation<MarcarCorrespondenciaDevolvidaCommand>
        {
            public MarcarCorrespondenciaDevolvidaCommandValidation()
            {
                ValidateId();
                ValidateUsuarioId();
                ValidateNomeUsuario();
            }
        }
    }
}
