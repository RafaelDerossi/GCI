using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using CondominioApp.Enquetes.App.Models;
using CondominioApp.Enquetes.App.ViewModels;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class EditarEnqueteCommand : EnqueteCommand
    {

        public EditarEnqueteCommand
            (Guid enqueteId, string descricao, DateTime dataInicio, DateTime dataFim, bool apenasProprietarios,
             IEnumerable<AlternativaEnquete> alternativas)
        {
            Id = enqueteId;
            Descricao = descricao;           
            ApenasProprietarios = apenasProprietarios;

            SetDataInicio(dataInicio);
            SetDataFim(dataFim);
            SetAlternativas(alternativas);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new EditarEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class EditarEnqueteCommandValidation : EnqueteValidation<EditarEnqueteCommand>
        {
            public EditarEnqueteCommandValidation()
            {
                ValidateId();
                ValidateDescricao();
                ValidateDataInicial();
                ValidateDataFinal();              
                ValidateApenasProprietarios();               
            }
        }

    }
}
