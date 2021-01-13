using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class EditarVisitanteCommand : VisitanteCommand
    {

        public EditarVisitanteCommand
            (Guid id, string nome, string documento, string email, string foto, string nomeOriginalFoto,
            bool visitantePermanente, TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo,
            string placaVeiculo, string modeloVeiculo, string corVeiculo)
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
            SetVeiculo(placaVeiculo, modeloVeiculo, corVeiculo);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarVisitanteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarVisitanteCommandValidation : VisitanteValidation<EditarVisitanteCommand>
        {
            public EditarVisitanteCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateVisitantePermanente();
                ValidateTipoDeVisitante();
            }
        }

    }
}
