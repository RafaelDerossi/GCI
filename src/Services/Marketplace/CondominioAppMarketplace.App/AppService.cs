using System.Threading.Tasks;
using CondominioApp.Core.Data;
using FluentValidation.Results;

namespace CondominioAppMarketplace.App
{
    public class AppService
    {
        protected ValidationResult ValidationResult;

        protected AppService()
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