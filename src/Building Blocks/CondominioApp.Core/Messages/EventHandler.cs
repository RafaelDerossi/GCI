﻿using System.Threading.Tasks;
using CondominioApp.Core.Data;
using FluentValidation.Results;

namespace CondominioApp.Core.Messages
{
    public class EventHandler
    {
        protected ValidationResult ValidationResult;

        protected EventHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWorks uow)
        {
            try
            {
                if (!await uow.Commit()) AdicionarErro("Houve um erro ao persistir os dados");
            }
            catch (System.Exception ex)
            {
                AdicionarErro(ex.Message);
            }          

            return ValidationResult;
        }
        
        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}