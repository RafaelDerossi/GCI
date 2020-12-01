using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class AlterarEnqueteCommand : EnqueteCommand
    {

        public AlterarEnqueteCommand(Guid enqueteId, string descricao, DateTime dataInicio, DateTime dataFim, bool apenasProprietarios)
        {
            Id = enqueteId;
            Descricao = descricao;           
            ApenasProprietarios = apenasProprietarios;

            SetDataInicio(dataInicio);
            SetDataFim(dataFim);            
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AlterarEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AlterarEnqueteCommandValidation : EnqueteValidation<AlterarEnqueteCommand>
        {
            public AlterarEnqueteCommandValidation()
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
