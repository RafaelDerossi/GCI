using CondominioApp.Correspondencias.App.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Correspondencias.App.Aplication.Commands
{
    public class MarcarCorrespondenciaRetiradaCommand : CorrespondenciaCommand
    {
        public MarcarCorrespondenciaRetiradaCommand(
            Guid correspondenciaId, string nomeRetirante, string observacao,
            Guid entreguePorId, string entreguePorNome, string nomeOriginalFotoRetirante)
        {
            CorrespondenciaId = correspondenciaId;
            NomeRetirante = nomeRetirante;
            ObservacaoDaRetirada = observacao;
            EntreguePorId = entreguePorId;
            EntreguePorNome = entreguePorNome;
            SetFotoRetirante(nomeOriginalFotoRetirante);
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
                ValidateEntreguePorId();
                ValidateEntreguePorNome();
            }
        }
    }
}
