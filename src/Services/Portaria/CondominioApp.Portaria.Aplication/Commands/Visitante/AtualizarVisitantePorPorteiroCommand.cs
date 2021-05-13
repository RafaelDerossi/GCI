using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AtualizarVisitantePorPorteiroCommand : VisitanteCommand
    {

        public AtualizarVisitantePorPorteiroCommand
            (Guid id, string nome,TipoDeDocumento tipoDeDocumento, string documento, string email, string foto,
            string nomeOriginalFoto, TipoDeVisitante tipoDeVisitante, string nomeEmpresa, bool temVeiculo)
        {
            Id = id;
            SetNome(nome);                 
            TipoDeVisitante = tipoDeVisitante;
            NomeEmpresa = nomeEmpresa;
            TemVeiculo = temVeiculo;

            SetDocumento(documento, tipoDeDocumento);
            SetEmail(email);
            SetFoto(nomeOriginalFoto, foto);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AtualizarVisitantePorPorteiroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarVisitantePorPorteiroCommandValidation : VisitanteValidation<AtualizarVisitantePorPorteiroCommand>
        {
            public AtualizarVisitantePorPorteiroCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateVisitantePermanente();
                ValidateTipoDeVisitante();
            }
        }

    }
}
