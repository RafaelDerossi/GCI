using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using CondominioApp.Enquetes.App.Models;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class CadastrarEnqueteCommand : EnqueteCommand
    {

        public CadastrarEnqueteCommand(string descricao, DateTime dataInicio, DateTime dataFim,
            Guid condominioId, string condominioNome, Guid usuarioId, string usuarioNome,
            bool apenasProprietarios, IEnumerable<string> alternativas )
        {            
            Descricao = descricao;
            CondominioId = condominioId;
            CondominioNome = condominioNome;
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;

            SetDataInicio(dataInicio);
            SetDataFim(dataFim);
            SetAlternativas(alternativas);
        }


        public override bool EstaValido()
        {
            ValidationResult = new CadastrarEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class CadastrarEnqueteCommandValidation : EnqueteValidation<CadastrarEnqueteCommand>
        {
            public CadastrarEnqueteCommandValidation()
            {               
                ValidateDescricao();
                ValidateDataInicial();
                ValidateDataFinal();
                ValidateUsuarioId();
                ValidateUsuarioNome();
                ValidateCondominioId();
                ValidateCondominioNome();
                ValidateApenasProprietarios();               
            }
        }

    }
}
