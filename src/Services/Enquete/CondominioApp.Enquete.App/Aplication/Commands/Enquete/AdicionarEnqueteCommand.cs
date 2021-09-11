using CondominioApp.Enquetes.App.Aplication.Commands.Validations;
using CondominioApp.Enquetes.App.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace CondominioApp.Enquetes.App.Aplication.Commands
{
   public class AdicionarEnqueteCommand : EnqueteCommand
    {

        public AdicionarEnqueteCommand(string descricao, DateTime dataInicio, DateTime dataFim,
            Guid condominioId, string condominioNome, Guid funcionarioId, string funcionarioNome,
            bool apenasProprietarios, IEnumerable<AlternativaEnquete> alternativas)
        {            
            Descricao = descricao;
            CondominioId = condominioId;
            CondominioNome = condominioNome;
            FuncionarioId = funcionarioId;
            FuncionarioNome = funcionarioNome;
            ApenasProprietarios = apenasProprietarios;

            SetDataInicio(dataInicio);
            SetDataFim(dataFim);
            SetAlternativas(alternativas);
        }


        public override bool EstaValido()
        {
            if (!ValidationResult.IsValid)
                return ValidationResult.IsValid;

            ValidationResult = new AdicionarEnqueteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


        public class AdicionarEnqueteCommandValidation : EnqueteValidation<AdicionarEnqueteCommand>
        {
            public AdicionarEnqueteCommandValidation()
            {               
                ValidateDescricao();
                ValidateDataInicial();
                ValidateDataFinal();
                ValidateUsuarioId();
                ValidateUsuarioNome();
                ValidateCondominioId();
                ValidateCondominioNome();
                ValidateApenasProprietarios();
                ValidateAlternativas();               
            }
        }

    }
}
