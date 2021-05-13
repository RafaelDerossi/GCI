using CondominioApp.Core.Enumeradores;
using CondominioApp.Portaria.Aplication.Commands.Validations;
using System;

namespace CondominioApp.Portaria.Aplication.Commands
{
   public class AtualizarVisitantePorMoradorCommand : VisitanteCommand
    {

        public AtualizarVisitantePorMoradorCommand
            (Guid id, string nome,TipoDeDocumento tipoDeDocumento, string documento, string email, string foto,
            string nomeOriginalFoto, bool visitantePermanente, TipoDeVisitante tipoDeVisitante, string nomeEmpresa,
            bool temVeiculo)
        {
            Id = id;
            SetNome(nome);
            VisitantePermanente = visitantePermanente;           
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

            ValidationResult = new AtualizarVisitantePorMoradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AtualizarVisitantePorMoradorCommandValidation : VisitanteValidation<AtualizarVisitantePorMoradorCommand>
        {
            public AtualizarVisitantePorMoradorCommandValidation()
            {
                ValidateId();
                ValidateNome();
                ValidateVisitantePermanente();
                ValidateTipoDeVisitante();
            }
        }

    }
}
