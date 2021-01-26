using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class EditarVisitantePorPorteiroCommand : VisitanteCommand
    {

        public EditarVisitantePorPorteiroCommand
            (Guid id, string nome, string documento, string email, string foto, string nomeOriginalFoto,
            TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo)
        {
            Id = id;
            SetNome(nome);                 
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;

            SetDocumento(documento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto, foto);
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarVisitantePorPorteiroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVisitantePorPorteiroCommandValidation : VisitanteValidation<EditarVisitantePorPorteiroCommand>
        {
            public EditarVisitantePorPorteiroCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateVisitantePermanente();
                ValidateTipoDeVisitante();
            }
        }

    }
}
