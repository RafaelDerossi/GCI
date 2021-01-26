using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class EditarVisitantePorMoradorCommand : VisitanteCommand
    {

        public EditarVisitantePorMoradorCommand
            (Guid id, string nome, string documento, string email, string foto, string nomeOriginalFoto,
            bool visitantePermanente, TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
        {
            Id = id;
            SetNome(nome);
            VisitantePermanente = visitantePermanente;           
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;

            SetDocumento(documento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto, foto);           
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarVisitantePorMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVisitantePorMoradorCommandValidation : VisitanteValidation<EditarVisitantePorMoradorCommand>
        {
            public EditarVisitantePorMoradorCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateVisitantePermanente();
                ValidateTipoDeVisitante();
            }
        }

    }
}
